using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace TiendaJuguetes {
    public partial class WebForm4 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Pago(object sender, EventArgs e) {
            ENPedido pedido = new ENPedido();
            ENLinped linped = new ENLinped();
            ENCarritos carrito = (ENCarritos)Session["Carrito"];
            ENFactura factura = new ENFactura();
            ENCarritos carritoVoid = new ENCarritos();

            pedido.Usuario = Session["email"].ToString();
            pedido.numPedido = pedido.obtenerUltimo() + 1;
            pedido.Importe = int.Parse(carrito.total.ToString());
            pedido.AgregarPedido();
            linped.Pedido = pedido.numPedido;

            for(int i=0; i<carrito.articulos.Count; i++) {
                linped.Articulo = carrito.articulos[i].id_prod;
                linped.Cantidad = carrito.articulos[i].cantidad;
                linped.Linea = i + 1;
                linped.agregarLinea();
            }
            factura.Id = factura.getLastId() + 1;
            factura.Usuario = pedido.Usuario;
            factura.addFactura();
            carrito.borrarCarrito();
            Session.Add("Carrito", carritoVoid);
            Response.Redirect("Default.aspx");
        }
    }
}