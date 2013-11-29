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
    public partial class AsignarPerfilMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMenus();
                CargarSession();
            }
        }

        private void CargarSession()
        {
            IMenus bdd = new BusinessLogic();
            ROL rolSelected = Session["rolSelected"] as ROL;
            lblNombrePerfil.Text = "Rol seleccionado: " + rolSelected.DESCRIPCIONROL;
            List<MENU> menusInRol = bdd.GetMenusInRol(rolSelected.IDROL);
            List<MENU> menus = bdd.GetMenusConPadres();
            ListItemCollection collection = new ListItemCollection();
            ListItem item = null;
            menus.RemoveAt(0);
            menus.ForEach(menu => 
            {
                var menuFound = menusInRol.FirstOrDefault(x => x.IDMENU == menu.IDMENU);
                if (menuFound != null)
                {
                    item = new ListItem
                    {
                        Text = menuFound.DESCRIPCIONMENU,
                        Value = menuFound.IDMENU.ToString(),
                        Selected = true
                    };
                    collection.Add(item);
                }
                else
                {
                    item = new ListItem
                    {
                        Text = menu.DESCRIPCIONMENU,
                        Value = menu.IDMENU.ToString(),
                        Selected = false
                    };
                    collection.Add(item);
                }
            });
            chkMenus.Items.Clear();
            collection.ToList().ForEach(listItem => chkMenus.Items.Add(listItem));
        }


        private void CargarMenus()
        {
            IMenus bdd = new BusinessLogic();
            List<MENU> menus = bdd.GetMenusConPadres();
            menus.RemoveAt(0);
            menus = menus.OrderBy(x => x.DESCRIPCIONMENU).ToList();
            chkMenus.DataSource = menus;
            chkMenus.DataTextField = "DESCRIPCIONMENU";
            chkMenus.DataValueField = "IDMENU";
            chkMenus.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoPerfiles.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ROL rolSelected = Session["rolSelected"] as ROL;
            IMenus bdd = new BusinessLogic();
            ROLMENU rolmenu = null;
            ROLMENU padre = null;
            List<ListItem> menusSelected = chkMenus.Items.ToList().Where(x => x.Selected == true).ToList();
            List<ROLMENU> rolesToAdd = new List<ROLMENU>();
            menusSelected.ForEach(listItem => 
            {
                rolmenu = new ROLMENU
                {
                    IDROLMENU = Guid.NewGuid(),
                    IDROL = rolSelected.IDROL,
                    IDMENU = new Guid(listItem.Value)
                }.MarkAsAdded();
                padre = bdd.GetMenuPadre(rolmenu.IDMENU, rolSelected.IDROL);
                if(!rolesToAdd.Contains(padre))
                    rolesToAdd.Add(padre);
                rolesToAdd.Add(rolmenu);
            });
            bdd.SaveRolMenu(rolesToAdd);
            Response.Redirect("~/ui/MantenimientoPerfiles.aspx");
        }
    }
}