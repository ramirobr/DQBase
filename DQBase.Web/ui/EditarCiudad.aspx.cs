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
    public partial class EditarCiudad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRegiones();
                if (Session["ciudadToUpdate"] != null)
                    CargarDesdeSession();
            }
        }

        private void CargarDesdeSession()
        {
            UBICACIONGEOGRAFICA ciudadToUpdate = Session["ciudadToUpdate"] as UBICACIONGEOGRAFICA;
            ddlRegiones.SelectedValue = ciudadToUpdate.IDPADRE.ToString();
            txtNombre.Text = ciudadToUpdate.NOMBREUBICACION;
        }

        private void CargarRegiones()
        {
            IUbicacion bdd = new BusinessLogic();
            List<UBICACIONGEOGRAFICA> ciudades = bdd.GetRegiones();
            ddlRegiones.DataSource = ciudades;
            ddlRegiones.DataTextField = "NOMBREUBICACION";
            ddlRegiones.DataValueField = "IDUBICACION";
            ddlRegiones.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UBICACIONGEOGRAFICA ciudad = null;
            if (Session["ciudadToUpdate"] != null)
            {
                ciudad = Session["ciudadToUpdate"] as UBICACIONGEOGRAFICA;
                ciudad = ciudad.MarkAsModified();
            }
            else
            {
                ciudad = new UBICACIONGEOGRAFICA();
                ciudad.IDUBICACION = Guid.NewGuid();
            }
            IUbicacion bdd = new BusinessLogic();
            ciudad.IDPADRE = new Guid(ddlRegiones.SelectedValue);
            ciudad.NOMBREUBICACION = txtNombre.Text;
            ciudad.CATEGORIAUBICACION = Constants.TIPO_UBICACION_CIUDAD;
            bdd.SaveUbicacion(ciudad);
            Response.Redirect("~/ui/MantenimientoUbicacion.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoUbicacion.aspx");
        }
    }
}