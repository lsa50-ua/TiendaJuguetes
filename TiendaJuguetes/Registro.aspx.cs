using library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaJuguetes
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenarDropDownList();
            }
        }

        protected void LLenarDropDownList()
        {
            ENProvincia en = new ENProvincia();
            DataSet ds = en.obtener();

            DropDownList.DataSource = ds;
            DropDownList.DataTextField = "nombre";
            DropDownList.DataValueField = "cod";
            DropDownList.DataBind();
            DropDownList.Items.Insert(0, new ListItem("<Seleccione Provincia>", "0"));
        }

        protected void ButtonRegister(object sender, EventArgs e)
        {
            bool ok = EmailValidator.IsValid && NombreValidator.IsValid && ApellidosValidator.IsValid && DNIValidator.IsValid && TelefonoValidator.IsValid &&
                ContrasenaValidator.IsValid && Contrasena2Validator.IsValid && DropDownList.SelectedValue != "0" && CalleValidator.IsValid && CodPostalValidator.IsValid
                && EmptyEmail.IsValid && EmptyName.IsValid && EmptyApellidos.IsValid && EmptyDNI.IsValid && EmptyTelefono.IsValid && EmptyContrasena.IsValid &&
                EmptyContrasena2.IsValid && EmptyCalle.IsValid && EmptyCodPostal.IsValid;
            if(DropDownList.SelectedValue == "0")
            {
                Label1.Text = "Introduzca una provinicia!!";
            }
            else
            {
                Label1.Text = "";
            }
            if (ok)
            {
                ENUsuario en = new ENUsuario(TextBoxEmail.Text, TextBoxNombre.Text, TextBoxApellidos.Text, TextBoxDNI.Text, int.Parse(TextBoxTelefono.Text), int.Parse(TextBoxContrasena.Text), int.Parse(DropDownList.SelectedValue), TextBoxCalle.Text, int.Parse(TextBoxCodPostal.Text));
                if (en.createUsuario())
                {
                    Session["email"] = en.EMAIL;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Label2.Text = "El email o el DNI ya existen en la Base de Datos!!";
                }
            }
        }

    }
}