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
    public partial class MantenimientoUbicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPaises(false);
                CargarRegiones(false);
                CargarCiudades(false);
            }
        }

        private void CargarCiudades(bool loadFromSession)
        {
            List<Ubicacion> ciudades = null;
            if (loadFromSession)
            {
                ciudades = Session["ciudades"] as List<Ubicacion>;
            }
            else 
            {
                IUbicacion bdd = new BusinessLogic();
                ciudades = bdd.GetUbicacionCiudades();
                Session.Add("ciudades", ciudades);
            }
            gridCiudades.DataSource = ciudades;
            gridCiudades.DataBind();
        }


        private void CargarRegiones(bool loadFromSession)
        {
            List<Ubicacion> regiones = null;
            if (loadFromSession)
            {
                regiones = Session["regiones"] as List<Ubicacion>;
            }
            else
            {
                IUbicacion bdd = new BusinessLogic();
                regiones = bdd.GetUbicacionRegiones();
                Session.Add("regiones", regiones);
            }
            gridRegiones.DataSource = regiones;
            gridRegiones.DataBind();
        }

        private void CargarPaises(bool loadFromSession)
        {
            List<UBICACIONGEOGRAFICA> paises = null;
            if (loadFromSession)
            {
                paises = Session["paises"] as List<UBICACIONGEOGRAFICA>;
            }
            else
            {
                IUbicacion bdd = new BusinessLogic();
                paises = bdd.GetPaises();
                Session.Add("paises", paises);
            }
            gridPaises.DataSource = paises;
            gridPaises.DataBind();
        }

        protected void btnNewPais_Click(object sender, EventArgs e)
        {
            Session.Remove("paises");
            Response.Redirect("~/ui/EditarPais.aspx");
        }

        protected void gridPaises_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = null;
            int index = 0;
            UBICACIONGEOGRAFICA paisSeleccionado = null;
            List<UBICACIONGEOGRAFICA> paises;
            try
            {
                if (e.CommandName == Constants.COMMAND_EDITAR)
                {
                    index = int.Parse(e.CommandArgument.ToString());
                    row = gridPaises.Rows[index];
                    paises = Session["paises"] as List<UBICACIONGEOGRAFICA>;
                    paisSeleccionado = paises.FirstOrDefault(x => x.NOMBREUBICACION == row.Cells[2].Text);
                    Session.Add("paisSeleccionado", paisSeleccionado);
                    Response.Redirect("~/ui/EditarPais.aspx");
                }
            }
            catch (Exception ex)
            {
                ShowErrorsPaises(ex.Message);
            }
        }

        protected void gridPaises_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridPaises.PageIndex = e.NewPageIndex;
            CargarPaises(true);
        }


        private void ShowErrorsPaises(string message)
        {
            lblErrorPais.Visible = true;
            lblErrorPais.Text = message;
        }

        protected void btnVerTodosPais_Click(object sender, EventArgs e)
        {
            CargarPaises(false);
        }

        protected void btnBuscarPais_Click(object sender, EventArgs e)
        {
            List<UBICACIONGEOGRAFICA> paises = Session["paises"] as List<UBICACIONGEOGRAFICA>;
            List<UBICACIONGEOGRAFICA> filterList = null;
            try
            {
                if (string.IsNullOrEmpty(txtBuscar.Text)) throw new Exception("El texto esta en blanco");
                filterList = paises.Where(x => x.NOMBREUBICACION.ToLower().Contains(txtBuscar.Text.ToLower())).ToList();
                gridPaises.DataSource = filterList;
                gridPaises.DataBind();
            }
            catch (Exception ex)
            {
                ShowErrorsPaises(ex.Message);
            }
        }

        protected void btnBorrarPais_Click(object sender, EventArgs e)
        {
            CheckBox chkBorrar = null;
            UBICACIONGEOGRAFICA paisSeleccionado = null;
            List<UBICACIONGEOGRAFICA> paises = Session["paises"] as List<UBICACIONGEOGRAFICA>;
            IUbicacion bdd = new BusinessLogic();
            try
            {
                gridPaises.Rows.ToList().ForEach(row => 
                {
                    chkBorrar = row.FindControl("chkBorrar") as CheckBox;
                    if (chkBorrar.Checked)
                    {
                        paisSeleccionado = paises.FirstOrDefault(x => x.NOMBREUBICACION == row.Cells[2].Text);
                        paisSeleccionado.ESBORRADOUBICACION = true;
                        paisSeleccionado = paisSeleccionado.MarkAsModified();
                        bdd.SaveUbicacion(paisSeleccionado);
                    }
                });
                Response.Redirect("~/ui/MantenimientoUbicacion.aspx");
            }
            catch (Exception ex)
            {
                ShowErrorsPaises(ex.Message);
            }
        }

        protected void btnNuevoRegion_Click(object sender, EventArgs e)
        {
            Session.Remove("ubicacionToUpdate");
            Response.Redirect("~/ui/EditarRegion.aspx");
        }

        protected void btnBuscarRegion_Click(object sender, EventArgs e)
        {
            List<Ubicacion> regiones = Session["regiones"] as List<Ubicacion>;
            List<Ubicacion> filerlist = null;
            if (string.IsNullOrEmpty(txtBuscarRegion.Text)) return;
            filerlist = regiones.Where(x => x.GetPropertyValue<string>(ddPropRegiones.SelectedValue).Contains(txtBuscarRegion.Text)).ToList();
            gridRegiones.DataSource = filerlist;
            gridRegiones.DataBind();
        }

        protected void btnVerTodosRegion_Click(object sender, EventArgs e)
        {
            CargarRegiones(false);
        }

        protected void btnBorrarRegion_Click(object sender, EventArgs e)
        {
            CheckBox chkBorrar = null;
            List<Ubicacion> regiones = Session["regiones"] as List<Ubicacion>;
            List<UBICACIONGEOGRAFICA> paises = Session["paises"] as List<UBICACIONGEOGRAFICA>;
            UBICACIONGEOGRAFICA ubicacionTodelete = null;
            Ubicacion ubicacionSelected=null;
            IUbicacion bdd = new BusinessLogic();
            gridRegiones.Rows.ToList().ForEach(row => 
            {
                chkBorrar = row.FindControl("chkBorrar") as CheckBox;
                if (chkBorrar.Checked)
                {
                    ubicacionSelected=regiones.FirstOrDefault(x => x.Nombre==row.Cells[3].Text);
                    ubicacionTodelete = new UBICACIONGEOGRAFICA
                    {
                        IDUBICACION = ubicacionSelected.IdUbicacion,
                        NOMBREUBICACION = ubicacionSelected.Nombre,
                        CATEGORIAUBICACION = Constants.TIPO_UBICACION_REGION,
                        ESBORRADOUBICACION = true,
                        IDPADRE = paises.FirstOrDefault(x => x.NOMBREUBICACION == ubicacionSelected.Pais) != null ? paises.FirstOrDefault(x => x.NOMBREUBICACION == ubicacionSelected.Pais).IDPADRE : null
                    }.MarkAsModified();
                    bdd.SaveUbicacion(ubicacionTodelete);
                }
            });
            Response.Redirect("~/ui/MantenimientoUbicacion.aspx");
        }

        protected void gridRegiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridRegiones.PageIndex = e.NewPageIndex;
            CargarRegiones(true);
        }

        protected void gridRegiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = null;
            int index = 0;
            Ubicacion regionSelected = null;
            List<Ubicacion> regiones;
            UBICACIONGEOGRAFICA ubicacionToUpdate = null;
            List<UBICACIONGEOGRAFICA> paises = Session["paises"] as List<UBICACIONGEOGRAFICA>;
            Guid? idPais = null;
            if (e.CommandName == Constants.COMMAND_EDITAR)
            {
                index = int.Parse(e.CommandArgument.ToString());
                row = gridRegiones.Rows[index];
                regiones = Session["regiones"] as List<Ubicacion>;
                regionSelected = regiones.FirstOrDefault(x => x.Nombre == row.Cells[3].Text);
                idPais=paises.FirstOrDefault(x => x.NOMBREUBICACION == regionSelected.Pais) != null ? paises.FirstOrDefault(x => x.NOMBREUBICACION == regionSelected.Pais).IDUBICACION : Guid.Empty;
                if (idPais == Guid.Empty) idPais = null;
                ubicacionToUpdate = new UBICACIONGEOGRAFICA
                {
                    IDUBICACION = regionSelected.IdUbicacion,
                    NOMBREUBICACION = regionSelected.Nombre,
                    CATEGORIAUBICACION = Constants.TIPO_UBICACION_REGION,
                    IDPADRE = idPais
                }.MarkAsUnchanged();
                Session.Add("ubicacionToUpdate", ubicacionToUpdate);
                Response.Redirect("~/ui/EditarRegion.aspx");
            }
        }

        protected void gridCiudades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridCiudades.PageIndex = e.NewPageIndex;
            CargarCiudades(true);
        }

        protected void gridCiudades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = null;
            int index = 0;
            Ubicacion regionSelected = null;
            List<Ubicacion> ciudades;
            UBICACIONGEOGRAFICA ciudadToUpdate = null;
            IUbicacion bdd = new BusinessLogic();
            List<UBICACIONGEOGRAFICA> regiones = null;
            Guid? idRegion = null;
            if (e.CommandName == Constants.COMMAND_EDITAR)
            {
                regiones = bdd.GetRegiones();
                index = int.Parse(e.CommandArgument.ToString());
                row = gridCiudades.Rows[index];
                ciudades = Session["ciudades"] as List<Ubicacion>;
                regionSelected = ciudades.FirstOrDefault(x => x.Nombre == row.Cells[3].Text);
                idRegion = regiones.FirstOrDefault(x => x.NOMBREUBICACION == regionSelected.Region) != null ? regiones.FirstOrDefault(x => x.NOMBREUBICACION == regionSelected.Region).IDUBICACION : Guid.Empty;
                if (idRegion == Guid.Empty) idRegion = null;
                ciudadToUpdate = new UBICACIONGEOGRAFICA
                {
                    IDUBICACION = regionSelected.IdUbicacion,
                    NOMBREUBICACION = regionSelected.Nombre,
                    CATEGORIAUBICACION = Constants.TIPO_UBICACION_CIUDAD,
                    IDPADRE = idRegion
                }.MarkAsUnchanged();
                Session.Add("ciudadToUpdate", ciudadToUpdate);
                Response.Redirect("~/ui/EditarCiudad.aspx");
            }
        }

        protected void btnNewCiudad_Click(object sender, EventArgs e)
        {
            Session.Remove("ciudadToUpdate");
            Response.Redirect("~/ui/EditarCiudad.aspx");
        }

        protected void btnBuscarCiudad_Click(object sender, EventArgs e)
        {
            List<Ubicacion> ciudades = Session["ciudades"] as List<Ubicacion>;
            List<Ubicacion> filterList = null;
            if (string.IsNullOrEmpty(txtBuscarCiudad.Text)) return;
            filterList = ciudades.Where(x => x.GetPropertyValue<string>(ddlPropCiudad.SelectedValue).Contains(txtBuscarCiudad.Text)).ToList();
            gridCiudades.DataSource = filterList;
            gridCiudades.DataBind();
        }

        protected void btnVerTodosCiudad_Click(object sender, EventArgs e)
        {
            CargarCiudades(false);
        }

        protected void btnBorrarCiudad_Click(object sender, EventArgs e)
        {
            CheckBox chkBorrar = null;
            IUbicacion bdd = new BusinessLogic();
            UBICACIONGEOGRAFICA ubicacionTodelete = null;
            Ubicacion ubicacionSelected = null;
            List<Ubicacion> ciudades = Session["ciudades"] as List<Ubicacion>;
            List<UBICACIONGEOGRAFICA> regiones = bdd.GetRegiones();
            gridCiudades.Rows.ToList().ForEach(row => 
            {
                chkBorrar = row.FindControl("chkBorrar") as CheckBox;
                if (chkBorrar.Checked)
                {
                    ubicacionSelected = ciudades.FirstOrDefault(x => x.Nombre == row.Cells[3].Text);
                    ubicacionTodelete = new UBICACIONGEOGRAFICA
                    {
                        IDUBICACION = ubicacionSelected.IdUbicacion,
                        NOMBREUBICACION = ubicacionSelected.Nombre,
                        ESBORRADOUBICACION = true,
                        IDPADRE = regiones.FirstOrDefault(x => x.NOMBREUBICACION == ubicacionSelected.Region) != null ? regiones.FirstOrDefault(x => x.NOMBREUBICACION == ubicacionSelected.Region).IDPADRE : null
                    }.MarkAsModified();
                    bdd.SaveUbicacion(ubicacionTodelete);
                }
            });
        }
    }
}