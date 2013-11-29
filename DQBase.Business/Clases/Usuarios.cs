using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DQBase.Entities;
using DQBase.DataAccessLayer;

namespace DQBase.Business
{
    public partial class BusinessLogic : IUsuarios
    {
        /// <summary>
        /// Metodo para autenticar un usuario en el sistema
        /// </summary>
        /// <param name="usuario">usuario que se va a autenticar</param>
        /// <exception cref="System.ArgumentNullException"/>
        /// <returns></returns>
        public UsuarioAutenticado Autenticar(USUARIO usuario)
        {
            UsuarioAutenticado response = null;
            try
            {
                if (usuario == null)
                    throw new ArgumentNullException("usuario");

                using (DQBaseContext ctx=new DQBaseContext(ConnectionString))
                {
                    var usuarioAutenticado = (from user in ctx.USUARIO
                                                  where user.USUARIO1 == usuario.USUARIO1 && user.CLAVE == usuario.CLAVE
                                                  select new 
                                                  { 
                                                      user,
                                                      rol=(from rolusuario in ctx.ROLUSUARIO
                                                            where rolusuario.IDUSUARIO==user.IDUSUARIO
                                                            select rolusuario).FirstOrDefault()
                                                  }
                                                  ).FirstOrDefault();

                    if (null == usuarioAutenticado) return null;

                    if (null == usuarioAutenticado.rol) return null;

                    List<MENU> menuUsuario = (from menu in ctx.MENU
                                              join rolmenu in ctx.ROLMENU on menu.IDMENU equals rolmenu.IDMENU
                                              join rol in ctx.ROL on rolmenu.IDROL equals rol.IDROL
                                              where usuarioAutenticado.rol.IDROL == rol.IDROL
                                              select menu).ToList();

                    if (null == menuUsuario) return null;

                    response = new UsuarioAutenticado
                    {
                        Usuario = usuarioAutenticado.user,
                        Menu = menuUsuario
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Crea un usuario para el sistema
        /// </summary>
        /// <param name="usuario">Usuario a crear</param>
        public void CrearUsuario(USUARIO usuario)
        {
            try
            {
                using (DQBaseContext contex = new DQBaseContext(ConnectionString))
                {
                    var dbquery = (from user in contex.USUARIO
                                   where user.USUARIO1 == usuario.USUARIO1 && user.ESBORRADOUSUARIO==false
                                   select user).FirstOrDefault();
                    if (dbquery == null)
                    {
                        if (usuario.IDLABORATORIO == Guid.Empty)
                            usuario.IDLABORATORIO = null;
                        contex.USUARIO.ApplyChanges(usuario);
                        contex.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El usuario ya existe");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene la lista de roles del sistema
        /// </summary>
        /// <returns></returns>
        public List<ROL> ObtenerRoles()
        {
            List<ROL> response = null;
            try
            {
                using (DQBaseContext contex =new DQBaseContext(ConnectionString))
                {
                    response = (from rol in contex.ROL
                                select rol).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Busca el nombre del usuario y los roles del mismo
        /// </summary>
        ///<param name="nombreUsuario">Nombre del usuario</param>
        /// <returns></returns>
        public USUARIO BuscaUsuarioRol(string nombreUsuario)
        {
            USUARIO response = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    var dbQuery = from user in context.USUARIO
                                  where user.NOMBRECOMPLETO == nombreUsuario
                                  select new
                                  {
                                      user.IDUSUARIO,
                                      user.NOMBRECOMPLETO,
                                      user.ROLUSUARIO
                                  };
                    response = (from user in dbQuery.ToList()
                                select new USUARIO
                                {
                                    IDUSUARIO=user.IDUSUARIO,
                                    NOMBRECOMPLETO = user.NOMBRECOMPLETO,
                                    ROLUSUARIO = user.ROLUSUARIO
                                }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Asigna los roles al usuario
        /// </summary>
        /// <param name="rolesAsignados">lista de roles a cargar</param>
        public void AsignaUsuarioRol(List<ROLUSUARIO> rolesAsignados)
        {
            try
            {
                Guid idUsuario = rolesAsignados[0].IDUSUARIO;
                using (DQBaseContext contex=new DQBaseContext(ConnectionString))
                {
                    var roles = (from rol in contex.ROLUSUARIO
                                 where rol.IDUSUARIO == idUsuario
                                 select rol).ToList();
                    if (roles != null && roles.Count > 0)
                    {
                        roles.ForEach(rol => 
                        {
                            contex.ROLUSUARIO.DeleteObject(rol);
                        });
                        contex.SaveChanges();
                    }
                    rolesAsignados.ForEach(rol =>
                    {
                        contex.ROLUSUARIO.ApplyChanges(rol);
                    });
                    contex.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene la lista de usuarios
        /// </summary>
        /// <returns></returns>
        public List<UsuarioDetalle> ObtenerListaUsuarios()
        {
            List<UsuarioDetalle> response = null;
            List<LABORATORIO> laboratorios=ObtenerLaboratorio();
            try
            {
                using (DQBaseContext context = new DQBaseContext(ConnectionString))
                {
                    response = (from user in context.USUARIO
                                where user.ESBORRADOUSUARIO == false
                                select user).ToList().Select(data => new UsuarioDetalle
                                {
                                    FechaCaducidad = data.FechaCaducidad != null ? data.FechaCaducidad.Value.ToShortDateString() : string.Empty,
                                    FechaCreacion = data.FechaCreacion != null ? data.FechaCreacion.Value.ToShortDateString() : string.Empty,
                                    Laboratorio = data.IDLABORATORIO != null ? laboratorios.FirstOrDefault(x => x.IDLABORATORIO == data.IDLABORATORIO).NOMBRELABORATORIO : string.Empty,
                                    NombreCompleto = data.NOMBRECOMPLETO,
                                    NombreUsuario = data.USUARIO1,
                                    IdUsuario = data.IDUSUARIO
                                }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Busca un usuario por su id
        /// </summary>
        /// <param name="idUsuartio"></param>
        /// <returns></returns>
        public USUARIO BuscarUsuarioPorId(Guid idUsuartio)
        {
            USUARIO response = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    response = (from user in context.USUARIO
                                where user.IDUSUARIO == idUsuartio && user.ESBORRADOUSUARIO == false
                                select user).FirstOrDefault();
                    if(response!=null)
                        response = response.MarkAsUnchanged();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Edita o crea un usuario
        /// </summary>
        /// <param name="usuario">usuario</param>
        public void SaveUsuario(USUARIO usuario)
        {
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    context.USUARIO.ApplyChanges(usuario);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Guarda un rol
        /// </summary>
        /// <param name="rol">rol</param>
        public void SaveRol(ROL rol)
        {
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    context.ROL.ApplyChanges(rol);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
