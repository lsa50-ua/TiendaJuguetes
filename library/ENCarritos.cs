using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Windows;

public class ENCarritos
{
	private int _id;
	private int _total;
	//private int _estado; //1 - Pendiente, 2 - Procesado, 3 - Abandonado.
	public List<ENLinCarrito> articulos;

	public int total
	{
		get { return _total; }
		set { _total = value; }
	}

	public int id
	{
		get { return _id; }
		set { _id = value; }
	}

	public ENCarritos()
	{
		total = 0;
		id = nextId();
		articulos = new List<ENLinCarrito>();

		CADCarritos user = new CADCarritos();

		user.crearCarritoDB(this);	
	}

	public void calcularTotal()
    {
		total = 0;

		for (int i = 0; i < articulos.Count; i++)
        {
			ENArticulo arti = idToArticulo(articulos[i].id_prod);
			total = total + (articulos[i].cantidad * arti.precio);
        }

		CADCarritos user = new CADCarritos();

		user.calcularTotal(this);
	}

	private int nextId()
    {
		CADCarritos user = new CADCarritos();

		return user.nextId(this); 	
    }

	public bool borrarCarrito() //Vacia el carrito
	{
		CADCarritos user = new CADCarritos();
		return user.borrarCarrito(this);
	}

	public bool anadirACarrito(int id_prod, int cantidad)
	{
		if (cantidad == 0)
		{
			return borrarArticuloCarrito(id_prod);
		}
		else
		{
			bool existe = false;

			for (int i = 0; i < this.articulos.Count; i++)
			{
				if (id_prod == this.articulos[i].id_prod)
				{
					existe = true;
					this.articulos[i].cantidad = this.articulos[i].cantidad + cantidad;
					break;
				}
			}

			if (!existe)
			{
				ENLinCarrito nuevaLin = new ENLinCarrito(id_prod, this.id, cantidad);

				this.articulos.Add(nuevaLin);
			}

			this.calcularTotal();

			CADCarritos user = new CADCarritos();
			return user.anadirACarrito(this, id_prod, existe);
		}
	}

	public bool borrarDelCarrito(int id_prod, int cantidad) //Sirve para quitarle cantidad a un producto
	{
		int nuevaCantidad = 0;

		for (int i = 0; i < this.articulos.Count; i++)
		{
			if (id_prod == this.articulos[i].id_prod)
			{
				nuevaCantidad = this.articulos[i].cantidad - cantidad;
				
				if (nuevaCantidad <= 0) {
					MessageBox.Show("No puedes seleccionar menos cantidad. Para borrar el producto de tu carrito usa el botón de borrar a la derecha. (ASPA ROJO)");
					return false;
				} else
                {
					this.articulos[i].cantidad = nuevaCantidad;
					break;
				}
			}
		}

		this.calcularTotal();

		CADCarritos user = new CADCarritos();
		return user.borrarDelCarrito(this, id_prod, nuevaCantidad);
	
	}

	public bool borrarArticuloCarrito(int id_prod) //Borra la línea del producto
	{
		for (int i = 0; i < this.articulos.Count; i++)
		{
			if (id_prod == this.articulos[i].id_prod)
			{
				this.articulos.RemoveAt(i);  
				break;
			}
		}

		this.calcularTotal();

		CADCarritos user = new CADCarritos();
		return user.borrarArticuloCarrito(this, id_prod);
	}

	public List<ENArticulo> todosArticulos()
	{
		List<ENArticulo> lista = new List<ENArticulo>();

		SqlConnection connection = null;

		connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ToString());
		connection.Open();

		string query2 = "Select COUNT(codigo) From [dbo].[Articulos] '";
		SqlCommand queryCommand2 = new SqlCommand(query2, connection);
		int max = (Int32)queryCommand2.ExecuteScalar();

		string query = "Select * From [dbo].[Articulos] '";
		SqlCommand queryCommand = new SqlCommand(query, connection);
		SqlDataReader read = queryCommand.ExecuteReader();
		

		for (int i = 0; i < max; i++)
        {
			read.Read();

			ENArticulo articulo = new ENArticulo();

			articulo.cod = int.Parse(read["codigo"].ToString());
			articulo.nombre = read["nombre"].ToString();
			articulo.precio = int.Parse(read["precio"].ToString());
			articulo.urlimagen = read["urlimagen"].ToString();
			articulo.descripcion = read["descripcion"].ToString();

			lista.Add(articulo);
		}

		return lista;
	}

	public void syncDatos() //Coge los datos del Carrito y los implementa en la db
    {
		CADCarritos user = new CADCarritos();
		user.syncDatos(this);
    }

	public ENArticulo idToArticulo(int id)
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
	}
}
