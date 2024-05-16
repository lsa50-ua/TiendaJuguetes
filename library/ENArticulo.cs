using System;
using System.Data; 

public class ENArticulo
{
	private int _categoria, _cod, _precio, _stock;
	private string _nombre, _descripcion, _urlimagen, _nombreimagen;

	public string nombreimagen
	{
		get { return _nombreimagen; }
		set { _nombreimagen = value; }
	}
	public int cod
	{
		get { return _cod; }
		set { _cod = value; }
	}

	public int categoria
	{
		get { return _categoria; }
		set { _categoria = value; }
	}

	public string nombre
	{
		get { return _nombre; }
		set { _nombre = value; }
	}

	public string descripcion
	{
		get { return _descripcion; }
		set { _descripcion = value; }
	}

	public string urlimagen
	{
		get { return _urlimagen; }
		set { _urlimagen = value; }
	}

	public int precio
	{
		get { return _precio; }
		set { _precio = value; }
	}

	public int stock {
		get { return _stock; }
		set { _stock = value; }
	}


	public ENArticulo()
    {
		cod = 1;
		nombre = "";
		categoria = 0;
		descripcion = "";
		nombreimagen = "";
		urlimagen = "";
		precio = 0;
		stock = 0;
	}

	public ENArticulo(int cod, string nombre, int categoria, int precio, string nombreimagen, string urlimagen, string descripcion)
	{
		this.cod = cod;
		this.nombre = nombre;
		this.categoria = categoria;
		this.descripcion = descripcion;
		this.nombreimagen = nombreimagen;
		this.urlimagen = urlimagen;
		this.precio = precio;
		this.stock = stock;
	}

	public ENArticulo(ENArticulo articulo)
    {
		this.cod = articulo.cod;
		this.nombre = articulo.nombre;
		this.categoria = articulo.categoria;
		this.precio = articulo.precio;
		this.urlimagen = articulo.urlimagen;
		this.descripcion = articulo.descripcion;
		this.stock = articulo.stock;
    }

	public bool crearArticulo()
	{
		bool creado = false;
		CADArticulo user = new CADArticulo();
		creado =  user.crearArticulo(this);
		return creado;
	}

	public bool borrarArticulo()
	{
		bool borrado = false;
		CADArticulo user = new CADArticulo();
		borrado = user.borrarArticulo(this);
		return borrado;
	}

	public bool actualizarArticulo()
	{
		bool actualizado = false;
		CADArticulo user = new CADArticulo();
		actualizado =  user.actualizarArticulo(this);
		return actualizado;
	}

	public bool obtenerArticulo()
	{
		bool obtenido = false;
		CADArticulo articulo = new CADArticulo();
        if (articulo.obtenerArticulo(this))
        {
			obtenido = true;
        }
		return obtenido;
	}

	public DataTable obtenerArticulo(int codArticulo)
    {
		DataTable dtArticulo = new DataTable();
		CADArticulo cadArticulo = new CADArticulo();

		dtArticulo = cadArticulo.obtenerArticulo(codArticulo);

		return dtArticulo; 
    }


	public static DataTable obtenerArticulos()
    {
		CADArticulo cadArticulo = new CADArticulo();
		DataTable dtArticulos;

		dtArticulos = cadArticulo.obtenerArticulos();
		return dtArticulos; 
    }

	public static DataTable obtenerArticulos(int categoria)
    {
		CADArticulo cadArticulo = new CADArticulo();
		DataTable dtArticulos = cadArticulo.obtenerArticulos(categoria);

		return dtArticulos;
    }

	public DataTable obtenerArticulos(string comando) {
		CADArticulo cadArticulo = new CADArticulo();
		DataTable dtArticulos;
		cadArticulo.Comando = comando;
		dtArticulos = cadArticulo.obtenerArticulos();
		return dtArticulos;
	}

	public int obtenerUltimoId() {
		CADArticulo cad = new CADArticulo();
		return cad.obtenerUltimoId();
    }


}
