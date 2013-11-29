using System;
using System.Collections.Generic;
using System.Linq;
using DQBase.Entities;

namespace DQBase.Business
{
    public interface IProductos
    {
        /// <summary>
        /// Obtiene la lista de productos
        /// </summary>
        /// <returns></returns>
        List<PRODUCTO> GetProducts();
        
        /// <summary>
        /// Obtiene la lista de subProductos mediante el id del producto
        /// </summary>
        /// <param name="productId">id del producto</param>
        /// <returns></returns>
        List<SubProductos> GetSubProductsByProduct(Guid productId);

        /// <summary>
        /// Almacena o edita un produto
        /// </summary>
        /// <param name="producto">Producto</param>
        void SaveProducto(PRODUCTO producto);

        /// <summary>
        /// Obtiene los movimientos del producto
        /// </summary>
        /// <returns></returns>
        List<MovimientoProductos> GetMovimientoProductos();

        /// <summary>
        /// Guarda la informacion del movimiento producto
        /// </summary>
        /// <param name="movimiento">movimiento</param>
        void SaveMovimientoProducto(MOVIMIENTOSUBPRODUCTO movimiento);

        /// <summary>
        /// Edita historico precios
        /// </summary>
        /// <param name="historico">historico</param>
        void SaveHistorico(HISTORICOPRECIO historico);

    }
}
