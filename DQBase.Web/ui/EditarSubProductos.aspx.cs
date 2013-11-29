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
    public partial class EditarSubProductos : System.Web.UI.Page
    {
        private List<CATALOGO> aplicacion = null;
        private List<CATALOGO> formaProducto = null;
        private List<CATALOGO> tipoMercado = null;
        private List<CATALOGO> tipoProducto = null;
        private List<GRUPOTERAPEUTICO> grupos = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarGrupoTerapeutico();
                CargarCatalogoAplicacion();
                CargarCatalogoFormaProducto();
                CargarCatalogoTipoMercado();
                CargarCatalogoTipoProducto();
                CargarSesion();
            }
        }

        private void CargarSesion()
        {
            SubProductos subProductoSeleccionado = Session["subProductoSeleccionado"] as SubProductos;
            if (subProductoSeleccionado == null) return;
            ddlAplicacion.SelectedValue = subProductoSeleccionado.Aplicacion;
            ddlForma.SelectedValue = subProductoSeleccionado.Forma;
            ddlGrupoTerapeutico.SelectedValue = subProductoSeleccionado.GrupoTerapeutico;
            ddlTipoMercado.SelectedValue = subProductoSeleccionado.TipoMercado;
            ddlTipoProducto.SelectedValue = subProductoSeleccionado.TipoProducto;
            txtCantidad.Text = subProductoSeleccionado.Cantidad.ToString();
            txtConcentracion.Text = subProductoSeleccionado.Concentracion.ToString();
            txtPresentacion.Text = subProductoSeleccionado.Presentacion;
            txtPrincipio.Text = subProductoSeleccionado.PrincipioActivo;
            txtUnidad.Text = subProductoSeleccionado.Unidad;
            txtIndicaciones.Text = subProductoSeleccionado.IndicacionesUso;
        }

        private void CargarGrupoTerapeutico()
        {
            IGrupoTerapeutico bdd = new BusinessLogic();
            grupos = bdd.GetGrupos();
            ddlGrupoTerapeutico.DataSource = grupos;
            ddlGrupoTerapeutico.DataTextField = "NOMBREGRUPOTER";
            ddlGrupoTerapeutico.DataValueField = "NOMBREGRUPOTER";
            ddlGrupoTerapeutico.DataBind();
        }

        /// <summary>
        /// Carga el catalogo tipo producto
        /// </summary>
        private void CargarCatalogoTipoProducto()
        {
            tipoProducto = Session["Catalogo" + Catalogos.TIPOPRODUCTO.ToString().ToLower()] as List<CATALOGO>;
            ddlTipoProducto.DataSource = tipoProducto;
            ddlTipoProducto.DataTextField = "DESCRIPCIONCATALOGO";
            ddlTipoProducto.DataValueField = "DESCRIPCIONCATALOGO";
            ddlTipoProducto.DataBind();
        }

        /// <summary>
        /// Carga el catalogo tipo mercado
        /// </summary>
        private void CargarCatalogoTipoMercado()
        {
            tipoMercado = Session["Catalogo" + Catalogos.TIPOMERCADO.ToString().ToLower()] as List<CATALOGO>;
            ddlTipoMercado.DataSource = tipoMercado;
            ddlTipoMercado.DataTextField = "DESCRIPCIONCATALOGO";
            ddlTipoMercado.DataValueField = "DESCRIPCIONCATALOGO";
            ddlTipoMercado.DataBind();
        }

        /// <summary>
        /// Carga el catalogo forma producto
        /// </summary>
        private void CargarCatalogoFormaProducto()
        {
            formaProducto = Session["Catalogo" + Catalogos.FORMAPRODUCTO.ToString().ToLower()] as List<CATALOGO>;
            ddlForma.DataSource = formaProducto;
            ddlForma.DataTextField = "DESCRIPCIONCATALOGO";
            ddlForma.DataValueField = "DESCRIPCIONCATALOGO";
            ddlForma.DataBind();
        }

        /// <summary>
        /// Carga el catalogo aplicacion
        /// </summary>
        private void CargarCatalogoAplicacion()
        {
            aplicacion = Session["Catalogo" + Catalogos.APLICACIONPRODUCTO.ToString().ToLower()] as List<CATALOGO>;
            ddlAplicacion.DataSource = aplicacion;
            ddlAplicacion.DataTextField = "DESCRIPCIONCATALOGO";
            ddlAplicacion.DataValueField = "DESCRIPCIONCATALOGO";
            ddlAplicacion.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoProducto.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IGrupoTerapeutico gruposbb = new BusinessLogic();
                grupos = gruposbb.GetGrupos();
                aplicacion = Session["Catalogo" + Catalogos.APLICACIONPRODUCTO.ToString().ToLower()] as List<CATALOGO>;
                formaProducto = Session["Catalogo" + Catalogos.FORMAPRODUCTO.ToString().ToLower()] as List<CATALOGO>;
                tipoMercado = Session["Catalogo" + Catalogos.TIPOMERCADO.ToString().ToLower()] as List<CATALOGO>;
                tipoProducto = Session["Catalogo" + Catalogos.TIPOPRODUCTO.ToString().ToLower()] as List<CATALOGO>;
                SubProductos subProductoSeleccionado = Session["subProductoSeleccionado"] as SubProductos;
                ISubProductos bdd = new BusinessLogic();
                SUBPRODUCTO subProducto = null;
                Guid idProducto = Guid.Empty;
                if (subProductoSeleccionado == null)
                {
                    subProducto = new SUBPRODUCTO();
                    subProducto.IDSUBPRODUCTO = Guid.NewGuid();
                    subProducto = subProducto.MarkAsAdded();
                    PRODUCTO selectedProduct = Session["selectedProduct"] as PRODUCTO;
                    idProducto = selectedProduct.IDPRODUCTO;
                }
                else
                {
                    subProducto = bdd.ObtenerSubProductoById(subProductoSeleccionado.IdSubProducto);
                    subProducto = subProducto.MarkAsModified();
                    idProducto = subProductoSeleccionado.IdProducto;
                }
                subProducto.IDPRODUCTO = idProducto;
                subProducto.IDGRUPO = grupos.FirstOrDefault(x => x.NOMBREGRUPOTER == ddlGrupoTerapeutico.SelectedValue).IDGRUPO;
                subProducto.IDAPLICACION = aplicacion.FirstOrDefault(x => x.DESCRIPCIONCATALOGO == ddlAplicacion.SelectedValue).IDCATALAGO;
                subProducto.IDFORMAPROD = formaProducto.FirstOrDefault(x => x.DESCRIPCIONCATALOGO == ddlForma.SelectedValue).IDCATALAGO;
                subProducto.IDTIPOMERCADO = tipoMercado.FirstOrDefault(x => x.DESCRIPCIONCATALOGO == ddlTipoMercado.SelectedValue).IDCATALAGO;
                subProducto.IDTIPOPRODUCTO = tipoProducto.FirstOrDefault(x => x.DESCRIPCIONCATALOGO == ddlTipoProducto.SelectedValue).IDCATALAGO;
                subProducto.PRESENTACION = txtPresentacion.Text;
                subProducto.CONCENTRACION = string.IsNullOrEmpty(txtConcentracion.Text) ? 0 : double.Parse(txtConcentracion.Text);
                subProducto.UNIDAD = txtUnidad.Text;
                subProducto.CANTIDAD = string.IsNullOrEmpty(txtCantidad.Text) ? short.Parse("0") : short.Parse(txtCantidad.Text);
                subProducto.PRINCIPIOACTIVO = txtPrincipio.Text;
                subProducto.INDICACIONESDEUSO = txtIndicaciones.Text;
                if (ValidarFormulario(subProducto))
                    bdd.SaveSubProducto(subProducto);
                Response.Redirect("~/ui/MantenimientoProducto.aspx");
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            
        }

        private bool ValidarFormulario(SUBPRODUCTO subProducto)
        {
            bool resultado = false;
            if (subProducto.IDGRUPO == Guid.Empty)
                throw new Exception("Seleccione un grupo");
            if (subProducto.IDAPLICACION == null || subProducto.IDAPLICACION.Value == Guid.Empty)
                throw new Exception("Seleccione una aplicacion");
            if (subProducto.IDFORMAPROD == null || subProducto.IDFORMAPROD.Value == Guid.Empty)
                throw new Exception("Seleccione una forma");
            if (subProducto.IDTIPOMERCADO == null || subProducto.IDTIPOMERCADO == Guid.Empty)
                throw new Exception("Seleccione el tipo de mercado");
            if (subProducto.IDTIPOPRODUCTO == null || subProducto.IDTIPOPRODUCTO == Guid.Empty)
                throw new Exception("Seleccione el tipo de producto");
            if (string.IsNullOrEmpty(subProducto.PRESENTACION))
                throw new Exception("Escriba la presentación");
            if (subProducto.CONCENTRACION == 0)
                throw new Exception("Escriba la concentación");
            if (string.IsNullOrEmpty(subProducto.UNIDAD))
                throw new Exception("Escriba la unidad");
            if (subProducto.CANTIDAD == 0)
                throw new Exception("Escriba la cantidad");
            if (string.IsNullOrEmpty(subProducto.PRINCIPIOACTIVO))
                throw new Exception("Escriba el principio activo");
            if (string.IsNullOrEmpty(subProducto.INDICACIONESDEUSO))
                throw new Exception("Escriba las indicaciones de uso");
            resultado = true;
            return resultado;
        }
    }
}