using System;
using System.Collections.Generic;
using DQBase.Entities;

namespace DQBase.Business
{
    public interface IArchivos
    {
        List<ArchivoLeido> LeerHoja(string nombreLaboratorio, string nombreArchivo);
    }
}
