using System;


namespace DQBase.Entities
{
    public class MovimientoProductos
    {
        public string Laboratorio { get; set; }
        public string NombreProducto { get; set; }
        public string PresentacionProducto { get; set; }
        public string CodigoProductoLaboratorio { get; set; }
        public decimal Precio { get; set; }
        public string FechaLanzamiento { get; set; }
        public Guid IdMovimiento { get; set; }
        public Guid IdHistorico { get; set; }
        public bool EsNuevo { get; set; }
        public MOVIMIENTOSUBPRODUCTO Movimiento { get; set; }
        public HISTORICOPRECIO Historico { get; set; }
    }
}
