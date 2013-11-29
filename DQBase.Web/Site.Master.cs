using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DQBase.Entities;
using DQBase.Business;

namespace DQBase.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null && Session["Menu"] == null)
                    Response.Redirect("~/");

                ConsultarCatalogo(Catalogos.APLICACIONPRODUCTO);
                ConsultarCatalogo(Catalogos.FORMAPRODUCTO);
                ConsultarCatalogo(Catalogos.TIPOMERCADO);
                ConsultarCatalogo(Catalogos.TIPOPRODUCTO);

                GenerarMenu();
            }
        }

        /// <summary>
        /// carga los catalogos de la base de datos
        /// </summary>
        private void ConsultarCatalogo(Catalogos catalogo)
        {
            ICatalogos negocio = new BusinessLogic();
            List<CATALOGO> resultado = negocio.ObtenerCatalogo(catalogo);
            string nombrecatalogo="Catalogo" + catalogo.ToString().ToLower();
            Session.Add(nombrecatalogo, resultado);
        }

        /// <summary>
        /// Genera el menu apartir de los resultados de la base de datos
        /// </summary>
        private void GenerarMenu()
        {
            List<MENU> menus = null;
            List<MENU> menusPadres = null;
            List<MENU> submenus = null;
            TreeNode item;
            TreeNode subitem;
            menus = (List<MENU>)Session["Menu"];
            menus = menus.OrderBy(menu => menu.NIVELMENU).ToList();
            menusPadres = menus.Where(menu => menu.NIVELMENU == 0).ToList();
            menusPadres.ForEach(padre =>
            {
                submenus = menus.Where(x => x.IDMENUPADRE == padre.IDMENU).ToList();
                item = new TreeNode
                {
                    Value = padre.DESCRIPCIONMENU,
                    NavigateUrl = padre.RUTA
                };
                TreeViewMenu.Nodes.Add(item);
                submenus.ForEach(submenu =>
                {
                    subitem = new TreeNode
                    {
                        Value = submenu.DESCRIPCIONMENU,
                        NavigateUrl = submenu.RUTA
                    };
                    item.ChildNodes.Add(subitem);
                });
            });
        }
    }
}