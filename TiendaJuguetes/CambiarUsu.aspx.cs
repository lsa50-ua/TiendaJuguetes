using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaJuguetes
{
    public partial class CambiarUsu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario();
            en.EMAIL = Session["email"].ToString();
            if (en.readAllUsu())
            {
                TextBoxEmail.Text = en.EMAIL;
                TextBoxNombre.Text = en.NOMBRE;
                TextBoxApellidos.Text = en.APELLIDOS;
            }
        }

        protected void BModificar(object sender, EventArgs e)
        {
            if (EmailValidator.IsValid && NombreValidator.IsValid && ApellidosValidator.IsValid && EmptyEmail.IsValid && EmptyName.IsValid && EmptyApellidos.IsValid)
            {
                ENUsuario en = new ENUsuario();
                en.EMAIL = Session["email"].ToString();
                if (en.readAllUsu())
                {
                    en.EMAIL = TextBoxEmail.Text;
                    en.NOMBRE = TextBoxNombre.Text;
                    en.APELLIDOS = TextBoxApellidos.Text;
                    if (en.modificarUsuario() == false)
                    {
                        Label2.Text = "No se ha podido modificar";
                    }
                    else
                    {
                        Session.Remove("email");
                        Session["email"] = en.EMAIL;
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }
    }
}