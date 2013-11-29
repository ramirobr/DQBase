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
    public partial class EditarProducto : System.Web.UI.Page
    {
        private PRODUCTO producto = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    if (Session["selectedProduct"] != null)
                    {
                        producto = Session["selectedProduct"] as PRODUCTO;
                        txtNombreProducto.Text = producto.NOMBREPRODUCTO;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoProducto.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombreProducto.Text))
                    throw new Exception("Escriba el nombre");
                IProductos bdd = new BusinessLogic();
                if (Session["selectedProduct"] == null)
                {
                    producto = new PRODUCTO();
                    producto.IDPRODUCTO = Guid.NewGuid();
                }
                else
                    producto = Session["selectedProduct"] as PRODUCTO;
                producto.NOMBREPRODUCTO = txtNombreProducto.Text;
                bdd.SaveProducto(producto);
                Session.Remove("selectedProduct");
                Response.Redirect("~/ui/MantenimientoProducto.aspx");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void ShowError(string message)
        {
            lblError.Visible = true;
            lblError.Text = message;
        }
    }
}