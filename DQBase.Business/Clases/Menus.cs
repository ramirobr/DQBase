using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DQBase.Entities;
using DQBase.DataAccessLayer;

namespace DQBase.Business
{
    public partial class BusinessLogic: IMenus
    {
        /// <summary>
        /// Obtiene la lista de menus
        /// </summary>
        /// <returns></returns>
        public List<ListaMenu> GetMenus()
        {
            List<ListaMenu> response = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    response = (from menu1 in context.MENU
                                join menu2 in context.MENU on menu1.IDMENUPADRE equals menu2.IDMENU into leftMenu
                                from menus in leftMenu.DefaultIfEmpty()
                                orderby menu1.NIVELMENU
                                select new
                                {
                                    Menu = menu1.DESCRIPCIONMENU,
                                    IdMenu = menu1.IDMENU,
                                    Padre = menus.DESCRIPCIONMENU,
                                    Ruta = menu1.RUTA
                                }).ToList().Select(menu => new ListaMenu
                                 {
                                     Menu = menu.Menu,
                                     Padre = menu.Padre,
                                     Ruta = menu.Ruta,
                                     IdMenu = menu.IdMenu,
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
        /// Graba o actualiza un menu
        /// </summary>
        /// <param name="menu">menu a grabar</param>
        public void SaveMenu(MENU menu)
        {
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    context.MENU.ApplyChanges(menu);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene todos los menus
        /// </summary>
        /// <returns></returns>
        public List<MENU> GetAllMenus()
        {
            List<MENU> response = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    response = (from menu in context.MENU
                                select menu).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }


        public List<MENU> GetMenusSinPadres()
        {
            List<MENU> response = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    response = (from menu in context.MENU
                                where menu.NIVELMENU == 0
                                select menu).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            response.Insert(0, new MENU { DESCRIPCIONMENU = "", IDMENU = Guid.Empty });
            return response;
        }


        public List<MENU> GetMenusConPadres()
        {
            List<MENU> response = null;
            try
            {
                using (DQBaseContext context = new DQBaseContext(ConnectionString))
                {
                    response = (from menu in context.MENU
                                where menu.NIVELMENU == 1
                                select menu).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            response.Insert(0, new MENU { DESCRIPCIONMENU = "", IDMENU = Guid.Empty });
            return response;
        }


        public List<MENU> GetMenusInRol(Guid idRol)
        {
            List<MENU> response = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    response = (from menu in context.MENU
                                join rolmenu in context.ROLMENU on menu.IDMENU equals rolmenu.IDMENU
                                where rolmenu.IDROL == idRol && menu.NIVELMENU == 1
                                select menu).ToList();  
                }
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }


        public void SaveRolMenu(List<ROLMENU> rolesMenus)
        {
            Guid idRol = rolesMenus[0].IDROL;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    var roles = context.ROLMENU.Where(rol => rol.IDROL == idRol).ToList();
                    if (roles != null)
                    {
                        roles.ForEach(rol => context.ROLMENU.DeleteObject(rol));
                        context.SaveChanges();
                    }
                    rolesMenus.ForEach(rol => context.ROLMENU.AddObject(rol));
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public ROLMENU GetMenuPadre(Guid idMenu, Guid idRol)
        {
            Guid? idPadre = null;
            MENU menu = null;
            ROLMENU result = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    idPadre = context.MENU.FirstOrDefault(data => data.IDMENU == idMenu).IDMENUPADRE;
                    menu = context.MENU.FirstOrDefault(data => data.IDMENUPADRE == idPadre);
                }
                result = new ROLMENU
                {
                    IDMENU = menu.IDMENU,
                    IDROL = idRol,
                    IDROLMENU = Guid.NewGuid()
                }.MarkAsAdded();
            }
            catch (Exception)
            {
                
                throw;
            }
            return result;
        }
    }
}
