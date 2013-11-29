using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQBase.Entities
{
    public class ListaMenu
    {
        public string Menu { get; set; }
        public string Padre { get; set; }
        public string Ruta { get; set; }
        public Guid IdMenu { get; set; }
        public Guid IdPadre { get; set; }
    }
}
