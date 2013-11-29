using System;

namespace DQBase.Entities
{
    public class SubProductos
    {
        public int Orden { get; set; }
        public Guid IdProducto { get; set; }
        public Guid IdSubProducto { get; set; }
        public string GrupoTerapeutico { get; set; }
        public string Aplicacion {get; set;}
        public string Forma { get; set; }
        public string TipoMercado { get; set; }
        public string TipoProducto { get; set; }
        public string Presentacion { get; set; }
        public string Concentracion { get; set; }
        public string Unidad { get; set; }
        public string Cantidad { get; set; }
        public string PrincipioActivo { get; set; }
        public string IndicacionesUso { get; set; }
        public bool EsBorrado { get; set; }
    }
}
