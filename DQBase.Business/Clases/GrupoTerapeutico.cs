using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DQBase.Entities;
using DQBase.DataAccessLayer;

namespace DQBase.Business
{
    public partial class BusinessLogic: IGrupoTerapeutico
    {

        public List<GRUPOTERAPEUTICO> GetGrupos()
        {
            List<GRUPOTERAPEUTICO> response = null;
            try
            {
                using (DQBaseContext contex=new DQBaseContext(ConnectionString))
                {
                    response = (from grupo in contex.GRUPOTERAPEUTICO
                                where grupo.ESBORRADOGRUPOTER == false
                                select grupo).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
