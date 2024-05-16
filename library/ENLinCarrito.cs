using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ENLinCarrito
{
	private int _id_prod;
	private int _id_carr;
	private int _cantidad;

	public int id_prod
	{
		get { return _id_prod; }
		set { _id_prod = value; }
	}
	public int id_carr
	{
		get { return _id_carr; }
		set { _id_carr = value; }
	}

	public int cantidad
	{
		get { return _cantidad; }
		set { _cantidad = value; }
	}

	public ENLinCarrito(int id_prod, int id_carr, int cantidad)
	{
		if (id_prod > 0 && id_carr > 0 && cantidad > 0)
        {
			this.id_prod = id_prod;
			this.id_carr = id_carr;
			this.cantidad = cantidad;
		}
	}

	public ENLinCarrito(int id_prod, int id_carr)
	{
		if (id_prod > 0 && id_carr > 0)
		{
			this.id_prod = id_prod;
			this.id_carr = id_carr;
			this.cantidad = 1;
		}
	}
}
