using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DQBase.Entities;

namespace DQBase.Business
{
    /// <summary>
    /// Interfaz que contiene los metodos para manipular los catalogos
    /// </summary>
    public interface ICatalogos
    {
        /// <summary>
        /// Obtiene un catalogo
        /// </summary>
        /// <param name="nombreTabla">nombre de la tabla para filtrar el catalogo</param>
        /// <returns>retorna una lista de catalogos</returns>
        List<CATALOGO> ObtenerCatalogo(Catalogos tabla);
        /// <summary>
        /// Crea un nuevo catalogo
        /// </summary>
        /// <param name="catalogo">Catalogo a insertar</param>
        void CrearCatalogo(CATALOGO catalogo);
        /// <summary>
        /// Actualiza un catalogo
        /// </summary>
        /// <param name="catalogo">Catalogo a modificar</param>
        void ActualizarCatalogo(CATALOGO catalogo);
        /// <summary>
        /// Borra un catalogo
        /// </summary>
        /// <param name="catalogo">Catalogo a borrar</param>
        void BorrarCatalogo(CATALOGO catalogo);
    }
}
