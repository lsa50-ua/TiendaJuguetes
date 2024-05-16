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
    public partial class CambiarDir : System.Web.UI.Page
    {
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

        protected void Modificarb(object sender, EventArgs e)
        {
            Response.Redirect("AreaPersonal.aspx");
        }
    }
}