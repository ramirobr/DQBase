using System;
using System.Collections.Generic;
using DQBase.Entities;

namespace DQBase.Business
{
    public interface IMenus
    {
        /// <summary>
        /// Obtiene la lista de menus
        /// </summary>
        /// <returns></returns>
        List<ListaMenu> GetMenus();
        /// <summary>
        /// Graba o actualiza un menu
        /// </summary>
        /// <param name="menu">menu a grabar</param>
        void SaveMenu(MENU menu);

        /// <summary>
        /// Obtiene todos los menus
        /// </summary>
        /// <returns></returns>
        List<MENU> GetAllMenus();

        List<MENU> GetMenusSinPadres();

        List<MENU> GetMenusConPadres();

        List<MENU> GetMenusInRol(Guid idRol);

        void SaveRolMenu(List<ROLMENU> rolesMenus);

        ROLMENU GetMenuPadre(Guid idMenu, Guid idRol);
    }
}
