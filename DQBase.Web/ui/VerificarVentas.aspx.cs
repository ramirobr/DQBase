using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DQBase.Entities;
using DQBase.Business;
using System.Drawing;

namespace DQBase.Web.ui
{
    public partial class VerificarVentas : System.Web.UI.Page
    {
        private List<CATALOGO> _meses;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnPublicar.Attributes["Onclick"] = "return ConfirmPublish();";
                CargarLaboratorios();
                CargarMeses();
            }
            lblError.Visible = false;
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
                year = ultimaFecha.Year + 1;
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
            _meses.Insert(0, new CATALOGO { IDCATALAGO = Guid.Empty, DESCRIPCIONCATALOGO = "" });
            ddlPeriodo.DataSource = _meses;
            ddlPeriodo.DataTextField = "DESCRIPCIONCATALOGO";
            ddlPeriodo.DataValueField = "CODIGO";
            ddlPeriodo.DataBind();
        }

        private void CargarLaboratorios()
        {
            ILaboratorios bdd = new BusinessLogic();
            List<LABORATORIO> laboratorios = bdd.ObtenerLaboratorio();
            Session.Add("laboratorios", laboratorios);
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid(false);
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            
        }

        private void BindGrid(bool loadFromSession)
        {
            try
            {
                List<GetCicloVentasResult> ciclos = null;
                if (loadFromSession)
                {
                    ciclos = Session["ciclos"] as List<GetCicloVentasResult>;
                }
                else
                {
                    IVentas bdd = new BusinessLogic();
                    DateTime fechaInicio;
                    DateTime fechaFin;
                    ListItem selectedItem;
                    int mes = 0;
                    int year = 0;
                    if (!string.IsNullOrEmpty(ddlPeriodo.SelectedValue))
                    {
                        selectedItem = ddlPeriodo.SelectedItem;
                        mes = int.Parse(selectedItem.Value);
                        year = int.Parse(selectedItem.Text.Split('-').Where(val => !string.IsNullOrEmpty(val)).ToArray()[1]);
                    }
                    else
                        throw new Exception("Seleccione un mes");
                    FechasDelMes(mes, year, out fechaInicio, out fechaFin);
                    ciclos = bdd.ObtenerCicloVentas(fechaInicio, fechaFin);
                    Session.Add("ciclos", ciclos);
                }
                GridCiclos.DataSource = ciclos;
                GridCiclos.DataBind();

                if (ciclos == null || ciclos.Count ==0)
                {
                    lblError.Visible = true;
                    lblError.Text = "No existen ventas subidas";
                    lblError.ForeColor = Color.Green;
                    return;
                }
                btnPublicar.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            
        }

        private void FechasDelMes(int mes,int year, out DateTime fechaInicio, out DateTime fechaFin)
        {
            fechaInicio = new DateTime(year, mes, 1).Date;
            fechaFin = new DateTime(year, mes, DateTime.DaysInMonth(DateTime.Now.Year, mes)).Date;
            Session.Add("fechaInicio", fechaInicio);
        }

        protected void GridCiclos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridCiclos.PageIndex = e.NewPageIndex;
            BindGrid(true);
        }

        protected void btnPublicar_Click(object sender, EventArgs e)
        {
            try
            {
                List<LABORATORIO> laboratorios = Session["laboratorios"] as List<LABORATORIO>;
                Guid idLaboratorio = Guid.Empty;
                DateTime fechaInicio;
                IVentas bdd = new BusinessLogic();
                CheckBox chkPublicar = null;
                fechaInicio = (DateTime)Session["fechaInicio"];
                bdd.PublicarVentas(fechaInicio);
                GridCiclos.Rows.ToList().ForEach(row =>
                {
                    chkPublicar = row.FindControl("chkPublicar") as CheckBox;
                    if (chkPublicar.Checked)
                    {
                        idLaboratorio = laboratorios.FirstOrDefault(lab => lab.NOMBRELABORATORIO == row.Cells[1].Text).IDLABORATORIO;
                        //if (fechaFin.Month != DateTime.Now.Month - 1) throw new Exception("Solo se puede publicar las ventas del ciclo actual");
                        bdd.ActualizarVentas(idLaboratorio, fechaInicio);
                    }
                });
                GridCiclos.DataSource = null;
                GridCiclos.DataBind();
                Response.Redirect("~/ui/VerificarVentas.aspx");
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            
        }

        
    }
}