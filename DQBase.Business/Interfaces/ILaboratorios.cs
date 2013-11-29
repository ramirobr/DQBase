using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DQBase.Entities;

namespace DQBase.Business
{
    public interface ILaboratorios
    {
        /// <summary>
        /// Obtiene los laboratorios no asociados a una corporacion
        /// </summary>
        /// <returns></returns>
        List<LABORATORIO> ObtenerLaboratorio();

        /// <summary>
        /// Obtiene los laboratorios asociados a una corporacion
        /// </summary>
        /// <param name="corporacion"></param>
        /// <returns></returns>
        List<LABORATORIO> ObtenerLaboratorio(string nombreCorporacion);

        /// <summary>
        /// Obtiene un laboratorio por el nombre
        /// </summary>
        /// <param name="nombreLaboratorio">nombre del laboratorio a buscar</param>
        /// <returns></returns>
        LABORATORIO ObtenerLaboratorioPorNombre(string nombreLaboratorio);

        /// <summary>
        /// Obtiene los laboratorios
        /// </summary>
        /// <returns></returns>
        List<ListaLaboratorio> GetLaboratorios();

        /// <summary>
        /// Guarda o edita un laboratorio
        /// </summary>
        /// <param name="laboratorio"></param>
        void SaveLaboratorio(LABORATORIO laboratorio);
    }
}
