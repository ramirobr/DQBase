using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DQBase.Business;
using DQBase.Entities;
using System.Reflection;

namespace DQBase.Web.ui
{
    public partial class MovimientoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid(false);
                CargarPropiedades();
            }
        }

        private void CargarPropiedades()
        {
            MovimientoProductos obj = new MovimientoProductos();
            List<PropertyInfo> properties = null;
            properties = obj.GetType().GetProperties().ToList().Where(x => x.PropertyType.FullName == "System.String").ToList();
            ddlPropMov.DataSource = properties;
            ddlPropMov.DataTextField = "Name";
            ddlPropMov.DataValueField = "Name";
            ddlPropMov.DataBind();
        }

        private void CargarGrid(bool loadFromSession)
        {
            List<MovimientoProductos> movimientos = null;
            if (loadFromSession)
            {
                movimientos = Session["movimientos"] as List<MovimientoProductos>;
            }
            else
            {
                IProductos bdd = new BusinessLogic();
                movimientos = bdd.GetMovimientoProductos();
                Session.Add("movimientos", movimientos);
            }
            GridMovimientos.DataSource = movimientos;
            GridMovimientos.DataBind();
        }

        protected void GridMovimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridMovimientos.PageIndex = e.NewPageIndex;
            CargarGrid(true); 
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<MovimientoProductos> movimientos = Session["movimientos"] as List<MovimientoProductos>;
            List<MovimientoProductos> filterList = null; 
            if (string.IsNullOrEmpty(txtBuscar.Text)) return;
            filterList = movimientos.Where(x => x.GetPropertyValue<string>(ddlPropMov.SelectedValue).Contains(txtBuscar.Text)).ToList();
            GridMovimientos.DataSource = filterList;
            GridMovimientos.DataBind();
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            CargarGrid(true); 
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/CrearMovimientoProducto.aspx");
        }

        protected void GridMovimientos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = null;
            int index = 0;
            List<MovimientoProductos> movimientos = Session["movimientos"] as List<MovimientoProductos>;
            MovimientoProductos selectMovimiento = null;
            if (e.CommandName == Constants.COMMAND_EDITAR)
            {
                index = int.Parse(e.CommandArgument.ToString());
                row = GridMovimientos.Rows[index];
                selectMovimiento = movimientos.FirstOrDefault(x => x.Laboratorio == row.Cells[1].Text 
                    && x.NombreProducto == row.Cells[2].Text 
                    && x.PresentacionProducto==row.Cells[3].Text
                    && x.CodigoProductoLaboratorio==row.Cells[4].Text
                    && x.FechaLanzamiento==row.Cells[6].Text);
                Session.Add("selectMovimiento", selectMovimiento);
                Response.Redirect("~/ui/EditarMovimientoProducto.aspx");
            }
        }
    }
}