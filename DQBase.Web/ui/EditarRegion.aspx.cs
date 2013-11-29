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
    public partial class EditarRegion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPaises();
                if (Session["ubicacionToUpdate"] != null)
                    CargarSession();
            }
        }

        private void CargarSession()
        {
            UBICACIONGEOGRAFICA ubicacion = Session["ubicacionToUpdate"] as UBICACIONGEOGRAFICA;
            ddlPais.SelectedValue = ubicacion.IDPADRE.GetValueOrDefault().ToString();
            txtNombre.Text = ubicacion.NOMBREUBICACION;
        }

        private void CargarPaises()
        {
            IUbicacion bdd = new BusinessLogic();
            List<UBICACIONGEOGRAFICA> ubicaciones = bdd.GetPaises();
            ddlPais.DataSource = ubicaciones;
            ddlPais.DataTextField = "NOMBREUBICACION";
            ddlPais.DataValueField = "IDUBICACION";
            ddlPais.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IUbicacion bdd = new BusinessLogic();
            UBICACIONGEOGRAFICA ubicacion = null;
            if (Session["ubicacionToUpdate"] != null)
            {
                ubicacion = Session["ubicacionToUpdate"] as UBICACIONGEOGRAFICA;
                ubicacion=ubicacion.MarkAsModified();
            }
            else
            {
                ubicacion = new UBICACIONGEOGRAFICA();
                ubicacion.IDUBICACION = Guid.NewGuid();
            }
            
            ubicacion.NOMBREUBICACION = txtNombre.Text;
            ubicacion.IDPADRE = new Guid(ddlPais.SelectedValue);
            ubicacion.CATEGORIAUBICACION = Constants.TIPO_UBICACION_REGION;
            bdd.SaveUbicacion(ubicacion);
            Response.Redirect("~/ui/MantenimientoUbicacion.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoUbicacion.aspx");
        }

    }
}