using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace TiendaJuguetes
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //crearUsuPrueba();

            SqlConnection connection = null;
            ENCarritos carrito = (ENCarritos)Session["Carrito"];

            //carrito.syncDatos();

            if (carrito == null)
            {
                TableRow r = new TableRow();
                TableCell c5 = new TableCell();
                c5.Controls.Add(new LiteralControl("No tienes articulos en tu carrito."));
                r.Cells.Add(c5);

                TablaCarrito.Rows.Add(r);
            } else if (carrito.articulos.Count() <= 0)
            {
                TableRow r = new TableRow();
                TableCell c5 = new TableCell();
                c5.Controls.Add(new LiteralControl("No tienes articulos en tu carrito."));
                r.Cells.Add(c5);

                TablaCarrito.Rows.Add(r);
            } else {
                try
                {
                    /*connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ToString());
                    connection.Open();

                    string query = "Select * From LinCarrito WHERE numCarrito = '" + carrito.id + "' ";
                    SqlCommand queryCommand = new SqlCommand(query, connection);
                    SqlDataReader read = queryCommand.ExecuteReader();*/

                    int total = 0;

                    for (int j = 0; j < carrito.articulos.Count(); j++)
                    {
                        TableRow r = new TableRow();
                        //read.Read();
                        //ENArticulo articulo = idArti(int.Parse(read["numProducto"].ToString()));
                        ENArticulo articulo = carrito.idToArticulo(carrito.articulos[j].id_prod);

                        Image image = new Image();
                        image.ImageUrl = articulo.urlimagen;
                        image.Height = 100;
                        //image.Width = 100;

                        TableCell c4 = new TableCell();
                        c4.Controls.Add(image);
                        c4.HorizontalAlign = (HorizontalAlign)1;
                        r.Cells.Add(c4);

                        TableCell c = new TableCell();
                        c.Controls.Add(new LiteralControl("<a href='Articulo.aspx?nombreimagen=" + articulo.nombreimagen + "'>"));
                        c.Controls.Add(new LiteralControl(articulo.nombre));
                        c.Controls.Add(new LiteralControl("</a>"));
                        c.HorizontalAlign = (HorizontalAlign)2;
                        r.Cells.Add(c);

                        TableCell c2 = new TableCell();
                        c2.Controls.Add(new LiteralControl(articulo.precio.ToString() + " €"));
                        c2.HorizontalAlign = (HorizontalAlign)2;
                        r.Cells.Add(c2);

                        ImageButton menos = new ImageButton();
                        menos.Click += new ImageClickEventHandler(menosButton);
                        //menos.AlternateText = read["numProducto"].ToString();
                        menos.AlternateText = carrito.articulos[j].id_prod.ToString();
                        menos.ImageUrl = "fotos/botonmenos.png";
                        menos.Width = 20;
                        menos.Height = 20;

                        //TextBox textBox = new TextBox();
                        //textBox.Text = read["cantidad"].ToString();
                        //textBox.Text = carrito.articulos[j].cantidad.ToString();
                        //textBox.Width = 50;
                        //textBox.TextChanged += new EventHandler(this.TextChanged);

                        ImageButton mas = new ImageButton();
                        mas.Click += new ImageClickEventHandler(masButton);
                        //menos.AlternateText = read["numProducto"].ToString();
                        mas.AlternateText = carrito.articulos[j].id_prod.ToString();
                        mas.ImageUrl = "fotos/botonmas.png";
                        mas.Width = 20;
                        mas.Height = 20;

                        TableCell c3 = new TableCell();
                        c3.Controls.Add(menos);
                        c3.Controls.Add(new LiteralControl("  " + carrito.articulos[j].cantidad.ToString() + "  "));
                        c3.Controls.Add(mas);
                        c3.HorizontalAlign = (HorizontalAlign)2;
                        r.Cells.Add(c3);

                        TableCell c5 = new TableCell();
                        total = total + (carrito.articulos[j].cantidad * articulo.precio);
                        c5.Controls.Add(new LiteralControl(((carrito.articulos[j].cantidad * articulo.precio).ToString()) +" €"));
                        c5.HorizontalAlign = (HorizontalAlign)2;
                        r.Cells.Add(c5);

                        ImageButton borrar = new ImageButton();
                        borrar.Click += new ImageClickEventHandler(borrarDelCarrito);
                        //menos.AlternateText = read["numProducto"].ToString();
                        borrar.AlternateText = carrito.articulos[j].id_prod.ToString();
                        borrar.ImageUrl = "fotos/botonasparoja.png";
                        borrar.Width = 50;
                        borrar.Height = 50;

                        TableCell c6 = new TableCell();
                        c6.Controls.Add(borrar);
                        r.Cells.Add(c6);
                        c6.HorizontalAlign = (HorizontalAlign)3;

                        TablaCarrito.Rows.Add(r);
                        
                    }

                    TableRow r2 = new TableRow();
                    TableCell c7 = new TableCell();
                    c7.Controls.Add(new LiteralControl("Precio total: "+ total + " €"));
                    c7.HorizontalAlign = (HorizontalAlign)2;
                    r2.Cells.Add(c7);

                    TablaPrecio.Rows.Add(r2);

                    TableRow r3 = new TableRow();
                    TableCell c8 = new TableCell();
                    c8.Controls.Add(new LiteralControl("Gastos de envio: 3.00 €"));
                    c8.HorizontalAlign = (HorizontalAlign)2;
                    r3.Cells.Add(c8);

                    TablaPrecio.Rows.Add(r3);

                    TableRow r4 = new TableRow();
                    total += 3;
                    TableCell c9 = new TableCell();
                    c9.Controls.Add(new LiteralControl("Total a pagar: " + total + " €"));
                    c9.HorizontalAlign = (HorizontalAlign)2;
                    r4.Cells.Add(c9);

                    TablaPrecio.Rows.Add(r4);

                    ImageButton pagar = new ImageButton();
                    pagar.Click += new ImageClickEventHandler(pagarCarrito);
                    //menos.AlternateText = read["numProducto"].ToString();
                    //pagar.AlternateText = carrito.articulos[j].id_prod.ToString();
                    pagar.ImageUrl = "fotos/botonpagar.png";
                    pagar.Width = 400;
                    pagar.Height = 120;

                    TableRow r5 = new TableRow();
                    TableCell c10 = new TableCell();
                    c10.Controls.Add(pagar);
                    c10.HorizontalAlign = (HorizontalAlign)2;
                    r5.Cells.Add(c10);

                    TablaPrecio.Rows.Add(r5);


                }
                catch (SqlException ex)
                {
                    Console.WriteLine("ERROR: {0}", ex.Message);

                    TableRow r = new TableRow();
                    TableCell c5 = new TableCell();
                    c5.Controls.Add(new LiteralControl("No tienes articulos en tu carrito. (SQLERROR)"));
                    r.Cells.Add(c5);

                    TablaCarrito.Rows.Add(r);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: {0}", ex.Message);

                    TableRow r = new TableRow();
                    TableCell c5 = new TableCell();
                    c5.Controls.Add(new LiteralControl("No tienes articulos en tu carrito. (EXERROR)"));
                    r.Cells.Add(c5);

                    TablaCarrito.Rows.Add(r);

                }
            }
        }

        void pagarCarrito(Object sender, ImageClickEventArgs e)
        {
            if (Session["email"] == null)
            {
                Page.Response.Redirect("InicioSesion.aspx");
            }
            else
            {
                Page.Response.Redirect("Pago.aspx");
            }
        }

        void borrarDelCarrito(Object sender, ImageClickEventArgs e)
        {
            ENCarritos carrito = (ENCarritos)Session["Carrito"];

            ImageButton text = (ImageButton)sender;
            int id = int.Parse(text.AlternateText);

            carrito.borrarArticuloCarrito(id);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        void menosButton(Object sender, ImageClickEventArgs e)
        {
            ENCarritos carrito = (ENCarritos)Session["Carrito"];

            ImageButton text = (ImageButton)sender;
            int id = int.Parse(text.AlternateText);

            carrito.borrarDelCarrito(id, 1);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        void masButton(Object sender, ImageClickEventArgs e)
        {
            ENCarritos carrito = (ENCarritos)Session["Carrito"];

            ImageButton text = (ImageButton)sender;
            int id = int.Parse(text.AlternateText);

            carrito.anadirACarrito(id, 1);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }


        protected void cambioCantidad(int indicador, int id) // 0 - Menos 1 - Mas
        {
            ENCarritos carrito = (ENCarritos)Session["Carrito"];

            SqlConnection connection = null;

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ToString());
            connection.Open();

            TableRow r = new TableRow();
            TableCell c5 = new TableCell();
            c5.Controls.Add(new LiteralControl("Si soy " + id.ToString()));
            r.Cells.Add(c5);

            string query = "INSERT LinCarrito SET cantidad = '" + 2 + "'WHERE id_carr = '" + carrito.id + "' AND id_prod = '" + 3 + "'";
            SqlCommand consulta = new SqlCommand(query, connection);
            consulta.ExecuteNonQuery();

            //tb4.Text = "Adios!";
            TablaCarrito.Rows.Add(r);
        }

        /*public ENArticulo idArti(int id)
        {
            ENArticulo articulo = new ENArticulo();
            articulo.nombre = "ERROR";

            try
            {
                SqlConnection connection = null;

                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ToString());
                connection.Open();

                string query = "Select * From [dbo].[Articulo] WHERE cod = '" + id + "' ";
                SqlCommand queryCommand = new SqlCommand(query, connection);
                SqlDataReader read = queryCommand.ExecuteReader();
                read.Read();

                articulo.cod = int.Parse(read["cod"].ToString());
                articulo.nombre = read["nombre"].ToString();
                articulo.precio = int.Parse(read["precio"].ToString());
                articulo.urlimagen = read["urlimagen"].ToString();
                articulo.descripcion = read["descripcion"].ToString();
                articulo.nombreimagen = read["nombreimagen"].ToString();
                articulo.stock = int.Parse(read["stock"].ToString());

            }
            catch (SqlException ex)
            {
                Console.WriteLine("ERROR: {0}", ex.Message);
                articulo.nombre = "ERRORSQL";
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex.Message);
                articulo.nombre = "ERROREX: " + ex.Message + ". ";
            }

            return articulo;

        }*/

        public void crearUsuPrueba()
        {
            ENCarritos carritomain = (ENCarritos)Session["Carrito"];
            if (carritomain == null) { 

                //TablaCarrito.Rows.Add(r);

                ENUsuario usu = new ENUsuario();

                ENCarritos carr = new ENCarritos();
                //carr.id = 1;
                //ENLinCarrito lin = new ENLinCarrito(1, 1, 10);
                //ENLinCarrito lin2 = new ENLinCarrito(2, 1, 10);
                //carr.articulos.Add(lin);
                //carr.articulos.Add(lin2);

                //carr.anadirACarrito(2, 20);
                carr.anadirACarrito(1, 40);
                carr.anadirACarrito(1, 20);
                carr.anadirACarrito(2, 500);

                usu.NIF = "49273207P";
                Session.Add("Usuario", usu);
                Session.Add("Carrito", carr);
            }
        }
    }
}