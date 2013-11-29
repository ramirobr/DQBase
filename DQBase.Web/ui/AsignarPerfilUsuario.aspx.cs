using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DQBase.Business;
using DQBase.Entities;

namespace DQBase.Web.ui
{
    public partial class AsignarPerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarRoles();
                BuscaUsuario();
            }
            else
            {
                lblError.Visible = false;
            }
        }
        private void CargarRoles()
        {
            try
            {
                IUsuarios negocio = new BusinessLogic();
                List<ROL> roles = negocio.ObtenerRoles();
                rblPerfiles.DataSource = roles;
                rblPerfiles.DataTextField = "DESCRIPCIONROL";
                rblPerfiles.DataValueField = "IDROL";
                rblPerfiles.DataBind();
                Session.Add("Roles", roles);
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            
        }

        protected void BuscaUsuario()
        {
            try
            {
                IUsuarios negocio = new BusinessLogic();
                USUARIO userSesion = Session["userToModify"] as USUARIO;
                USUARIO usuario = negocio.BuscaUsuarioRol(userSesion.NOMBRECOMPLETO);
                lblNombreUsuario.Text = userSesion.NOMBRECOMPLETO;
                List<ROL> roles = Session["Roles"] as List<ROL>;
                ListItemCollection collection = new ListItemCollection();
                ListItem item = null;
                if (usuario == null)
                {
                    collection.Clear();

                    foreach (ListItem valor in rblPerfiles.Items)
                    {
                        item = new ListItem { Text=valor.Text,Value=valor.Value};
                        collection.Add(item);
                    }
                    rblPerfiles.Items.Clear();
                    foreach (ListItem valor in collection)
                        rblPerfiles.Items.Add(valor);
                    throw new Exception("Usuario no encontrado");
                }
                Session.Add("UsuarioBuscado", usuario);
                collection.Clear();
                usuario.ROLUSUARIO.ToList().OrderBy(rol => rol.IDROL).ToList().ForEach(rolSelected =>
                {
                    roles.OrderBy(rol => rol.IDROL).ToList().ForEach(rol =>
                    {
                        if (rol.IDROL == rolSelected.IDROL)
                        {
                            item = new ListItem
                            {
                                Text = rol.DESCRIPCIONROL,
                                Value = rol.IDROL.ToString(),
                                Selected = true
                            };
                        }
                        else
                        {
                            item = new ListItem
                            {
                                Text = rol.DESCRIPCIONROL,
                                Value = rol.IDROL.ToString()
                            };
                        }
                        if(!collection.Contains(item))
                            collection.Add(item);
                    });
                });
                if (collection.Count > 0)
                {
                    rblPerfiles.Items.Clear();
                    foreach (ListItem valor in collection)
                        rblPerfiles.Items.Add(valor);
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message); 
            }
            
        }

        private void MostrarError(string mensaje)
        {
            lblError.Visible = true;
            lblError.Text = mensaje;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<ListItem> selectedItems = rblPerfiles.Items.ToList().Where(item => item.Selected == true).ToList();
                List<ROLUSUARIO> rolesAsignados = new List<ROLUSUARIO>();
                ROLUSUARIO rol = null;
                USUARIO usuarioSeleccionado=Session["UsuarioBuscado"] as USUARIO;
                IUsuarios negocio = new BusinessLogic();
                selectedItems.ForEach(item =>
                {
                    rol = new ROLUSUARIO 
                    { 
                        IDROLUSUARIO=Guid.NewGuid(),
                        IDROL=new Guid(item.Value),
                        IDUSUARIO = usuarioSeleccionado.IDUSUARIO
                    };
                    rolesAsignados.Add(rol);
                });
                negocio.AsignaUsuarioRol(rolesAsignados);
                Response.Redirect("~/ui/MantenimientoUsuarios.aspx");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoUsuarios.aspx");
        }
    }
}