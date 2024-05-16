using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace TiendaJuguetes
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario();
            if (EmailValidator.IsValid && ContrasenaValidator.IsValid && EmptyEmail.IsValid && EmptyEmail.IsValid)
            {
                en.EMAIL = TextBoxEmail.Text;
                en.CONTRASENA = int.Parse(TextBoxContrasena.Text);
                if (en.validarUsuario())
                {
                    Session["email"] = en.EMAIL;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Mensaje.Text = "Alguno de los campos no es valido, Introduzcalos correctamente de nuevo";
                }
            }

        }
    }
}