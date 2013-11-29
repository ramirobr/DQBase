using System;
using System.Collections.Generic;
using System.Linq;
using DQBase.Entities;
using DQBase.DataAccessLayer;

namespace DQBase.Business
{
    public partial class BusinessLogic: IUbicacion
    {

        /// <summary>
        /// Obtiene las ciudades
        /// </summary>
        /// <returns></returns>
        public List<UBICACIONGEOGRAFICA> GetCiudades()
        {
            List<UBICACIONGEOGRAFICA> response = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    response = (from ubicacion in context.UBICACIONGEOGRAFICA
                                where ubicacion.ESBORRADOUBICACION == false && ubicacion.CATEGORIAUBICACION == Constants.TIPO_UBICACION_CIUDAD
                                select ubicacion).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Obtiene las regiones
        /// </summary>
        /// <returns></returns>
        public List<UBICACIONGEOGRAFICA> GetRegiones()
        {
            List<UBICACIONGEOGRAFICA> response = null;
            try
            {
                using (DQBaseContext context = new DQBaseContext(ConnectionString))
                {
                    response = (from ubicacion in context.UBICACIONGEOGRAFICA
                                where ubicacion.ESBORRADOUBICACION == false && ubicacion.CATEGORIAUBICACION == Constants.TIPO_UBICACION_REGION
                                select ubicacion).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Obtiene las regiones
        /// </summary>
        /// <returns></returns>
        public List<UBICACIONGEOGRAFICA> GetPaises()
        {
            List<UBICACIONGEOGRAFICA> response = null;
            try
            {
                using (DQBaseContext context = new DQBaseContext(ConnectionString))
                {
                    response = (from ubicacion in context.UBICACIONGEOGRAFICA
                                where ubicacion.ESBORRADOUBICACION == false && ubicacion.CATEGORIAUBICACION == Constants.TIPO_UBICACION_PAIS
                                orderby ubicacion.NOMBREUBICACION
                                select ubicacion).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Inserta o edita una ubicacion
        /// </summary>
        /// <param name="ubicacion">Ubicacion geografica</param>
        public void SaveUbicacion(UBICACIONGEOGRAFICA ubicacion)
        {
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    context.UBICACIONGEOGRAFICA.ApplyChanges(ubicacion);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Ubicacion> GetUbicacionRegiones()
        {
            List<Ubicacion> response = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    response = (from ubicacion in context.UBICACIONGEOGRAFICA
                                join ubicacionpais in context.UBICACIONGEOGRAFICA on ubicacion.IDPADRE equals ubicacionpais.IDUBICACION into left
                                from pais in left.Where(x => x.ESBORRADOUBICACION == false)
                                where ubicacion.ESBORRADOUBICACION == false && ubicacion.CATEGORIAUBICACION == Constants.TIPO_UBICACION_REGION
                                && ubicacion.IDPADRE!=null
                                orderby ubicacion.NOMBREUBICACION
                                select new
                                {
                                    IdRegion = ubicacion.IDUBICACION,
                                    NombreRegion = ubicacion.NOMBREUBICACION,
                                    Pais = pais.NOMBREUBICACION
                                }).ToList().Select(data => new Ubicacion
                                   {
                                       IdUbicacion = data.IdRegion,
                                       Nombre = data.NombreRegion,
                                       Pais = data.Pais
                                   }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }


        public List<Ubicacion> GetUbicacionCiudades()
        {
            List<Ubicacion> response = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    response = (from ubicacion in context.UBICACIONGEOGRAFICA
                                join ubicacionregion in context.UBICACIONGEOGRAFICA on ubicacion.IDPADRE equals ubicacionregion.IDUBICACION into left
                                from region in left.Where(x => x.ESBORRADOUBICACION == false)
                                where ubicacion.ESBORRADOUBICACION == false && ubicacion.CATEGORIAUBICACION == Constants.TIPO_UBICACION_CIUDAD
                                && ubicacion.IDPADRE != null
                                orderby ubicacion.NOMBREUBICACION
                                select new
                                {
                                    IdRegion = ubicacion.IDUBICACION,
                                    NombreRegion = ubicacion.NOMBREUBICACION,
                                    Region = region.NOMBREUBICACION
                                }).ToList().Select(data => new Ubicacion
                                {
                                    IdUbicacion = data.IdRegion,
                                    Nombre = data.NombreRegion,
                                    Region = data.Region
                                }).ToList();
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
