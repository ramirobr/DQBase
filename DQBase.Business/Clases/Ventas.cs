using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using DQBase.Entities;
using DQBase.DataAccessLayer;

namespace DQBase.Business
{
    public partial class BusinessLogic: IVentas
    {
        /// <summary>
        /// Guarda la ventas en la base de datos
        /// </summary>
        /// <param name="ventas">lista de ventas a grabar</param>
        public void GuardarVentas(List<VENTA> ventas, bool esCorporacion)
        {
            try
            {
                Guid idLaboratorio = ventas[0].IDLABORATORIO;
                DateTime fechaVenta = ventas[0].FECHA;
                Ciclo ciclo = null;
                int existeVenta = 0;
                List<Guid> idLabs = null;
                List<VENTA> ventasBorrar = null;
                using (DQBaseContext context = new DQBaseContext(ConnectionString))
                {
                    using (TransactionScope transaction=new TransactionScope())
                    {
                        if (esCorporacion)
                        {
                            idLabs=new List<Guid>(ventas.Select(x => x.IDLABORATORIO));
                            existeVenta = (from venta in context.VENTA
                                           where idLabs.Contains(venta.IDLABORATORIO)
                                           && venta.FECHA == fechaVenta
                                           select venta).Count();
                        }
                        else
                        {
                            existeVenta = (from venta in context.VENTA
                                           where venta.IDLABORATORIO == idLaboratorio
                                           && venta.FECHA == fechaVenta
                                           select venta).Count();
                        }

                        if (existeVenta == 0)
                        {
                            ventas.ForEach(venta =>
                            {
                                context.VENTA.ApplyChanges(venta);
                            });
                            context.SaveChanges();
                            bool existeCiclo = (from cic in context.Ciclo
                                                where cic.FechaCiclo == fechaVenta
                                                select cic).Any();
                            if (!existeCiclo)
                            {
                                ciclo = new Ciclo
                                {
                                    IdCiclo = Guid.NewGuid(),
                                    FechaCiclo = fechaVenta,
                                    EsBorrado=false,
                                };
                                context.Ciclo.ApplyChanges(ciclo);
                                context.SaveChanges();
                            }
                            transaction.Complete();
                        }
                        else
                        {
                            var cicloVenta = context.Ciclo.FirstOrDefault(x => x.FechaCiclo == fechaVenta);
                            if (cicloVenta.EsPublicado) throw new Exception("La ventas no pueden ser publicadas");

                            if (esCorporacion)
                            {
                                idLabs = new List<Guid>(ventas.Select(x => x.IDLABORATORIO));
                                ventasBorrar = (from venta in context.VENTA
                                                where idLabs.Contains(venta.IDLABORATORIO)
                                                && venta.FECHA == fechaVenta
                                                select venta).ToList();
                            }
                            else
                            {
                                ventasBorrar = (from venta in context.VENTA
                                                where venta.IDLABORATORIO == idLaboratorio
                                                && venta.FECHA == fechaVenta
                                                select venta).ToList();
                            }

                            ventasBorrar.ForEach(venta =>
                            {
                                context.VENTA.DeleteObject(venta);
                            });
                            ventas.ForEach(venta =>
                            {
                                context.VENTA.ApplyChanges(venta);
                            });
                            context.SaveChanges();
                            transaction.Complete();
                        }
                   }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Obtiene las lista de ciclo ventas por laboratorio
        /// </summary>
        /// <returns></returns>
        public List<GetCicloVentasResult> ObtenerCicloVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<GetCicloVentasResult> response = null;
            DateTime fechaInicioCicloAnterior;
            DateTime fechaFinCicloAnterior;
            int year=fechaInicio.Year;
            int month=fechaInicio.Month;
            try
            {
                if (month == 1)
                {
                    year -= 1;
                    fechaInicioCicloAnterior = new DateTime(year, 12, 1).Date;
                    fechaFinCicloAnterior = new DateTime(year, 12, 31).Date;
                }
                else
                {
                    fechaInicioCicloAnterior = new DateTime(year, month - 1, 1).Date;
                    fechaFinCicloAnterior = new DateTime(year, month - 1, DateTime.DaysInMonth(year, month - 1)).Date;
                }
                using (DQBaseContext context = new DQBaseContext(ConnectionString))
                {
                    response = context.GetCicloVentas(fechaInicio, fechaFin, fechaInicioCicloAnterior, fechaFinCicloAnterior).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Publica las ventas
        /// </summary>
        /// <param name="fechaCiclo">fecha del ciclo</param>
        public void PublicarVentas(DateTime fechaCiclo)
        {
            Ciclo ciclo = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    ciclo = (from cic in context.Ciclo
                             where cic.EsBorrado == false 
                             && cic.FechaCiclo == fechaCiclo 
                             select cic).FirstOrDefault();

                    if (ciclo == null) throw new Exception("No se pudo publicar las ventas");
                    if (ciclo.FechaPublicacion != null) throw new Exception("Las ventas ya fueron publicadas");
                    ciclo.FechaPublicacion = DateTime.Now.Date;
                    ciclo.EsPublicado = true;
                    context.Ciclo.ApplyChanges(ciclo);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actualiza las ventas
        /// </summary>
        /// <param name="idLaboratorio">id del laboratorio</param>
        /// <param name="fechaVenta">fecha de la venta</param>
        public void ActualizarVentas(Guid idLaboratorio,DateTime fechaVenta)
        {
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    var ventas = (from venta in context.VENTA
                                  where venta.IDLABORATORIO == idLaboratorio && venta.FECHA==fechaVenta
                                  select venta).ToList();

                    ventas.ForEach(venta => 
                    {
                        venta.ESCORRECTO = true;
                        context.VENTA.ApplyChanges(venta);    
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Pregunta si las ventas ya fueron aprobadas
        /// </summary>
        /// <param name="fecha">Fecha del ciclo</param>
        /// <returns></returns>
        public bool VentasAprobadas(DateTime fecha)
        {
            bool respuesta = false;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    respuesta = context.Ciclo.Where(ciclo => ciclo.FechaCiclo == fecha).Any(ciclo => ciclo.EsPublicado == true);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return respuesta;
        }

        /// <summary>
        /// Verifica si existen las ventas
        /// </summary>
        /// <param name="fecha">fecha de las ventas</param>
        /// <param name="idLaboratorio">Id del laboratorio</param>
        /// <returns></returns>
        public bool ExistenVentas(DateTime fecha, Guid idLaboratorio)
        {
            bool respuesta = false;
            try
            {
                using (DQBaseContext context = new DQBaseContext(ConnectionString))
                {
                    respuesta = (from venta in context.VENTA
                                 where venta.FECHA == fecha && venta.IDLABORATORIO == idLaboratorio
                                 select venta).Any();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }


        public List<Ciclo> GetCiclos()
        {
            List<Ciclo> resultado = null;
            try
            {
                using (DQBaseContext context=new DQBaseContext(ConnectionString))
                {
                    resultado = (from ciclo in context.Ciclo
                                 where ciclo.EsBorrado == false
                                 orderby ciclo.FechaCiclo
                                 select ciclo).ToList();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return resultado;
        }
    }
}
