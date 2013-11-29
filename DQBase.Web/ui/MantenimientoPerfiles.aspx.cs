using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DQBase.Entities;
using DQBase.Business;

namespace DQBase.Web.ui
{
    public partial class MantenimientoPerfiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarRoles(false);
        }

        private void CargarRoles(bool loadFromSession)
        {
            List<ROL> roles = null;
            if (loadFromSession)
            {
                roles = Session["roles"] as List<ROL>;
            }
            else 
            {
                IUsuarios bdd = new BusinessLogic();
                roles = bdd.ObtenerRoles();
                Session.Add("roles", roles);
            }
            GridRoles.DataSource = roles;
            GridRoles.DataBind();
        }

        protected void GridRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridRoles.PageIndex = e.NewPageIndex;
            CargarRoles(true);
        }

        protected void GridRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = null;
            int index = 0;
            List<ROL> roles = Session["roles"] as List<ROL>;
            ROL rolSelected = null;
            switch (e.CommandName)
	        {
		        case Constants.COMMAND_EDITAR:
                    index = int.Parse(e.CommandArgument.ToString());
                    row = GridRoles.Rows[index];
                    rolSelected = roles.FirstOrDefault(x => x.DESCRIPCIONROL == row.Cells[2].Text);
                    Session.Add("rolSelected", rolSelected);
                    Response.Redirect("~/ui/CearPerfil.aspx");
                    break;
                case Constants.COMMAND_ASIGNAR_MENU:
                    index = int.Parse(e.CommandArgument.ToString());
                    row = GridRoles.Rows[index];
                    rolSelected = roles.FirstOrDefault(x => x.DESCRIPCIONROL == row.Cells[2].Text);
                    Session.Add("rolSelected", rolSelected);
                    Response.Redirect("~/ui/AsignarPerfilMenu.aspx");
                    break;
	        }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session.Remove("rolSelected");
            Response.Redirect("~/ui/CearPerfil.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<ROL> roles = Session["roles"] as List<ROL>;
            List<ROL> filterList = null;
            if (string.IsNullOrEmpty(txtBuscar.Text)) return;
            filterList = roles.Where(x => x.DESCRIPCIONROL.Contains(txtBuscar.Text)).ToList();
            GridRoles.DataSource = filterList;
            GridRoles.DataBind();
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            CargarRoles(false);
        }

    }
}