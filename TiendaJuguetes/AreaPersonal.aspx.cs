using library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaJuguetes
{
    
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarUsu.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarContra.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarDir.aspx");
        }
        /*
protected void Page_Load(object sender, EventArgs e)
{
if (!IsPostBack)
{
LLenarDropDownList();
}
ENUsuario en = new ENUsuario();
en.EMAIL = Session["email"].ToString();
if (en.readAllUsu())
{
TextBoxEmail.Text = en.EMAIL;
TextBoxNombre.Text = en.NOMBRE;
TextBoxApellidos.Text = en.APELLIDOS;
TextBoxDNI.Text = en.NIF;
TextBoxTelefono.Text = en.TELEFONO.ToString();
TextBoxContrasena.Text = en.CONTRASENA.ToString();
DropDownList.SelectedValue = en.PROVINCIA.ToString();
TextBoxCalle.Text = en.CALLE;
TextBoxCodPostal.Text = en.CODPOSTAL.ToString();
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
*/
    }
}