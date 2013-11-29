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
    public partial class MantenimientoCorpLab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCorporaciones(false);
                CargarLaboratorios(false);
                LlenarComboPropLab();
            }
        }

        private void LlenarComboPropLab()
        {
            ListaLaboratorio obj = new ListaLaboratorio();
            List<PropertyInfo> properties = obj.GetType().GetProperties().ToList();
            ddlPropLab.DataSource = properties;
            ddlPropLab.DataTextField = "Name";
            ddlPropLab.DataValueField = "Name";
            ddlPropLab.DataBind();
        }

        private void CargarLaboratorios(bool loadFromSession)
        {
            List<ListaLaboratorio> laboratorios = null;
            if (loadFromSession)
            {
                laboratorios = Session["laboratorios"] as List<ListaLaboratorio>;
                laboratorios = laboratorios.OrderBy(x => x.Nombre).ToList();
            }
            else
            {
                ILaboratorios bdd = new BusinessLogic();
                laboratorios = bdd.GetLaboratorios();
                laboratorios = laboratorios.OrderBy(x => x.Nombre).ToList();
                Session.Add("laboratorios", laboratorios);
            }
            GridLaboratorios.DataSource = laboratorios;
            GridLaboratorios.DataBind();
        }

        private void CargarCorporaciones(bool loadFromSession)
        {
            List<CORPORACION> corporaciones=null;
            if (loadFromSession)
            {
                corporaciones = Session["corporaciones"] as List<CORPORACION>;
                corporaciones = corporaciones.OrderBy(x => x.NOMBRECORPORACION).ToList();
            }
            else
            {
                ICorporaciones bdd = new BusinessLogic();
                corporaciones = bdd.ObtenerCorporaciones();
                corporaciones = corporaciones.OrderBy(x => x.NOMBRECORPORACION).ToList();
                Session.Add("corporaciones", corporaciones);
            }
            GridCorporaciones.DataSource = corporaciones;
            GridCorporaciones.DataBind();
        }

        protected void GridCorporaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridCorporaciones.PageIndex = e.NewPageIndex;
            CargarCorporaciones(true);
        }

        protected void btnBuscarCorp_Click(object sender, EventArgs e)
        {
            List<CORPORACION> corporaciones = Session["corporaciones"] as List<CORPORACION>;
            List<CORPORACION> filterList = null;
            filterList = corporaciones.Where(x => x.GetPropertyValue<string>(ddlBuscaCorp.SelectedValue).ToLower().Contains(txtBuscarCorp.Text.ToLower())).ToList();
            GridCorporaciones.DataSource = filterList;
            GridCorporaciones.DataBind();
        }

        protected void btnVerTodosCorp_Click(object sender, EventArgs e)
        {
            CargarCorporaciones(false);
        }

        protected void btnBorrarCorp_Click(object sender, EventArgs e)
        {
            ICorporaciones bdd = new BusinessLogic();
            CheckBox chkBorrar;
            CORPORACION corporacion = null;
            List<CORPORACION> corporaciones = Session["corporaciones"] as List<CORPORACION>;
            GridCorporaciones.Rows.ToList().ForEach(row => 
            {
                chkBorrar = row.FindControl("chkBorrar") as CheckBox;
                if (chkBorrar.Checked)
                {
                    corporacion = corporaciones.FirstOrDefault(x => x.NOMBRECORPORACION == row.Cells[2].Text);
                    corporacion.ESBORRADOCORPORACION = true;
                    corporacion = corporacion.MarkAsModified();
                    bdd.SaveCorporacion(corporacion);
                    Response.Redirect("~/ui/MantenimientoCorpLab.aspx");
                }
            });
        }

        protected void btnNuevoCorp_Click(object sender, EventArgs e)
        {
            Session.Remove("selectedCorp");
            Response.Redirect("~/ui/EditarCorporacion.aspx");
        }

        protected void GridCorporaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow selectedRow = null;
            int index = 0;
            List<CORPORACION> corporaciones = Session["corporaciones"] as List<CORPORACION>;
            CORPORACION selectedCorp = null;
            string nombreCorp=string.Empty;
            if (e.CommandName == Constants.COMMAND_EDITAR)
            {
                index = int.Parse(e.CommandArgument.ToString());
                selectedRow = GridCorporaciones.Rows[index];
                nombreCorp=Server.HtmlDecode(selectedRow.Cells[2].Text);
                selectedCorp = corporaciones.FirstOrDefault(x => x.NOMBRECORPORACION == nombreCorp);
                Session.Add("selectedCorp", selectedCorp);
                Response.Redirect("~/ui/EditarCorporacion.aspx");
            }
        }

        protected void GridLaboratorios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridLaboratorios.PageIndex = e.NewPageIndex;
            CargarLaboratorios(true);
        }

        protected void btnBuscarLab_Click(object sender, EventArgs e)
        {
            List<CORPORACION> corporaciones = Session["corporaciones"] as List<CORPORACION>;
            List<CORPORACION> filterList = null;
            filterList = corporaciones.Where(x => x.GetPropertyValue<string>(ddlPropLab.SelectedValue).Contains(txtBuscar.Text)).ToList();
            GridLaboratorios.DataSource = filterList;
            GridLaboratorios.DataBind();
            txtBuscar.Text = "";
        }

        protected void btnVerTodosLab_Click(object sender, EventArgs e)
        {
            CargarLaboratorios(true);
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            ILaboratorios bdd = new BusinessLogic();
            List<ListaLaboratorio> laboratorios = Session["laboratorios"] as List<ListaLaboratorio>;
            CheckBox chkBorrar;
            LABORATORIO selectedLab = null;
            GridLaboratorios.Rows.ToList().ForEach(row => 
            {
                chkBorrar = row.FindControl("chkBorrar") as CheckBox;
                if (chkBorrar.Checked)
                {
                    selectedLab = laboratorios.Where(x => x.Nombre == row.Cells[3].Text).Select(lab => new LABORATORIO 
                    {
                        IDLABORATORIO=lab.IdLaboratorio,
                        NOMBRELABORATORIO=lab.Nombre,
                        ESBORRADOLABORATORIO = true
                    }).FirstOrDefault();
                    selectedLab = selectedLab.MarkAsModified();
                    bdd.SaveLaboratorio(selectedLab);
                }
            });
            Response.Redirect("~/ui/MantenimientoCorpLab.aspx");
        }

        protected void btnAddLab_Click(object sender, EventArgs e)
        {
            Session.Remove("selectedLab");
            Response.Redirect("~/ui/EditarLaboratorio.aspx");
        }

        protected void GridLaboratorios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow selectedRow = null;
            int index = 0;
            List<ListaLaboratorio> laboratorios = Session["laboratorios"] as List<ListaLaboratorio>;
            ListaLaboratorio selectedLab = null;
            string labNombre = string.Empty;
            if (e.CommandName == Constants.COMMAND_EDITAR)
            {
                index = int.Parse(e.CommandArgument.ToString());
                selectedRow = GridLaboratorios.Rows[index];
                labNombre = Server.HtmlDecode(selectedRow.Cells[3].Text);
                selectedLab = laboratorios.FirstOrDefault(x => x.Nombre == labNombre);
                Session.Add("selectedLab", selectedLab);
                Response.Redirect("~/ui/EditarLaboratorio.aspx");
            }
        }
    }
}