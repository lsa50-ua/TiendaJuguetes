using library;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaJuguetes {
    public partial class AñadirProducto : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Submit(object sender, EventArgs e) {
            ENArticulo articulo = new ENArticulo();
            string urlimagen = "~/fotos/" + NomImagen.Text + ".png";

            articulo.categoria = Categoria.SelectedIndex + 1;
            articulo.nombre = Nombre.Text;
            articulo.descripcion = Descripcion.Text;
            articulo.precio = int.Parse(Precio.Text);
            articulo.urlimagen = urlimagen;
            articulo.nombreimagen = NomImagen.Text;
            articulo.cod = articulo.obtenerUltimoId() + 1;

            articulo.crearArticulo();
            Response.Redirect("Default.aspx");
        }
    }
}