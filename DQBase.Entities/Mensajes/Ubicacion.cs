using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQBase.Entities
{
    public class Ubicacion
    {
        public string Nombre { get; set; }
        public string Region { get; set; }
        public string Pais { get; set; }
        public Guid IdUbicacion { get; set; }
    }
}
