using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaJuguetes
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["nombreimagen"] != null)
            {
                string nombreimagen = Request.QueryString["nombreimagen"];
                //Buscar en la BD todos lod datos de ese ID
                ENArticulo articuloen = new ENArticulo();
                CADArticulo articulocad = new CADArticulo();
                ENCategoria categoria = new ENCategoria();
                articuloen.nombreimagen = nombreimagen;
                articulocad.obtenerArticulo(articuloen);
                categoria.Categoria = articuloen.categoria;
                categoria.getCategoria();

                //Asigno los datos en la página
                Image1.ImageUrl = articuloen.urlimagen;
                nombreJuguete.Text = articuloen.nombre;

                nombreArt.Text = articuloen.nombre;
                categoriaArt.Text = categoria.NomCategoria;
                descripcionArt.Text = articuloen.descripcion;
                precioArt.Text = articuloen.precio.ToString() + "€";
                stockArt.Text = articuloen.stock.ToString();
            }
        }

        protected void botoncarritoClick(object sender, EventArgs e)
        {
            string nombreimagen = Request.QueryString["nombreimagen"];
            //Buscar en la BD todos lod datos de ese ID
            ENArticulo articuloen = new ENArticulo();
            CADArticulo articulocad = new CADArticulo();
            articuloen.nombreimagen = nombreimagen;
            articulocad.obtenerArticulo(articuloen);

            ENCarritos carrito = (ENCarritos)Session["Carrito"];
            carrito.anadirACarrito(articuloen.cod, 1);
            Response.Redirect("Carrito.aspx");
        }
    }
}