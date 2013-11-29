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
    public partial class CearPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["rolSelected"] != null)
                    CargarDesdeSession();
            }
        }

        private void CargarDesdeSession()
        {
            ROL rolSelected = Session["rolSelected"] as ROL;
            txtDescripcion.Text = rolSelected.DESCRIPCIONROL;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ROL rol = null;
            IUsuarios bdd = new BusinessLogic();
            if (Session["rolSelected"] != null)
            {
                rol = Session["rolSelected"] as ROL;
                rol = rol.MarkAsModified();
            }
            else
            {
                rol = new ROL();
                rol.IDROL = Guid.NewGuid();
            }
            rol.DESCRIPCIONROL = txtDescripcion.Text;
            bdd.SaveRol(rol);
            Response.Redirect("~/ui/MantenimientoPerfiles.aspx");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/MantenimientoPerfiles.aspx");
        }
    }
}