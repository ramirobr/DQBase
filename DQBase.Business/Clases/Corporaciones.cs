using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DQBase.Entities;
using DQBase.DataAccessLayer;

namespace DQBase.Business
{
    public partial class BusinessLogic: ICorporaciones
    {
        /// <summary>
        /// Obtiene la lista de corporaciones
        /// </summary>
        /// <returns>retorna una lista</returns>
        public List<CORPORACION> ObtenerCorporaciones()
        {
            List<CORPORACION> response = null;
            try
            {
                using (DQBaseContext ctx =new DQBaseContext(ConnectionString))
                {
                    response = (from corporacion in ctx.CORPORACION
                                where corporacion.ESBORRADOCORPORACION == false
                                select corporacion).ToList();
                    if (response != null)
                        response.Insert(0, new CORPORACION 
                        { 
                            IDCORPORACION=Guid.Empty,
                            NOMBRECORPORACION=string.Empty,
                            ABREVIATURACORPORACION=string.Empty
                        });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Crea o edita una corporacion
        /// </summary>
        /// <param name="corporacion">corporacion</param>
        public void SaveCorporacion(CORPORACION corporacion)
        {
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    context.CORPORACION.ApplyChanges(corporacion);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el id de la ubicacion de la corporacion
        /// </summary>
        /// <param name="nombreCorporacion">Nombre de la corporacion</param>
        /// <returns></returns>
        public Guid GetIdUbicacionCorporacion(string nombreCorporacion)
        {
            Guid result = Guid.Empty;
            CORPORACION selectedCorp = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    selectedCorp = context.CORPORACION.FirstOrDefault(x => x.NOMBRECORPORACION == nombreCorporacion);
                    if (selectedCorp != null)
                        result = selectedCorp.IdUbicacion.GetValueOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
