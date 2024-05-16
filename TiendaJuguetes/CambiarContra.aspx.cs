using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaJuguetes
{
    public partial class CambiarContra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario();
            en.EMAIL = Session["email"].ToString();
            if (en.readAllUsu())
            {

            }

        }

        protected void ModificarB(object sender, EventArgs e)
        {
            Response.Redirect("AreaPersonal.aspx");
        }
    }
}