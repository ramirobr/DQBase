using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using DQBase.Entities;

namespace DQBase.Entities
{
    /// <summary>
    /// Clase que retorna el usuario autenticado
    /// </summary>
    [DataContract]
    public class UsuarioAutenticado
    {
        /// <summary>
        /// Usuario conectado
        /// </summary>
        [DataMember]
        public USUARIO Usuario { get; set; }

        /// <summary>
        /// Menu del usuario conectado
        /// </summary>
        [DataMember]
        public List<MENU> Menu { get; set; }
    }
}
