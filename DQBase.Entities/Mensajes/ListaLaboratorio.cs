
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQBase.Entities
{
    public class ListaLaboratorio
    {
        public string Ubicacion { get; set; }
        public string Corporacion { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public string Direccion { get; set; }
        public string Direccion2 { get; set; }
        public string Telefono { get; set; }
        public string Origen { get; set; }
        public string Observacion { get; set; }
        public Guid IdLaboratorio { get; set; }
    }
}
