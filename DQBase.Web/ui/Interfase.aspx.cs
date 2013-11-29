using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DQBase.Entities;
using DQBase.Business;
using DevExpress.Web.ASPxUploadControl;
using System.Drawing;


namespace DQBase.Web.ui
{
    public partial class Interfase : System.Web.UI.Page
    {
        private List<LABORATORIO> _laboratorios;
        private List<CORPORACION> _corporaciones;
        private List<CATALOGO> _meses;

        /// <summary>
        /// se ejecuta cuando la pagina se carga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["fileError"] != null)
                {
                    Exception ex = Session["fileError"] as Exception;
                    Session.Remove("fileError");
                    throw ex;
                }
                if (Session["filename"] != null)
                    btnCargar.Enabled = true;

                if (!IsPostBack)
                {
                    trCorp.Visible = false;
                    trLab.Visible = false;
                    CargarMeses();
                    CargarCorporaciones();
                    CargarLaboratorios();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message, true);
            }

            
        }


        private void CargarMeses()
        {
            ICatalogos bdd = new BusinessLogic();
            IVentas ventas = new BusinessLogic();
            List<Ciclo> ciclos = ventas.GetCiclos();
            Ciclo ultimoCiclo = ciclos.Where(ciclo => ciclo.EsPublicado).Last();
            DateTime ultimaFecha = ultimoCiclo.FechaCiclo;
            int numeroMesAMostrar = ultimaFecha.Month + 1;
            int year = ultimaFecha.Year;
            if (numeroMesAMostrar < 12)
            {
                numeroMesAMostrar = ultimaFecha.Month + 1;
                year = ultimaFecha.Year;
            }
            else if (numeroMesAMostrar == 12)
            {
                numeroMesAMostrar = ultimaFecha.Month;
                year = ultimaFecha.Year;
            }
            else if (numeroMesAMostrar > 12)
            {
                numeroMesAMostrar = 1;
                year = ultimaFecha.Year+1;
            }
            _meses = bdd.ObtenerCatalogo(Catalogos.MESES);
            CATALOGO mesMostrar = _meses.FirstOrDefault(mes => mes.CODIGO == numeroMesAMostrar.ToString());
            List<CATALOGO> fechasBorrar = _meses.Where(mes => (int.Parse(mes.CODIGO) > (numeroMesAMostrar + 1))).ToList();
            _meses.Clear();
            _meses.Add(mesMostrar);
            _meses.ForEach(mes => 
            {
                mes.DESCRIPCIONCATALOGO = mes.DESCRIPCIONCATALOGO + " - " + year.ToString();
            });
            _meses.Insert(0, new CATALOGO { IDCATALAGO=Guid.Empty, DESCRIPCIONCATALOGO=""});
            ddlMesPeriodo.DataSource = _meses;
            ddlMesPeriodo.DataTextField = "DESCRIPCIONCATALOGO";
            ddlMesPeriodo.DataValueField = "CODIGO";
            ddlMesPeriodo.DataBind();
        }

        /// <summary>
        /// Muentra el mesaje de error
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        /// <param name="isError">Es o no error</param>
        private void ShowError(string mensaje,bool isError)
        {
            lblError.ForeColor = isError ? Color.Red : Color.Green;
            lblError.Visible = true;
            lblError.Text = mensaje;
        }

        /// <summary>
        /// obtiene la lista de corporaciones de la base de datos
        /// </summary>
        private void CargarCorporaciones()
        {
            try
            {
                ICorporaciones negocio = new BusinessLogic();
                _corporaciones = negocio.ObtenerCorporaciones();
                Session.Add("CorporacionesTemp", _corporaciones);
                ddlCorporaciones.DataSource = _corporaciones;
                ddlCorporaciones.DataTextField = "NOMBRECORPORACION";
                ddlCorporaciones.DataBind();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message, true);        
            }
        }

        /// <summary>
        /// obtiene la lista de laboratorios de la base de datos
        /// </summary>
        private void CargarLaboratorios()
        {
            try
            {
                ILaboratorios negocio = new BusinessLogic();
                _laboratorios = negocio.ObtenerLaboratorio();
                Session.Add("LaboratoriosTemp", _laboratorios);
                ddlLaboratorios.DataSource = _laboratorios;
                ddlLaboratorios.DataTextField = "NOMBRELABORATORIO";
                ddlLaboratorios.DataBind();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message, true);    
            }
        }

        /// <summary>
        /// se ejecuta cuando cambia una opcion del radio button list
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args</param>
        protected void RadioOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(RadioOptions.SelectedValue)
            {
                case "1":
                    trCorp.Visible = true;
                    trLab.Visible = false;
                    break;
                case "2":
                    trCorp.Visible = false;
                    trLab.Visible = true;
                    break;
            }
            UploadControl.Enabled = true;
        }

        /// <summary>
        /// se ejecuta cuando el boton cargar es precionado
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args</param>
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                BlockControls(false,false);
                btnLimpiar.Enabled = false;
                IArchivos archivo = new BusinessLogic();
                IVentas ventasBdd = new BusinessLogic();
                ISubProductos subproductos = new BusinessLogic();
                ICorporaciones corporaciones = new BusinessLogic();
                string fileName = Session["FileName"].ToString();
                List<ArchivoLeido> resultados = null;
                List<VENTA> ventas = new List<VENTA>();
                USUARIO usuarioConectado = Session["Usuario"] as USUARIO;
                bool existeProductoLab = false;
                string mensajeNoExiste = string.Empty;
                _laboratorios = Session["LaboratoriosTemp"] as List<LABORATORIO>;
                _corporaciones = Session["CorporacionesTemp"] as List<CORPORACION>;
                bool isCorp = false;
                int mes = int.Parse(Session["MesSelected"].ToString());
                int year = int.Parse(Session["AñoSelected"].ToString());
                switch (RadioOptions.SelectedValue)
                {
                    case "1":
                        isCorp = true;
                        resultados = archivo.LeerHoja(ddlCorporaciones.Text, fileName);
                        resultados.ForEach(resultado =>
                        {
                            existeProductoLab = subproductos.ExisteCodigoLab(resultado.CodigoProductoLaboratorio);
                            if (existeProductoLab)
                            {
                                ventas.Add(new VENTA
                                {
                                    CANTIDADVENTA = resultado.CantidadVenta,
                                    FECHA = CalculaFechaPeriodo(mes,year),
                                    NOMBREINSTITUCION = resultado.NombreInstitucion,
                                    IDLABORATORIO = subproductos.ObtenerSubProductoPorCodigoLab(resultado.CodigoProductoLaboratorio).IDLABORATORIO,
                                    IDUBICACION = resultado.IdUbicacion == Guid.Empty ? corporaciones.GetIdUbicacionCorporacion(ddlCorporaciones.SelectedValue) : resultado.IdUbicacion,
                                    TOTALVENTA = resultado.TotalVenta,
                                    ESPUBLICO = checkPublicPrivate.Checked,
                                    IDUSUARIO = usuarioConectado.IDUSUARIO,
                                    CODIGOSUBPRODUCTO = subproductos.ObtenerSubProductoPorCodigoLab(resultado.CodigoProductoLaboratorio).CODIGOSUBPRODUCTO,
                                    IDVENTA = Guid.NewGuid()
                                });
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(mensajeNoExiste))
                                    mensajeNoExiste = string.Format("El codigo {0} no se encuenta en la base de datos, por favor cree el producto", resultado.CodigoProductoLaboratorio) + "|";
                                else
                                    mensajeNoExiste += string.Format("El codigo {0} no se encuenta en la base de datos, por favor cree el producto", resultado.CodigoProductoLaboratorio) + "|";
                            }
                        });
                        break;
                    case "2":

                        resultados = archivo.LeerHoja(ddlLaboratorios.Text, fileName);
                        resultados.ForEach(resultado =>
                        {
                            existeProductoLab = subproductos.ExisteCodigoLab(resultado.CodigoProductoLaboratorio);
                            if (existeProductoLab)
                            {
                                ventas.Add(new VENTA
                                {
                                    CANTIDADVENTA = resultado.CantidadVenta,
                                    FECHA = CalculaFechaPeriodo(mes,year),
                                    NOMBREINSTITUCION = resultado.NombreInstitucion,
                                    IDLABORATORIO = _laboratorios.FirstOrDefault(x => x.NOMBRELABORATORIO == ddlLaboratorios.SelectedValue).IDLABORATORIO,
                                    IDUBICACION = resultado.IdUbicacion == Guid.Empty ? _laboratorios.FirstOrDefault(x => x.NOMBRELABORATORIO == ddlLaboratorios.SelectedValue).IDUBICACION : resultado.IdUbicacion,
                                    TOTALVENTA = resultado.TotalVenta,
                                    ESPUBLICO = checkPublicPrivate.Checked,
                                    IDUSUARIO = usuarioConectado.IDUSUARIO,
                                    CODIGOSUBPRODUCTO = subproductos.ObtenerSubProductoPorCodigoLab(resultado.CodigoProductoLaboratorio).CODIGOSUBPRODUCTO,
                                    IDVENTA = Guid.NewGuid()
                                });
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(mensajeNoExiste))
                                    mensajeNoExiste = string.Format("El codigo {0} no se encuenta en la base de datos, por favor cree el producto", resultado.CodigoProductoLaboratorio) + "|";
                                else
                                    mensajeNoExiste += string.Format("El codigo {0} no se encuenta en la base de datos, por favor cree el producto", resultado.CodigoProductoLaboratorio) + "|";
                            }
                        });
                        break;
                }
                ventasBdd.GuardarVentas(ventas, isCorp);
                if (string.IsNullOrEmpty(mensajeNoExiste))
                {
                    ShowError("Archivo procesado con éxito", false);
                    BlockControls(false, false);
                    btnCargar.Enabled = false;
                }
                else
                {
                    ShowError("El archivo se ha procesado con los siguientes errores:", true);
                    char[] separator = { '|' };
                    List<string> errorList = mensajeNoExiste.Split(separator).Where(x => !string.IsNullOrEmpty(x)).ToList();
                    Errores.DataSource = errorList;
                    Errores.DataBind();
                    Errores.Visible = true;
                }
                btnLimpiar.Enabled = true;
            }
            catch (Exception ex)
            {
                btnLimpiar.Enabled = true;
                ShowError(ex.Message, true);
            }
        }

        /// <summary>
        /// Calcula la fecha de periodo 
        /// </summary>
        /// <returns>Retorna un DateTime</returns>
        private DateTime CalculaFechaPeriodo(int mesSelected, int year)
        {
            DateTime respuesta = DateTime.Now.Date;
            int mes = mesSelected;//int.Parse(ddlMesPeriodo.SelectedValue);
            DateTime fechaMes = new DateTime(year, mes, 1);
            return fechaMes;
        }

        /// <summary>
        /// Se ejecuta cuando el archivo a sido subido con exito
        /// </summary>
        /// <param name="sender">Object sender</param>
        /// <param name="e">Event Arguments</param>
        protected void UploadControl_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            e.CallbackData = SaveFile(e.UploadedFile);//envia el mensaje por callback para mostrar el nombre del archivo en el mensaje javascript
        }

        /// <summary>
        /// Guarda el archivo
        /// </summary>
        /// <param name="uploadedFile">Archivo a guardar</param>
        /// <returns></returns>
        private string SaveFile(UploadedFile uploadedFile)
        {
            string fileName = string.Empty;
            if (uploadedFile.IsValid)
            {
                fileName = string.Format("{0}{1}", Server.MapPath("~/ui/ExcelFiles/"), uploadedFile.FileName);
                if (File.Exists(fileName))
                    File.Delete(fileName);
                uploadedFile.SaveAs(fileName);
                Session.Add("filename", fileName);
            }
            return uploadedFile.FileName;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            trCorp.Visible = false;
            trLab.Visible = false;
            ddlCorporaciones.SelectedValue = "";
            ddlLaboratorios.SelectedValue = "";
            btnCargar.Enabled = false;
            lblError.Text = "";
            lblError.Visible = false;
            Errores.Items.Clear();
            Errores.Visible = false;
            RadioOptions.Items.ToList().ForEach(item => item.Selected = false);
            BlockControls(true,true);
        }

        private void BlockControls(bool value,bool esLimpiar)
        {
            ddlCorporaciones.Enabled = value;
            ddlLaboratorios.Enabled = value;
            ddlMesPeriodo.Enabled = value;
            //btnCargar.Enabled = value;
            RadioOptions.Enabled = value;
            UploadControl.Enabled = value;
            checkPublicPrivate.Enabled = value;

            if (esLimpiar)
            {
                CargarMeses();
            }
        }

        protected void ddlMesPeriodo_TextChanged(object sender, EventArgs e)
        {
            IVentas bdd = new BusinessLogic();
            ListItem selectedItem = ddlMesPeriodo.SelectedItem;
            if (!string.IsNullOrEmpty(selectedItem.Value))
            {
                int mes = int.Parse(selectedItem.Value);
                int year = int.Parse(selectedItem.Text.Split('-').Where(val => !string.IsNullOrEmpty(val)).ToArray()[1]);
                Session.Add("MesSelected", mes);
                Session.Add("AñoSelected", year);
                if (bdd.VentasAprobadas(CalculaFechaPeriodo(mes,year)))
                {
                    ShowError("El ciclo esta cerrado", true);
                    BlockControls(false,false);
                }
                else
                {
                    lblError.Visible = false;
                }
            }
            
        } 
    }
}
