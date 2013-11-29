using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DQBase.Entities;

namespace DQBase.Business
{
    public interface ICorporaciones
    {
        /// <summary>
        /// Obtiene la lista de corporaciones
        /// </summary>
        /// <returns>retorna una lista</returns>
        List<CORPORACION> ObtenerCorporaciones();

        /// <summary>
        /// Crea o edita una corporacion
        /// </summary>
        /// <param name="corporacion">corporacion</param>
        void SaveCorporacion(CORPORACION corporacion);

        /// <summary>
        /// Obtiene el id de la ubicacion de la corporacion
        /// </summary>
        /// <param name="nombreCorporacion">Nombre de la corporacion</param>
        /// <returns></returns>
        Guid GetIdUbicacionCorporacion(string nombreCorporacion);
    }
}
