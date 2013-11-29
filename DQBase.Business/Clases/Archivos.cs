using System;
using System.Linq;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;
using DQBase.Entities;

namespace DQBase.Business
{
    public partial class BusinessLogic: IArchivos
    {
        public List<ArchivoLeido> LeerHoja(string nombreLaboratorio, string nombreArchivo)
        {
            List<ArchivoLeido> response = null;
            DataSet ds = new DataSet();
            string connectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;" + ("Data Source=" + (nombreArchivo + ";Extended Properties=\"Excel 12.0;HDR=YES\"")));
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    OleDbCommand cmd = new OleDbCommand();
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from [" + nombreLaboratorio + "$]";
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
                response = (from info in ds.Tables[0].AsEnumerable()
                            select new ArchivoLeido
                            {
                                CodigoProductoLaboratorio = info.Field<object>("CODIGOPRODUCTOLABORATORIO").ToString(),
                                CantidadVenta = (short)info.Field<double>("CANTIDADVENTA"),
                                TotalVenta = (decimal)info.Field<double>("TOTALVENTA"),
                                IdUbicacion = string.IsNullOrEmpty(info.Field<string>("IDUBICACION")) ? Guid.Empty : new Guid(info.Field<string>("IDUBICACION")),
                                NombreInstitucion = info.Field<string>("NOMBREINSTITUCION")
                            }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;   
        }
    }
}
