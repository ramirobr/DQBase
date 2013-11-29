using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DQBase.Entities;

namespace DQBase.Business
{
    /// <summary>
    /// Interfaz para el manejo de usuarios
    /// </summary>
    public interface IUsuarios
    {
        /// <summary>
        /// Metodo para autenticar un usuario en el sistema
        /// </summary>
        /// <param name="usuario">usuario que se va a autenticar</param>
        /// <exception cref="System.ArgumentNullException"/>
        /// <returns></returns>
        UsuarioAutenticado Autenticar(USUARIO usuario);
        
        /// <summary>
        /// Crea un usuario para el sistema
        /// </summary>
        /// <param name="usuario">Usuario a crear</param>
        void CrearUsuario(USUARIO usuario);

        /// <summary>
        /// Obtiene la lista de roles del sistema
        /// </summary>
        /// <returns></returns>
        List<ROL> ObtenerRoles();

        /// <summary>
        /// Busca el nombre del usuario y los roles del mismo
        /// </summary>
        ///<param name="nombreUsuario">Nombre del usuario</param>
        /// <returns></returns>
        USUARIO BuscaUsuarioRol(string nombreUsuario);

        /// <summary>
        /// Asigna los roles al usuario
        /// </summary>
        /// <param name="rolesAsignados">lista de roles a cargar</param>
        void AsignaUsuarioRol(List<ROLUSUARIO> rolesAsignados);

        /// <summary>
        /// Obtiene la lista de usuarios
        /// </summary>
        /// <returns></returns>
        List<UsuarioDetalle> ObtenerListaUsuarios();

        /// <summary>
        /// Busca un usuario por su id
        /// </summary>
        /// <param name="idUsuartio"></param>
        /// <returns></returns>
        USUARIO BuscarUsuarioPorId(Guid idUsuartio);

        /// <summary>
        /// Edita o crea un usuario
        /// </summary>
        /// <param name="usuario">usuario</param>
        void SaveUsuario(USUARIO usuario);

        /// <summary>
        /// Guarda un rol
        /// </summary>
        /// <param name="rol">rol</param>
        void SaveRol(ROL rol);
    }
}
