using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DQBase.Entities;
using DQBase.DataAccessLayer;

namespace DQBase.Business
{
    public partial class BusinessLogic:ICatalogos
    {
        /// <summary>
        /// Obtiene un catalogo
        /// </summary>
        /// <param name="nombreTabla">Nombre de la tabla para filtrar el catalogo</param>
        /// <returns>retorna una lista de catalogos</returns>
        public List<CATALOGO> ObtenerCatalogo(Catalogos tabla)
        {
            List<CATALOGO> response = null;
            try
            {
                using (DQBaseContext ctx = new DQBaseContext(ConnectionString))
                {
                    string nombreTabla=tabla.ToString();
                    response = (from catalogo in ctx.CATALOGO
                                where catalogo.TABLA == nombreTabla && catalogo.ESBORRADOCATALOGO == false
                                select catalogo).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Crea un nuevo catalogo
        /// </summary>
        /// <param name="catalogo">Catalogo a insertar</param>
        public void CrearCatalogo(CATALOGO catalogo)
        {
            try
            {
                using (DQBaseContext ctx = new DQBaseContext(ConnectionString))
                {
                    ctx.CATALOGO.ApplyChanges(catalogo);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actualiza un catalogo
        /// </summary>
        /// <param name="catalogo">Catalogo a modificar</param>
        public void ActualizarCatalogo(CATALOGO catalogo)
        {
            try
            {
                using (DQBaseContext ctx = new DQBaseContext(ConnectionString))
                {
                    var dbquery = (from catalog in ctx.CATALOGO
                                   where catalog.IDCATALAGO == catalogo.IDCATALAGO
                                   select catalog).FirstOrDefault();
                    if (dbquery == null) return;
                    dbquery.DESCRIPCIONCATALOGO = catalogo.DESCRIPCIONCATALOGO;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // <summary>
        /// Borra un catalogo
        /// </summary>
        /// <param name="catalogo">Catalogo a borrar</param>
        public void BorrarCatalogo(CATALOGO catalogo)
        {
            try
            {
                using (DQBaseContext ctx = new DQBaseContext(ConnectionString))
                {
                    var dbquery = (from catalog in ctx.CATALOGO
                                   where catalog.IDCATALAGO == catalogo.IDCATALAGO
                                   select catalog).FirstOrDefault();
                    if (dbquery == null) return;
                    dbquery.ESBORRADOCATALOGO = catalogo.ESBORRADOCATALOGO;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}