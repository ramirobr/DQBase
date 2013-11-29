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
    public partial class EditarPais : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["paisSeleccionado"] != null)
                    LoadFromSession();
            }
        }

        private void LoadFromSession()
        {
            UBICACIONGEOGRAFICA paisSeleccionado = Session["paisSeleccionado"] as UBICACIONGEOGRAFICA;
            txtNombre.Text = paisSeleccionado.NOMBREUBICACION;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IUbicacion bdd = new BusinessLogic();
                UBICACIONGEOGRAFICA objUbicacion = null;
                if (Session["paisSeleccionado"] != null)
                {
                    objUbicacion = Session["paisSeleccionado"] as UBICACIONGEOGRAFICA;
                    objUbicacion = objUbicacion.MarkAsModified();
                }
                else
                {
                    objUbicacion = new UBICACIONGEOGRAFICA();
                    objUbicacion.IDUBICACION = Guid.NewGuid();
                    objUbicacion = objUbicacion.MarkAsAdded();
                }
                
                objUbicacion.NOMBREUBICACION = txtNombre.Text;
                objUbicacion.CATEGORIAUBICACION = Constants.TIPO_UBICACION_PAIS;
                bdd.SaveUbicacion(objUbicacion);
                Response.Redirect("~/ui/MantenimientoUbicacion.aspx");
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoUbicacion.aspx");
        }
    }
}