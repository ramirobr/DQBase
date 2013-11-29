using System;
using System.Collections.Generic;
using System.Linq;
using DQBase.Entities;

namespace DQBase.Business
{
    public interface IGrupoTerapeutico
    {
        /// <summary>
        /// Obtiene la lista de grupos terapeuticos
        /// </summary>
        /// <returns></returns>
        List<GRUPOTERAPEUTICO> GetGrupos();
        

    }
}
