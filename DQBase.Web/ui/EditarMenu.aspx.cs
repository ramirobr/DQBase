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
    public partial class EditarMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarComboMenus();
                if (Session["menuSeleccionado"] != null)
                    LeerSessionMenu();
            }
        }

        private void LeerSessionMenu()
        {
            MENU menuSeleccionado = Session["menuSeleccionado"] as MENU;
            if(menuSeleccionado.IDMENUPADRE!=null)
                ddlPadreMenu.SelectedValue = menuSeleccionado.IDMENUPADRE.Value.ToString();
            txtDescripcion.Text = menuSeleccionado.DESCRIPCIONMENU;
            txtRuta.Text = menuSeleccionado.RUTA;
        }

        private void LlenarComboMenus()
        {
            IMenus bdd = new BusinessLogic();
            List<MENU> menus = bdd.GetMenusSinPadres();
            ddlPadreMenu.DataSource = menus;
            ddlPadreMenu.DataTextField = "DESCRIPCIONMENU";
            ddlPadreMenu.DataValueField = "IDMENU";
            ddlPadreMenu.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MENU menu = null;
            Guid padreSeleccionado = Guid.Empty;
            try
            {
                IMenus bdd = new BusinessLogic();
                if (Session["menuSeleccionado"] != null)
                {
                    menu = Session["menuSeleccionado"] as MENU;
                    menu = menu.MarkAsModified();
                }
                else
                {
                    menu = new MENU();
                    menu.IDMENU = Guid.NewGuid();
                }
                padreSeleccionado = new Guid(ddlPadreMenu.SelectedValue);
                if (padreSeleccionado != Guid.Empty)
                {
                    menu.NIVELMENU = 1;
                    menu.IDMENUPADRE = padreSeleccionado;
                }
                else
                    menu.NIVELMENU = 0;
                menu.RUTA = txtRuta.Text;
                menu.DESCRIPCIONMENU = txtDescripcion.Text;
                bdd.SaveMenu(menu);
                Response.Redirect("~/ui/MantenimientoMenus.aspx");
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoMenus.aspx");
        }
    }
}