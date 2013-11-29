using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DQBase.Entities;
using DQBase.DataAccessLayer;

namespace DQBase.Business
{
    public partial class BusinessLogic: ILaboratorios
    {

        /// <summary>
        /// Obtiene los laboratorios no asociados a una corporacion
        /// </summary>
        /// <returns></returns>
        public List<LABORATORIO> ObtenerLaboratorio()
        {
            List<LABORATORIO> response = new List<LABORATORIO>();
            try
            {
                response.Add(new LABORATORIO());
                using (DQBaseContext ctx =new DQBaseContext(ConnectionString))
                {
                    var query=(from laboratorio in ctx.LABORATORIO
                                where laboratorio.ESBORRADOLABORATORIO==false
                                orderby laboratorio.NOMBRELABORATORIO
                                select laboratorio).ToList();
                    response.AddRange(query);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Obtiene los laboratorios asociados a una corporacion
        /// </summary>
        /// <param name="corporacion"></param>
        /// <returns></returns>
        public List<LABORATORIO> ObtenerLaboratorio(string nombreCorporacion)
        {
            List<LABORATORIO> response = null;
            try
            {
                using (DQBaseContext ctx = new DQBaseContext(ConnectionString))
                {
                    response = (from laboratorio in ctx.LABORATORIO
                                join corporacion in ctx.CORPORACION on laboratorio.IDCORPORACION equals corporacion.IDCORPORACION
                                where laboratorio.ESBORRADOLABORATORIO == false
                                && corporacion.NOMBRECORPORACION == nombreCorporacion
                                select laboratorio).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Obtiene un laboratorio por el nombre
        /// </summary>
        /// <param name="nombreLaboratorio">nombre del laboratorio a buscar</param>
        /// <returns></returns>
        public LABORATORIO ObtenerLaboratorioPorNombre(string nombreLaboratorio)
        {
            LABORATORIO response = null;
            try
            {
                using (DQBaseContext contex=new DQBaseContext(ConnectionString))
                {
                    response=(from laboratorio in contex.LABORATORIO
                                  where laboratorio.NOMBRELABORATORIO==nombreLaboratorio
                                  && laboratorio.ESBORRADOLABORATORIO==false
                                  select laboratorio).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }


        public List<ListaLaboratorio> GetLaboratorios()
        {
            List<ListaLaboratorio> response = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    response = (from lab in context.LABORATORIO
                                join ubicacion in context.UBICACIONGEOGRAFICA on lab.IDUBICACION equals ubicacion.IDUBICACION
                                join corporacion in context.CORPORACION on lab.IDCORPORACION equals corporacion.IDCORPORACION into leftCorp
                                from corp in leftCorp.Where(x => x.ESBORRADOCORPORACION==false).DefaultIfEmpty()
                                where lab.ESBORRADOLABORATORIO == false && ubicacion.ESBORRADOUBICACION == false 
                                select new
                                {
                                    lab.IDLABORATORIO,
                                    ubicacion.NOMBREUBICACION,
                                    NOMBRECORPORACION = string.IsNullOrEmpty(corp.NOMBRECORPORACION) ? string.Empty : corp.NOMBRECORPORACION,
                                    lab.NOMBRELABORATORIO,
                                    lab.ABREVIATURALABORATORIO,
                                    lab.DIRECCION,
                                    lab.DIRECCION2,
                                    lab.TELEFONO,
                                    lab.ORIGEN,
                                    lab.OBSERVACION
                                }).ToList().Select(data => new ListaLaboratorio
                                  {
                                      IdLaboratorio=data.IDLABORATORIO,
                                      Abreviatura=data.ABREVIATURALABORATORIO,
                                      Corporacion=data.NOMBRECORPORACION,
                                      Direccion=data.DIRECCION,
                                      Direccion2=data.DIRECCION2,
                                      Nombre=data.NOMBRELABORATORIO,
                                      Observacion=data.OBSERVACION,
                                      Origen=data.ORIGEN,
                                      Telefono=data.TELEFONO,
                                      Ubicacion=data.NOMBREUBICACION
                                  }).ToList();
                                
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }


        public void SaveLaboratorio(LABORATORIO laboratorio)
        {
            try
            {
                using (DQBaseContext context=new DQBaseContext())
                {
                    context.LABORATORIO.ApplyChanges(laboratorio);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
