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
    public partial class EditarCorporacion : System.Web.UI.Page
    {
        private CORPORACION objCorp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objCorp = Session["selectedCorp"] as CORPORACION;
                if (objCorp != null)
                {
                    txtAbreviatura.Text = objCorp.ABREVIATURACORPORACION;
                    txtNombre.Text = objCorp.NOMBRECORPORACION;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ICorporaciones bdd = new BusinessLogic();
                objCorp = Session["selectedCorp"] as CORPORACION;
                if (objCorp == null)
                    objCorp = new CORPORACION();
                else
                {
                    objCorp = objCorp.MarkAsModified();
                    Session.Remove("selectedCorp");
                }
                if (string.IsNullOrEmpty(txtNombre.Text)) throw new Exception("Escriba el nombre");
                if (string.IsNullOrEmpty(txtAbreviatura.Text)) throw new Exception("Escriba la abreviatura");
                objCorp.ABREVIATURACORPORACION = txtAbreviatura.Text;
                objCorp.NOMBRECORPORACION = txtNombre.Text;
                bdd.SaveCorporacion(objCorp);
                Response.Redirect("~/ui/MantenimientoCorpLab.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("selectedCorp");
            Response.Redirect("~/ui/MantenimientoCorpLab.aspx");
        }
    }
}