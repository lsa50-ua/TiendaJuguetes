using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace TiendaJuguetes {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack){
                DataTable dataTable = new DataTable();
                dataTable = ENArticulo.obtenerArticulos();

                lvArticulos.DataSource = dataTable;
                lvArticulos.DataBind();
            }

            ENCarritos carrito = (ENCarritos)Session["Carrito"];

            if (carrito == null)
            {
                ENCarritos carro = new ENCarritos();

                Session.Add("Carrito", carro);
            }
        }

        protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
        {

        }

        protected void foto_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedImage = (ImageButton)sender;
            int codArticulo = int.Parse(clickedImage.CommandArgument);
            ENArticulo articulo = new ENArticulo();
            DataTable dtArticulo = articulo.obtenerArticulo(codArticulo);

            if (dtArticulo.Rows.Count > 0)
            {
                DataRow drArticulo = dtArticulo.Rows[0]; 
                articulo.nombreimagen = drArticulo["nombreimagen"].ToString();
                Response.Redirect("Articulo.aspx?nombreimagen=" + articulo.nombreimagen);
            }
        }

        protected void orderBy(string comando) {
            if(Page.IsPostBack) {
                DataTable dataTable = new DataTable();
                ENArticulo en = new ENArticulo();
                dataTable = en.obtenerArticulos(comando);

                lvArticulos.DataSource = dataTable;
                lvArticulos.DataBind();
            }
        }

        /*Prueba*/

        protected void onOrdenar(object sender, EventArgs e) {
            string comando = "";
            int opcion = OrdenarPor.SelectedIndex;

            switch(opcion) {
                case 0:
                    comando = "SELECT * FROM [dbo].[Articulo]";
                    orderBy(comando);
                    break;
                case 1:
                    comando = "SELECT * FROM [dbo].[Articulo] ORDER BY precio ASC";
                    orderBy(comando);
                    break;
                case 2:
                    comando = "SELECT * FROM [dbo].[Articulo] ORDER BY precio DESC";
                    orderBy(comando);
                    break;
                case 3:
                    comando = "SELECT * FROM [dbo].[Articulo] ORDER BY nombre ASC";
                    orderBy(comando);
                    break;
            }

        }
    }
}