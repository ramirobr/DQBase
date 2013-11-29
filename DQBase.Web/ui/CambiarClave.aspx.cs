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
    public partial class CambiarClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                USUARIO userToModify = Session["userToModify"] as USUARIO;
                lblNombreUsuario.Text = userToModify.NOMBRECOMPLETO;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IUsuarios bdd = new BusinessLogic();
                USUARIO userToModify = Session["userToModify"] as USUARIO;
                if (ValidarFormulario())
                {
                    userToModify.CLAVE = txtReClave.Text.EncriptarMD5();
                    userToModify = userToModify.MarkAsModified();
                    bdd.SaveUsuario(userToModify);
                    Response.Redirect("~/ui/MantenimientoUsuarios.aspx");
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            
        }

        /// <summary>
        /// Valida la informacion del formulario
        /// </summary>
        /// <returns></returns>
        private bool ValidarFormulario()
        {
            bool resultado = false;
            if (string.IsNullOrEmpty(txtClave.Text))
                throw new Exception("Ingrese la clave");
            if (string.IsNullOrEmpty(txtReClave.Text))
                throw new Exception("Ingrese la clave");
            if (!txtClave.Text.Equals(txtReClave.Text))
                throw new Exception("Las claves ingresadas no son iguales, repita por favor");
            resultado = true;
            return resultado;
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoUsuarios.aspx");
        }
    }
}