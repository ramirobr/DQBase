using System;
using System.Collections.Generic;
using System.Linq;
using DQBase.Entities;
using DQBase.DataAccessLayer;

namespace DQBase.Business
{
    public partial class BusinessLogic : IProductos
    {
        /// <summary>
        /// Obtiene la lista de productos
        /// </summary>
        /// <returns></returns>
        public List<PRODUCTO> GetProducts()
        {
            List<PRODUCTO> response = null;
            try
            {
                using (DQBaseContext contex=new DQBaseContext(ConnectionString))
                {
                    response = (from product in contex.PRODUCTO
                                where product.ESBORRADOPRODUCTO == false
                                orderby product.NOMBREPRODUCTO
                                select product).ToList();
                    response.ForEach(producto => producto= producto.MarkAsUnchanged());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Obtiene la lista de subProductos mediante el id del producto
        /// </summary>
        /// <param name="productId">id del producto</param>
        /// <returns></returns>
        public List<SubProductos> GetSubProductsByProduct(Guid productId)
        {
            List<SubProductos> response = null;
            int i = 0;
            try
            {
                List<CATALOGO> aplicacion = ObtenerCatalogo(Catalogos.APLICACIONPRODUCTO);
                List<CATALOGO> formaProducto = ObtenerCatalogo(Catalogos.FORMAPRODUCTO);
                List<CATALOGO> tipoMercado = ObtenerCatalogo(Catalogos.TIPOMERCADO);
                List<CATALOGO> tipoProducto = ObtenerCatalogo(Catalogos.TIPOPRODUCTO);
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    response = (from subProducto in context.SUBPRODUCTO
                                join grupo in context.GRUPOTERAPEUTICO on subProducto.IDGRUPO equals grupo.IDGRUPO
                                where subProducto.ESBORRADOSUBPRODUCTO == false && grupo.ESBORRADOGRUPOTER == false &&
                                subProducto.IDPRODUCTO == productId
                                select new
                                {
                                    grupo.NOMBREGRUPOTER,
                                    subProducto.IDPRODUCTO,
                                    subProducto.IDSUBPRODUCTO,
                                    subProducto.IDAPLICACION,
                                    subProducto.IDFORMAPROD,
                                    subProducto.IDTIPOMERCADO,
                                    subProducto.IDTIPOPRODUCTO,
                                    subProducto.PRESENTACION,
                                    subProducto.CONCENTRACION,
                                    subProducto.UNIDAD,
                                    subProducto.CANTIDAD,
                                    subProducto.PRINCIPIOACTIVO,
                                    subProducto.INDICACIONESDEUSO,
                                    subProducto.ESBORRADOSUBPRODUCTO
                                }).ToList().Select(data => new SubProductos
                                {
                                    Aplicacion = aplicacion.FirstOrDefault(x => x.IDCATALAGO == data.IDAPLICACION).DESCRIPCIONCATALOGO,
                                    TipoMercado = tipoMercado.FirstOrDefault(x => x.IDCATALAGO == data.IDTIPOMERCADO).DESCRIPCIONCATALOGO,
                                    TipoProducto = tipoProducto.FirstOrDefault(x => x.IDCATALAGO  == data.IDTIPOPRODUCTO).DESCRIPCIONCATALOGO,
                                    Forma = formaProducto.FirstOrDefault(x => x.IDCATALAGO == data.IDFORMAPROD).DESCRIPCIONCATALOGO,
                                    Cantidad = data.CANTIDAD.ToString(),
                                    Concentracion = data.CONCENTRACION.ToString(),
                                    GrupoTerapeutico =data.NOMBREGRUPOTER,
                                    Presentacion = data.PRESENTACION,
                                    PrincipioActivo =data.PRINCIPIOACTIVO,
                                    Unidad = data.UNIDAD,
                                    IdSubProducto=data.IDSUBPRODUCTO,
                                    IdProducto=data.IDPRODUCTO,
                                    IndicacionesUso=data.INDICACIONESDEUSO,
                                    EsBorrado=data.ESBORRADOSUBPRODUCTO,
                                    Orden=i++
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
        /// Almacena o edita un produto
        /// </summary>
        /// <param name="producto">Producto</param>
        public void SaveProducto(PRODUCTO producto)
        {
            try
            {
                using (DQBaseContext context =new DQBaseContext(ConnectionString))
                {
                    context.PRODUCTO.ApplyChanges(producto);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene los movimientos del producto
        /// </summary>
        /// <returns></returns>
        public List<MovimientoProductos> GetMovimientoProductos()
        {
            List<MovimientoProductos> response = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    response = (from mov in context.MOVIMIENTOSUBPRODUCTO
                                join sub in context.SUBPRODUCTO on mov.IDSUBPRODUCTO equals sub.IDSUBPRODUCTO
                                join lab in context.LABORATORIO on mov.IDLABORATORIO equals lab.IDLABORATORIO
                                join prod in context.PRODUCTO on sub.IDPRODUCTO equals prod.IDPRODUCTO
                                join his in context.HISTORICOPRECIO on mov.CODIGOSUBPRODUCTO equals his.CODIGOSUBPRODUCTO
                                where sub.ESBORRADOSUBPRODUCTO == false &&
                                lab.ESBORRADOLABORATORIO == false &&
                                prod.ESBORRADOPRODUCTO == false
                                orderby lab.NOMBRELABORATORIO
                                select new
                                {
                                    lab.NOMBRELABORATORIO,
                                    prod.NOMBREPRODUCTO,
                                    sub.PRESENTACION,
                                    mov.CODIGOPRODUCTOLABORATORIO,
                                    his.PRECIO,
                                    mov.FECHALANZAMIENTO,
                                    mov.CODIGOSUBPRODUCTO,
                                    his.IDHISTORICOPRECIO,
                                    mov.ESNUEVO,
                                    his,
                                    mov
                                }).ToList().Select(data => new MovimientoProductos
                                {
                                    CodigoProductoLaboratorio = data.CODIGOPRODUCTOLABORATORIO,
                                    FechaLanzamiento = string.Format("{0:dd/MM/yyyy}", data.FECHALANZAMIENTO),
                                    Laboratorio = data.NOMBRELABORATORIO,
                                    NombreProducto = data.NOMBREPRODUCTO,
                                    Precio = data.PRECIO,
                                    PresentacionProducto = data.PRESENTACION,
                                    IdHistorico = data.IDHISTORICOPRECIO,
                                    IdMovimiento = data.CODIGOSUBPRODUCTO,
                                    EsNuevo = data.ESNUEVO,
                                    Movimiento=data.mov,
                                    Historico=data.his
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
        /// Guarda la informacion del movimiento producto
        /// </summary>
        /// <param name="movimiento">movimiento</param>
        public void SaveMovimientoProducto(MOVIMIENTOSUBPRODUCTO movimiento)
        {
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    context.MOVIMIENTOSUBPRODUCTO.ApplyChanges(movimiento);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Edita historico precios
        /// </summary>
        /// <param name="historico">historico</param>
        public void SaveHistorico(HISTORICOPRECIO historico)
        {
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    context.HISTORICOPRECIO.ApplyChanges(historico);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
