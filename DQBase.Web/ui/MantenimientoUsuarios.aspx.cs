using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DQBase.Entities;
using DQBase.Business;
using System.Reflection;

namespace DQBase.Web.ui
{
    public partial class MantenimientoUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(false);
                LlenarComboPropiedades();
            }
        }

        public void BindGrid(bool loadFromSession)
        {
            try
            {
                List<UsuarioDetalle> usuarios = null;
                if (loadFromSession)
                {
                    usuarios = Session["listaUsuarios"] as List<UsuarioDetalle>;
                }
                else
                {
                    IUsuarios bdd = new BusinessLogic();
                    usuarios = bdd.ObtenerListaUsuarios();
                    Session.Add("listaUsuarios", usuarios);
                }
                GridUsuarios.DataSource = usuarios;
                GridUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
            
        }

        protected void GridUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridUsuarios.PageIndex = e.NewPageIndex;
            BindGrid(true);
        }

        private void MostrarError(Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }

        private void LlenarComboPropiedades()
        {
            UsuarioDetalle obj = new UsuarioDetalle();
            List<PropertyInfo> properties = null;
            properties = obj.GetType().GetProperties().ToList().Where(x => x.PropertyType.FullName == "System.String").ToList();
            ddlPropiedades.DataSource = properties;
            ddlPropiedades.DataTextField = "Name";
            ddlPropiedades.DataValueField = "Name";
            ddlPropiedades.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/CrearUsuario.aspx");
        }

        protected void btnBuscas_Click(object sender, EventArgs e)
        {
            List<UsuarioDetalle> usuarios = Session["listaUsuarios"] as List<UsuarioDetalle>;
            List<UsuarioDetalle> filterList = null;
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                filterList = usuarios.Where(x => x.GetPropertyValue<string>(ddlPropiedades.SelectedValue).Contains(txtBuscar.Text)).ToList();
                GridUsuarios.DataSource = filterList;
                GridUsuarios.DataBind();
            }
            txtBuscar.Text = string.Empty;

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            List<UsuarioDetalle> usuarios = Session["listaUsuarios"] as List<UsuarioDetalle>;
            CheckBox chkBorrar=null;
            IUsuarios bdd = new BusinessLogic();
            USUARIO userToModify = null;
            UsuarioDetalle selectedUser = null;
            GridUsuarios.Rows.ToList().ForEach(row => 
            {
                chkBorrar = (CheckBox)row.FindControl("chkBorrar");
                if (chkBorrar.Checked)
                {
                    selectedUser = usuarios.FirstOrDefault(x => x.NombreUsuario == row.Cells[6].Text);
                    userToModify = bdd.BuscarUsuarioPorId(selectedUser.IdUsuario);
                    if (userToModify != null)
                    {
                        userToModify.ESBORRADOUSUARIO = true;
                        bdd.SaveUsuario(userToModify);
                    }
                }
            });
            Response.Redirect("MantenimientoUsuarios.aspx");
        }

        protected void GridUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List<UsuarioDetalle> usuarios = Session["listaUsuarios"] as List<UsuarioDetalle>;
            USUARIO userToModify = null;
            UsuarioDetalle selectedUser = null;
            GridViewRow row = null;
            IUsuarios bdd = new BusinessLogic();
            int index = 0;
            switch (e.CommandName)
            {
                case Constants.COMMAND_EDITAR:
                    index = int.Parse(e.CommandArgument.ToString());
                    row = GridUsuarios.Rows[index];
                    selectedUser = usuarios.FirstOrDefault(x => x.NombreUsuario == row.Cells[6].Text);
                    userToModify = bdd.BuscarUsuarioPorId(selectedUser.IdUsuario);
                    Session.Add("userToModify", userToModify);
                    Response.Redirect("~/ui/EditarUsuario.aspx");
                    break;
                case Constants.COMMAND_CAMBIACLAVE:
                    index = int.Parse(e.CommandArgument.ToString());
                    row = GridUsuarios.Rows[index];
                    selectedUser = usuarios.FirstOrDefault(x => x.NombreUsuario == row.Cells[6].Text);
                    userToModify = bdd.BuscarUsuarioPorId(selectedUser.IdUsuario);
                    Session.Add("userToModify", userToModify);
                    Response.Redirect("~/ui/CambiarClave.aspx");
                    break;
                case Constants.COMMAND_ASIGNAR_PERFIL:
                    index = int.Parse(e.CommandArgument.ToString());
                    row = GridUsuarios.Rows[index];
                    selectedUser = usuarios.FirstOrDefault(x => x.NombreUsuario == row.Cells[6].Text);
                    userToModify = bdd.BuscarUsuarioPorId(selectedUser.IdUsuario);
                    Session.Add("userToModify", userToModify);
                    Response.Redirect("~/ui/AsignarPerfilUsuario.aspx");
                    break;
            }
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            BindGrid(true);
        }
    }
}