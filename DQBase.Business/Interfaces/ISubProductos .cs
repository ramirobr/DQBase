using System;
using DQBase.Entities;

namespace DQBase.Business
{
    public interface ISubProductos
    {
        /// <summary>
        /// Busca un producto por codigo de laboratorio 
        /// </summary>
        /// <param name="codigoLaboratorio">codigo del laboratorio</param>
        /// <returns></returns>
        MOVIMIENTOSUBPRODUCTO ObtenerSubProductoPorCodigoLab(string codigoLaboratorio);

        /// <summary>
        /// Añade o Edita un sub producto
        /// </summary>
        /// <param name="subProducto">Sub producto</param>
        void SaveSubProducto(SUBPRODUCTO subProducto);

        /// <summary>
        /// Obtiene un sun producto por su id
        /// </summary>
        /// <param name="idSubproducto">id del subproducto</param>
        /// <returns></returns>
        SUBPRODUCTO ObtenerSubProductoById(Guid idSubproducto);

        /// <summary>
        /// Existe o no el codigo del laboratorio almacenado en la bdd
        /// </summary>
        /// <param name="codigoLaboratorio">Codigo del laboratorio</param>
        /// <returns></returns>
        bool ExisteCodigoLab(string codigoLaboratorio);
    }
}
