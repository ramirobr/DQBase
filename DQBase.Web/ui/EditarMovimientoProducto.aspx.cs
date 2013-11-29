using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DQBase.Entities;
using DQBase.Business;

namespace DQBase.Web.ui
{
    public partial class EditarMovimientoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["selectMovimiento"]!=null)
                    CargarDesdeSession();
            }

        }

        private void CargarDesdeSession()
        {
            MovimientoProductos selectMovimiento = Session["selectMovimiento"] as MovimientoProductos;
            txtCodigoProducto.Text = selectMovimiento.CodigoProductoLaboratorio;
            txtPrecio.Text = selectMovimiento.Precio.ToString("##########.##");
            chkEsNuevo.Checked = selectMovimiento.EsNuevo;
            wdpFechaLanzamiento.Value = (object)selectMovimiento.FechaLanzamiento;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                IProductos bdd = new BusinessLogic();
                MovimientoProductos selectMovimiento = Session["selectMovimiento"] as MovimientoProductos;
                MOVIMIENTOSUBPRODUCTO moviento = selectMovimiento.Movimiento;
                HISTORICOPRECIO historico = selectMovimiento.Historico;
                moviento.CODIGOPRODUCTOLABORATORIO = txtCodigoProducto.Text;
                moviento.FECHALANZAMIENTO = (DateTime)wdpFechaLanzamiento.Value;
                moviento.ESNUEVO = chkEsNuevo.Checked;
                moviento = moviento.MarkAsModified();
                historico.PRECIO = decimal.Parse(txtPrecio.Text);
                historico = historico.MarkAsModified();
                bdd.SaveHistorico(historico);
                bdd.SaveMovimientoProducto(moviento);
                Response.Redirect("~/ui/MovimientoProducto.aspx");
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MovimientoProducto.aspx");
        }

    }
}