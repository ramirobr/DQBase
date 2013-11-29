using System;

namespace DQBase.Entities
{
    public class ArchivoLeido
    {
        public string CodigoProductoLaboratorio { get; set; }
        public short CantidadVenta { get; set; }
        public decimal TotalVenta { get; set; }
        public Guid IdUbicacion { get; set; }
        public string NombreInstitucion { get; set; }
    }
}
