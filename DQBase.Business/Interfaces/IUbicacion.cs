using System;
using DQBase.Entities;
using System.Collections.Generic;

namespace DQBase.Business
{
    public interface IUbicacion
    {
        /// <summary>
        /// Obtiene las ciudades
        /// </summary>
        /// <returns></returns>
        List<UBICACIONGEOGRAFICA> GetCiudades();
        
        /// <summary>
        /// Obtiene las regiones
        /// </summary>
        /// <returns></returns>
        List<UBICACIONGEOGRAFICA> GetRegiones();
        
        /// <summary>
        /// Obtiene las regiones
        /// </summary>
        /// <returns></returns>
        List<UBICACIONGEOGRAFICA> GetPaises();

        /// <summary>
        /// Inserta o edita una ubicacion
        /// </summary>
        /// <param name="ubicacion">Ubicacion geografica</param>
        void SaveUbicacion(UBICACIONGEOGRAFICA ubicacion);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Ubicacion> GetUbicacionRegiones();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Ubicacion> GetUbicacionCiudades();

    }
}
