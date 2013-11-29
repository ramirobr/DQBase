using System;
using System.Collections.Generic;
using System.Linq;
using DQBase.Entities;
using DQBase.DataAccessLayer;


namespace DQBase.Business
{
    public partial class BusinessLogic: ISubProductos
    {
        /// <summary>
        /// Busca un producto por codigo de laboratorio 
        /// </summary>
        /// <param name="codigoLaboratorio">codigo del laboratorio</param>
        /// <returns></returns>
        public MOVIMIENTOSUBPRODUCTO ObtenerSubProductoPorCodigoLab(string codigoLaboratorio)
        {
            MOVIMIENTOSUBPRODUCTO response = null;
            try
            {
                using (DQBaseContext ctx =new DQBaseContext(ConnectionString))
                {
                    response = (from movimiento in ctx.MOVIMIENTOSUBPRODUCTO
                               where movimiento.CODIGOPRODUCTOLABORATORIO == codigoLaboratorio
                               select movimiento).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Añade o Edita un sub producto
        /// </summary>
        /// <param name="subProducto">Sub producto</param>
        public void SaveSubProducto(SUBPRODUCTO subProducto)
        {
            try
            {
                using (DQBaseContext context = new DQBaseContext(ConnectionString))
                {
                    context.SUBPRODUCTO.ApplyChanges(subProducto);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un sun producto por su id
        /// </summary>
        /// <param name="idSubproducto">id del subproducto</param>
        /// <returns></returns>
        public SUBPRODUCTO ObtenerSubProductoById(Guid idSubproducto)
        {
            SUBPRODUCTO response = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    response = (from subp in context.SUBPRODUCTO
                                where subp.IDSUBPRODUCTO == idSubproducto &&
                                subp.ESBORRADOSUBPRODUCTO == false
                                select subp).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Existe o no el codigo del laboratorio almacenado en la bdd
        /// </summary>
        /// <param name="codigoLaboratorio">Codigo del laboratorio</param>
        /// <returns></returns>
        public bool ExisteCodigoLab(string codigoLaboratorio)
        {
            bool response = false;
            try
            {
                using (DQBaseContext ctx = new DQBaseContext(ConnectionString))
                {
                    response = (from movimiento in ctx.MOVIMIENTOSUBPRODUCTO
                                where movimiento.CODIGOPRODUCTOLABORATORIO == codigoLaboratorio
                                select movimiento).Any();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
