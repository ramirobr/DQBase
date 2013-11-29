using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DQBase.Business;
using DQBase.Entities;

namespace DQBase.Web.ui
{
    public partial class EditarLaboratorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarUbicacion();
                CargarCorporacion();
                if (Session["selectedLab"] != null)
                    LeerSession();
            }
        }

        private void LeerSession()
        {
            ListaLaboratorio laboratorio = Session["selectedLab"] as ListaLaboratorio;
            List<CORPORACION> corporaciones = Session["corporaciones"] as List<CORPORACION>;
            List<UBICACIONGEOGRAFICA> ciudades = Session["ciudades"] as List<UBICACIONGEOGRAFICA>;
            CORPORACION corpSelected = null;
            txtDireccion1.Text = laboratorio.Direccion;
            txtDireccion2.Text = laboratorio.Direccion2;
            txtNombre.Text = laboratorio.Nombre;
            txtObservacion.Text = laboratorio.Observacion;
            txtAbreviatura.Text = laboratorio.Abreviatura;
            ddlOrigen.Text = laboratorio.Origen;
            txtTelefono.Text = laboratorio.Telefono;
            corpSelected=corporaciones.FirstOrDefault(x => x.NOMBRECORPORACION==laboratorio.Corporacion);
            ddlCorporacion.SelectedValue = corpSelected != null ? corpSelected.IDCORPORACION.ToString() : Guid.Empty.ToString();
            ddlUbicacion.SelectedValue = ciudades.FirstOrDefault(x => x.NOMBREUBICACION == laboratorio.Ubicacion).IDUBICACION.ToString();
        }

        /// <summary>
        /// Carga las ubicaciones
        /// </summary>
        private void CargarUbicacion()
        {
            IUbicacion bdd = new BusinessLogic();
            List<UBICACIONGEOGRAFICA> ciudades = bdd.GetCiudades();
            ddlUbicacion.DataSource = ciudades;
            ddlUbicacion.DataTextField = "NOMBREUBICACION";
            ddlUbicacion.DataValueField = "IDUBICACION";
            ddlUbicacion.DataBind();
            Session.Add("ciudades", ciudades);
        }

        /// <summary>
        /// Carga las corporaciones
        /// </summary>
        private void CargarCorporacion()
        {
            ICorporaciones bdd = new BusinessLogic();
            List<CORPORACION> corporaciones = bdd.ObtenerCorporaciones();
            ddlCorporacion.DataSource = corporaciones;
            ddlCorporacion.DataTextField = "NOMBRECORPORACION";
            ddlCorporacion.DataValueField = "IDCORPORACION";
            ddlCorporacion.DataBind();
            Session.Add("corporaciones", corporaciones);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            LABORATORIO laboratorio = new LABORATORIO();
            ILaboratorios bdd = new BusinessLogic();
            ListaLaboratorio selectedLab = Session["selectedLab"] as ListaLaboratorio;
            if (Session["selectedLab"] != null)
            {
                laboratorio.IDLABORATORIO = selectedLab.IdLaboratorio;
                laboratorio = laboratorio.MarkAsModified();
            }
            else
            {
                laboratorio.IDLABORATORIO = Guid.NewGuid();
                laboratorio = laboratorio.MarkAsAdded();
            }

            Guid idCorporacion = new Guid(ddlCorporacion.SelectedValue);
            if (idCorporacion == Guid.Empty)
                laboratorio.IDCORPORACION = null;
            else
                laboratorio.IDCORPORACION = idCorporacion;

            laboratorio.IDUBICACION = new Guid(ddlUbicacion.SelectedValue);
            laboratorio.DIRECCION = txtDireccion1.Text;
            laboratorio.DIRECCION2 = txtDireccion2.Text;
            laboratorio.NOMBRELABORATORIO = txtNombre.Text;
            laboratorio.OBSERVACION = txtObservacion.Text;
            laboratorio.ORIGEN = ddlOrigen.Text;
            laboratorio.TELEFONO = txtTelefono.Text;
            laboratorio.ABREVIATURALABORATORIO = txtAbreviatura.Text;
            bdd.SaveLaboratorio(laboratorio);
            Response.Redirect("~/ui/MantenimientoCorpLab.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoCorpLab.aspx");
        }


    }
}