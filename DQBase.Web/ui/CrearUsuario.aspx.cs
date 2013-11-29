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
    public partial class CrearUsuario : System.Web.UI.Page
    {
        private List<LABORATORIO> _laboratorios;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                    CargarLaboratorio();

            }
            catch (Exception ex)
            {
                lblErrores.Visible = true;
                lblErrores.Text = ex.Message;
            }
        }

        /// <summary>
        /// Carga los laboratorios
        /// </summary>
        private void CargarLaboratorio()
        {
            ILaboratorios bdd = new BusinessLogic();
            _laboratorios = bdd.ObtenerLaboratorio();
            ddlLaboratorio.DataSource = _laboratorios;
            ddlLaboratorio.DataTextField = "NOMBRELABORATORIO";
            ddlLaboratorio.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpCaducidad.Value == null) throw new Exception("Escoja una fecha");
                ILaboratorios bdd = new BusinessLogic();
                IUsuarios userBdd = new BusinessLogic();
                LABORATORIO laboratorioConsultado=bdd.ObtenerLaboratorioPorNombre(ddlLaboratorio.Text);
                USUARIO userToSave = new USUARIO
                {
                    IDUSUARIO = Guid.NewGuid(),
                    IDLABORATORIO = laboratorioConsultado != null ? laboratorioConsultado.IDLABORATORIO : Guid.Empty,
                    NOMBRECOMPLETO = txtNombre.Text,
                    USUARIO1 = txtUsuario.Text,
                    FechaCreacion=DateTime.Now.Date,
                    FechaCaducidad=(DateTime)dtpCaducidad.Value,
                    CLAVE=txtClaveRepeat.Text.EncriptarMD5()
                };
                userBdd.CrearUsuario(userToSave);
                lblErrores.Visible = true;
                Response.Redirect("~/ui/MantenimientoUsuarios.aspx");
            }
            catch (Exception ex)
            {
                lblErrores.Visible = true;
                lblErrores.Text = ex.Message;
            }
           
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoUsuarios.aspx");
        }
    }
}