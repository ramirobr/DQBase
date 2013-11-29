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
    public partial class MantenimientoMenus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMenus(false);
                CargarPropiedades();
            }
        }

        private void CargarPropiedades()
        {
            ListaMenu obj = new ListaMenu();
            ddlPropMenu.DataSource = obj.GetType().GetProperties().ToList();
            ddlPropMenu.DataTextField = "Name";
            ddlPropMenu.DataValueField = "Name";
            ddlPropMenu.DataBind();
        }

        private void CargarMenus(bool loadFromSession)
        {
            List<ListaMenu> listamenus = null;
            List<MENU> menus = null;
            if (loadFromSession)
            {
                listamenus = Session["listamenus"] as List<ListaMenu>;
            }
            else
            {
                IMenus bdd = new BusinessLogic();
                listamenus = bdd.GetMenus();
                menus = bdd.GetAllMenus();
                Session.Add("listamenus", listamenus);
                Session.Add("menus", menus);
            }
            gridMenus.DataSource = listamenus;
            gridMenus.DataBind();
        }

        protected void gridMenus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridMenus.PageIndex = e.NewPageIndex;
            CargarMenus(true);
        }

        protected void gridMenus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row;
                int index = 0;
                ListaMenu listaMenuSeleccionado = null;
                MENU menuSeleccionado = null;
                List<ListaMenu> listamenus = Session["listamenus"] as List<ListaMenu>;
                List<MENU> menus = Session["menus"] as List<MENU>;
                if (e.CommandName == Constants.COMMAND_EDITAR)
                {
                    index = int.Parse(e.CommandArgument.ToString());
                    row = gridMenus.Rows[index];
                    listaMenuSeleccionado = listamenus.FirstOrDefault(x => x.Menu == row.Cells[1].Text);
                    menuSeleccionado = menus.FirstOrDefault(x => x.IDMENU == listaMenuSeleccionado.IdMenu);
                    Session.Add("menuSeleccionado", menuSeleccionado);
                    Response.Redirect("~/ui/EditarMenu.aspx");
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<ListaMenu> listamenus = Session["listamenus"] as List<ListaMenu>;
            List<ListaMenu> filterList = null;
            if(string.IsNullOrEmpty(txtBuscar.Text)) return;
            filterList = listamenus.Where(x => x.GetPropertyValue<string>(ddlPropMenu.SelectedValue).Contains(txtBuscar.Text)).ToList();
            gridMenus.DataSource = filterList;
            gridMenus.DataBind();
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            CargarMenus(false);
        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session.Remove("menuSeleccionado");
            Response.Redirect("~/ui/EditarMenu.aspx");
        }

    }
}