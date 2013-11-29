using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQBase.Entities
{
    public class UsuarioDetalle
    {
        public string Laboratorio { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaCaducidad { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
