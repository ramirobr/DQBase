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
    public partial class EditarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarDatos();
        }

        private void CargarDatos()
        {
            USUARIO userToModify = Session["userToModify"] as USUARIO;
            txtNomCompleto.Text = userToModify.NOMBRECOMPLETO;
            txtNomUsuario.Text = userToModify.USUARIO1;
            dtpCaducidad.Value = userToModify.FechaCaducidad;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            IUsuarios bdd = new BusinessLogic();
            USUARIO userToModify = Session["userToModify"] as USUARIO;
            userToModify.NOMBRECOMPLETO = txtNomCompleto.Text;
            userToModify.USUARIO1 = txtNomUsuario.Text;
            userToModify.FechaCaducidad = (DateTime)dtpCaducidad.Value;
            bdd.SaveUsuario(userToModify);
            Response.Redirect("~/ui/MantenimientoUsuarios.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoUsuarios.aspx");
        }

    }
}