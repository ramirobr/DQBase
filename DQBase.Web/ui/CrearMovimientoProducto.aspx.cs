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
    public partial class CrearMovimientoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLaboratorios();
                CargarProductos();
            }
        }

        private void CargarLaboratorios()
        {
            ILaboratorios bdd = new BusinessLogic();
            List<LABORATORIO> laboratorios = bdd.ObtenerLaboratorio();
            ddlLaboratorios.DataSource = laboratorios;
            ddlLaboratorios.DataTextField = "NOMBRELABORATORIO";
            ddlLaboratorios.DataValueField = "IDLABORATORIO";
            ddlLaboratorios.DataBind();
        }

        private void CargarProductos()
        {
            IProductos bdd = new BusinessLogic();
            List<PRODUCTO> productos = bdd.GetProducts();
            ddlProductos.DataSource = productos;
            ddlProductos.DataValueField = "IDPRODUCTO";
            ddlProductos.DataTextField = "NOMBREPRODUCTO";
            ddlProductos.DataBind();
        }


        protected void btnObtenerSubProductos_Click(object sender, EventArgs e)
        {
            IProductos bdd = new BusinessLogic();
            Guid idSubProducto = new Guid(ddlProductos.SelectedValue);
            List<SubProductos> subProductos = bdd.GetSubProductsByProduct(idSubProducto);
            ddlSubProducto.DataSource = subProductos;
            ddlSubProducto.DataValueField = "IdSubProducto";
            ddlSubProducto.DataTextField = "Presentacion";
            ddlSubProducto.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IProductos bdd = new BusinessLogic();
                MOVIMIENTOSUBPRODUCTO movimiento = new MOVIMIENTOSUBPRODUCTO();
                HISTORICOPRECIO historico = new HISTORICOPRECIO();
                movimiento.CODIGOSUBPRODUCTO = Guid.NewGuid();
                movimiento.IDSUBPRODUCTO = new Guid(ddlSubProducto.SelectedValue);
                movimiento.IDLABORATORIO = new Guid(ddlLaboratorios.SelectedValue);
                movimiento.ESNUEVO = chkEsNuevo.Checked;
                movimiento.FECHALANZAMIENTO = (DateTime)wdpFechaLanzamiento.Value;
                movimiento.CODIGOPRODUCTOLABORATORIO = txtCodigo.Text;

                historico.IDHISTORICOPRECIO = Guid.NewGuid();
                historico.CODIGOSUBPRODUCTO = movimiento.CODIGOSUBPRODUCTO;
                historico.FECHAHISTORICOPRECIO = DateTime.Now;
                historico.PRECIO = decimal.Parse(txtPrecio.Text);

                movimiento.HISTORICOPRECIO.Add(historico);

                bdd.SaveMovimientoProducto(movimiento);

                Response.Redirect("~/ui/MovimientoProducto.aspx");


            }
            catch (Exception ex)
            {

                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MovimientoProducto.aspx");
        }


    }
}