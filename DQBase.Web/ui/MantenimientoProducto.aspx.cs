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
    public partial class MantenimientoProducto : System.Web.UI.Page
    {
        private PRODUCTO selectedProduct = null;

        /// <summary>
        /// Se ejecuta cuando se carga la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindGridProducts(false);
                BindPropertyCombo();
            }
        }

        /// <summary>
        /// Llena el combo de de buscar por de los subproductos con la lista de propiedades de la clase subProducto
        /// </summary>
        private void BindPropertyCombo()
        {
            SubProductos subp = new SubProductos();
            ddlPropSubProducts.DataSource = subp.GetType().GetProperties().ToList(); ;
            ddlPropSubProducts.DataTextField = "Name";
            ddlPropSubProducts.DataValueField = "Name";
            ddlPropSubProducts.DataBind();
        }

        /// <summary>
        /// Llena el grid de sub productos
        /// </summary>
        /// <param name="loadFromSession">si tiene que cargar por session los productos</param>
        private void BindGridProducts(bool loadFromSession)
        {
            List<PRODUCTO> producs = null;
            if (loadFromSession)
                producs = Session["products"] as List<PRODUCTO>;
            else
            {
                IProductos dataBase = new BusinessLogic();
                producs = dataBase.GetProducts();
                Session.Add("products", producs);
            }
            GridProducts.DataSource = producs;
            GridProducts.DataBind();
        }

        /// <summary>
        /// Ejecuta el paginamiento en la grilla de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<PRODUCTO> filterProducts=Session["filterProducts"] as List<PRODUCTO>;
            GridProducts.PageIndex = e.NewPageIndex;
            if(filterProducts== null)
                BindGridProducts(true);
            else
            {
                GridProducts.DataSource=filterProducts;
                GridProducts.DataBind();
            }
        }

        /// <summary>
        /// Ejecuta los botones sobre la grilla de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow selectedRow = null;
            int index = 0;
            IProductos dataBase = null;
            List<SubProductos> subProductos = null;
            List<PRODUCTO> producs = producs = Session["products"] as List<PRODUCTO>;
            switch (e.CommandName)
            {
                case Constants.COMMAND_SUBPRODUCTOS:
                    index = int.Parse(e.CommandArgument.ToString());
                    selectedRow = GridProducts.Rows[index];
                    dataBase = new BusinessLogic();
                    selectedProduct = producs.FirstOrDefault(x => x.NOMBREPRODUCTO == selectedRow.Cells[4].Text);
                    Session.Add("selectedProduct", selectedProduct);
                    subProductos = dataBase.GetSubProductsByProduct(selectedProduct.IDPRODUCTO);
                    if (subProductos.Count > 0)
                    {
                        Session.Add("subProductos", subProductos);
                        GridSubProductos.DataSource = subProductos;
                        GridSubProductos.DataBind();
                        trSubProd.Visible = true;
                    }
                    else
                        trSubProd.Visible = false;
                    break;
                case Constants.COMMAND_EDITAR:
                    index = int.Parse(e.CommandArgument.ToString());
                    selectedRow = GridProducts.Rows[index];
                    selectedProduct = producs.FirstOrDefault(x => x.NOMBREPRODUCTO == selectedRow.Cells[4].Text);
                    Session.Add("selectedProduct", selectedProduct);
                    Response.Redirect("~/ui/EditarProducto.aspx");
                    break;
                case Constants.COMMAND_AGREGAR:
                    index = int.Parse(e.CommandArgument.ToString());
                    selectedRow = GridProducts.Rows[index];
                    selectedProduct = producs.FirstOrDefault(x => x.NOMBREPRODUCTO == selectedRow.Cells[4].Text);
                    Session.Add("selectedProduct", selectedProduct);
                    trSubProd.Visible = true;
                    break;
            }
            
        }

        /// <summary>
        /// Envia a la pagina de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNewProd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/EditarProducto.aspx");
        }

        /// <summary>
        /// Busca el o los productos que cumplan con la condicion ingresada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuscaProd_Click(object sender, EventArgs e)
        {
            List<PRODUCTO> producs = Session["products"] as List<PRODUCTO>;
            List<PRODUCTO> filterList = null;
            if (!string.IsNullOrEmpty(txtBuscaProd.Text))
            {
                filterList = producs.Where(x => x.NOMBREPRODUCTO.Contains(txtBuscaProd.Text)).ToList();
                if (filterList.Count > 0)
                {
                    GridProducts.DataSource = filterList;
                    GridProducts.DataBind();
                }
                Session.Add("filterProducts", filterList);
            }
            txtBuscaProd.Text = string.Empty;
            trSubProd.Visible = false;

        }

        /// <summary>
        /// Muestra todos los productos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            BindGridProducts(true);
            Session.Remove("filterProducts");
            trSubProd.Visible = false;
        }

        /// <summary>
        /// Ejecuta la accion de editar en la grilla de sub productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridSubProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow selectedRow = null;
            int index = 0;
            List<SubProductos> subProductos = Session["subProductos"] as List<SubProductos>;
            SubProductos subProductoSeleccionado = null;
            int orden = 0;
            if (e.CommandName == Constants.COMMAND_EDITAR)
            {
                index = int.Parse(e.CommandArgument.ToString());
                selectedRow = GridSubProductos.Rows[index];
                orden = int.Parse(selectedRow.Cells[2].Text);
                subProductoSeleccionado = subProductos.FirstOrDefault(x => x.Orden == orden);
                Session.Add("subProductoSeleccionado", subProductoSeleccionado);
                Response.Redirect("~/ui/EditarSubProductos.aspx");
            }
        }

        /// <summary>
        /// Envia a la pantalla para crear un nuevo sub producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNewSubProd_Click(object sender, EventArgs e)
        {
            Session.Remove("subProductoSeleccionado");
            Response.Redirect("~/ui/EditarSubProductos.aspx");
        }

        /// <summary>
        /// Realiza la busqueda sobre la grilla de subproductos, usa refleccion para buscar por la propiedad seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuscaSubProd_Click(object sender, EventArgs e)
        {
            List<SubProductos> subProducst = Session["subProductos"] as List<SubProductos>;
            List<SubProductos> filterList = null;
            if (!string.IsNullOrEmpty(txtBuscaSubProd.Text))
            {
                filterList = subProducst.Where(x => x.GetPropertyValue<string>(ddlPropSubProducts.SelectedValue) == txtBuscaSubProd.Text).ToList();
                if (filterList.Count > 0)
                {
                    GridSubProductos.DataSource = filterList;
                    GridSubProductos.DataBind();
                }
            }
            txtBuscaSubProd.Text = string.Empty;
        }

        /// <summary>
        /// Muestra todos los sub productos en la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnViewAllSub_Click(object sender, EventArgs e)
        {
            List<SubProductos> subProducst = Session["subProductos"] as List<SubProductos>;
            GridSubProductos.DataSource = subProducst;
            GridSubProductos.DataBind();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            CheckBox checkBorrado;
            IProductos bdd = new BusinessLogic();
            List<PRODUCTO> products = Session["products"] as List<PRODUCTO>;
            PRODUCTO selectedProduct = null;
            GridProducts.Rows.ToList().ForEach(row => 
            {
                checkBorrado = row.FindControl("chkBorrar") as CheckBox;
                if (checkBorrado.Checked)
                {
                    selectedProduct = products.FirstOrDefault(product => product.NOMBREPRODUCTO == row.Cells[4].Text);
                    selectedProduct.ESBORRADOPRODUCTO = true;
                    bdd.SaveProducto(selectedProduct);
                }
            });
        }

        protected void btnBorrarSubProducts_Click(object sender, EventArgs e)
        {
            List<SubProductos> subProducst = Session["subProductos"] as List<SubProductos>;
            SubProductos selectedSubProduct = null;
            ISubProductos bdd = new BusinessLogic();
            CheckBox checkBorrado;
            SUBPRODUCTO subproducto = null;
            GridSubProductos.Rows.ToList().ForEach(row => 
            {
                checkBorrado = row.FindControl("checkBorrar") as CheckBox;
                if (checkBorrado.Checked)
                {
                    selectedSubProduct = subProducst.FirstOrDefault(subp => subp.Orden == int.Parse(row.Cells[2].Text));
                    subproducto = new SUBPRODUCTO
                    {
                        IDSUBPRODUCTO = selectedSubProduct.IdSubProducto,
                        IDPRODUCTO = selectedSubProduct.IdProducto,
                        ESBORRADOSUBPRODUCTO = true
                    };
                    subproducto = subproducto.MarkAsModified();
                    bdd.SaveSubProducto(subproducto);
                }
            });
        }

    }
}