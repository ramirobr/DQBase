using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Profile;
using DQBase.Business;
using DQBase.Entities;

namespace DQBase.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        /// <summary>
        /// Muestra el mensaje de la excepcion producida 
        /// </summary>
        /// <param name="mensaje">texto del mensaje</param>
        private void MostrarError(string mensaje)
        {
            LabelError.Visible = true;
            LabelError.Text = mensaje;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                IUsuarios negocio = new BusinessLogic();
                USUARIO usuario = new USUARIO();
                UsuarioAutenticado respuesta = null;
                usuario.USUARIO1 = txtUsuario.Text;
                usuario.CLAVE = txtClave.Text.EncriptarMD5();
                respuesta = negocio.Autenticar(usuario);
                if (respuesta==null)
                { 
                    MostrarError("Usuario o contraseña no validos");
                    return;
                }
                if (respuesta.Usuario.NOMBRECOMPLETO == Constants.NOMBRE_USUARION_ADMIN || (respuesta.Usuario.FechaCaducidad != null && respuesta.Usuario.FechaCaducidad.Value > DateTime.Now.Date))
                {
                    Session.Add("Usuario", respuesta.Usuario);
                    Session.Add("Menu", respuesta.Menu);
                    Response.Redirect("~/ui/Entrada.aspx");
                }
                else
                    throw new Exception("El usuario no esta vigente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }
    }
}