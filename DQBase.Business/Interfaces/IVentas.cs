using System;
using System.Collections.Generic;
using DQBase.Entities;

namespace DQBase.Business
{
    public interface IVentas
    {
        /// <summary>
        /// Guarda las ventas
        /// </summary>
        /// <param name="ventas">Lista de ventas a guardas</param>
        void GuardarVentas(List<VENTA> ventas, bool esCorporacion);

        /// <summary>
        /// Obtiene las lista de ciclo ventas por laboratorio
        /// </summary>
        /// <returns></returns>
        List<GetCicloVentasResult> ObtenerCicloVentas(DateTime fechaInicio, DateTime fechaFin);

        /// <summary>
        /// Publica las ventas
        /// </summary>
        /// <param name="fechaCiclo">fecha del ciclo</param>
        void PublicarVentas(DateTime fechaCiclo);

        /// <summary>
        /// Actualiza las ventas
        /// </summary>
        /// <param name="idLaboratorio">id del laboratorio</param>
        /// <param name="fechaVenta">fecha de la venta</param>
        void ActualizarVentas(Guid idLaboratorio, DateTime fechaVenta);

        /// <summary>
        /// Pregunta si las ventas ya fueron aprobadas
        /// </summary>
        /// <param name="fecha">Fecha del ciclo</param>
        /// <returns></returns>
        bool VentasAprobadas(DateTime fecha);

        /// <summary>
        /// Verifica si existen las ventas
        /// </summary>
        /// <param name="fecha">fecha de las ventas</param>
        /// <param name="idLaboratorio">Id del laboratorio</param>
        /// <returns></returns>
        bool ExistenVentas(DateTime fecha, Guid idLaboratorio);


        List<Ciclo> GetCiclos();
        
    }
}
