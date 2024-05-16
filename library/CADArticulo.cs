using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

public class CADArticulo
{
	private String constring;

	private String _comando;

	public String Comando {
        get { return _comando; }
        set { _comando = value; }
    }


	public CADArticulo()
	{
		constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
	}

	public CADArticulo(String comando) {
		constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
		Comando = comando;
	}


	public bool obtenerArticulo(ENArticulo en)
    {
		bool done = true;
		SqlConnection con = null;
		String consulta = "";
        try
        {
			con = new SqlConnection(constring); 
			con.Open();
			consulta = "select * from [dbo].[Articulo] where nombreimagen ='" + en.nombreimagen + "'";
			SqlCommand comando = new SqlCommand(consulta, con);
			SqlDataReader read = comando.ExecuteReader();
			read.Read();
			if (read["nombreimagen"].ToString() == en.nombreimagen) {
				en.cod = int.Parse(read["cod"].ToString());
				en.nombre = read["nombre"].ToString();
				en.precio = int.Parse(read["precio"].ToString());
				en.urlimagen = read["urlimagen"].ToString();
				en.descripcion = read["descripcion"].ToString();
				en.categoria = int.Parse(read["categoria"].ToString());
				en.stock = int.Parse(read["stock"].ToString());
			} 
		} 
		catch (SqlException e)
		{
			done = false;
			Console.WriteLine("ERROR: {0}", e.Message);

		}
		catch (Exception e)
		{
			done = false;
			Console.WriteLine("ERROR: {0}", e.Message);
		}
		finally
		{
			con.Close();
		}

		return done;
	}

	public DataTable obtenerArticulos()
	{
		DataTable dtArticulos = new DataTable();
		SqlConnection sqlConnection = new SqlConnection(constring);
		SqlDataAdapter sqlAdapter = null;

        try
        {
			if(Comando == null) {
				sqlAdapter = new SqlDataAdapter("select * from Articulo", constring);
			}
			else {
				sqlAdapter = new SqlDataAdapter(Comando, constring);
			}
			sqlAdapter.Fill(dtArticulos);
        }
		catch (SqlException sqlException)
		{
			Console.WriteLine("SQL operation has failed. Error: {0}", sqlException.Message);
		}
		catch (Exception exception)
		{
			Console.WriteLine("The operation has failed. Error: {0}", exception.Message);
		}
        finally
        {
			sqlConnection.Close();
        }

		return dtArticulos;
	}


	public DataTable obtenerArticulos(int categoria)
	{
		DataTable dtArticulos = new DataTable();
		SqlConnection sqlConnection = new SqlConnection(constring);
		SqlDataAdapter sqlAdapter = null;

		try
		{
			if (Comando == null)
			{
				sqlAdapter = new SqlDataAdapter("select * from Articulo where categoria = " + categoria, constring);
			}
			else
			{
				sqlAdapter = new SqlDataAdapter(Comando, constring);
			}
			sqlAdapter.Fill(dtArticulos);
		}
		catch (SqlException sqlException)
		{
			Console.WriteLine("SQL operation has failed. Error: {0}", sqlException.Message);
		}
		catch (Exception exception)
		{
			Console.WriteLine("The operation has failed. Error: {0}", exception.Message);
		}
		finally
		{
			sqlConnection.Close();
		}

		return dtArticulos;
	}

	public DataTable obtenerArticulo(int codArticulo)
    {
		DataTable dtArticulo = new DataTable();
		SqlConnection sqlConnection = new SqlConnection(constring);
		try
		{
			SqlDataAdapter sqlAdapter = new SqlDataAdapter("select cod, nombre, precio, nombreimagen, urlimagen, descripcion, categoria from Articulo where cod = " + codArticulo, constring);
			sqlAdapter.Fill(dtArticulo);
		}
		catch (SqlException sqlException)
		{
			Console.WriteLine("SQL operation has failed. Error: {0}", sqlException.Message);
		}
		catch (Exception exception)
		{
			Console.WriteLine("The operation has failed. Error: {0}", exception.Message);
		}
		finally
		{
			sqlConnection.Close();
		}

		return dtArticulo;
	}


	public bool crearArticulo(ENArticulo en)
	{
		bool created = false;
		SqlConnection connection = null;

		try
		{
			connection = new SqlConnection(constring);
			connection.Open();

			string consulta = "INSERT INTO[dbo].[Articulo] (cod, nombre, precio, nombreimagen, urlimagen, descripcion, categoria) VALUES (" + en.cod + ", '" + en.nombre + "', '" + en.precio + "', '" + en.nombreimagen + "', '" + en.urlimagen + "', '"
				+ en.descripcion + "', " + en.categoria + ")";
			SqlCommand queryCommand = new SqlCommand(consulta, connection);
			queryCommand.ExecuteNonQuery();
			created = true;
			connection.Close();
		}
		catch (SqlException e)
		{
			created = false;
			Console.WriteLine("ERROR: {0}", e.Message);

		}
		catch (Exception e)
		{
			created = false;
			Console.WriteLine("ERROR: {0}", e.Message);
		}
		finally
		{
			connection.Close();
		}

		return created;

	}

	public bool borrarArticulo(ENArticulo en)
	{
		bool found = true;
		SqlConnection connection = null;

		try
		{
			connection = new SqlConnection(constring);
			connection.Open();

			string consulta = "Select * From [dbo].[Usuarios] Where codigo = '" + en.cod + "' ";
			SqlCommand queryCommand = new SqlCommand(consulta, connection);
			SqlDataReader read = queryCommand.ExecuteReader();
			read.Read();

			if (int.Parse(read["cod"].ToString()) == en.cod)
			{
				en.cod = int.Parse(read["cod"].ToString());
				en.nombre = read["nombre"].ToString();
				en.precio = int.Parse(read["precio"].ToString());
			}
			else
				found = false;

			read.Close();
			connection.Close();
		}
		catch (SqlException e)
		{
			found = false;
			Console.WriteLine("ERROR: {0}", e.Message); 

		}
		catch (Exception e)
		{
			found = false;
			Console.WriteLine("ERROR: {0}", e.Message);
		}
		finally
		{
			connection.Close();
		}

		try
		{
			connection = new SqlConnection(constring);
			connection.Open();

			string consulta = "Select * From [dbo].[Usuarios] Where codigo = '" + en.cod + "' ";
			SqlCommand queryCommand = new SqlCommand(consulta, connection);
			SqlDataReader read = queryCommand.ExecuteReader();
			read.Read();

			if (int.Parse(read["cod"].ToString()) == en.cod)
			{
				en.cod = int.Parse(read["cod"].ToString());
				en.nombre = read["nombre"].ToString();
				en.precio = int.Parse(read["precio"].ToString());
			}
			else
				found = false;

			read.Close();
			connection.Close();
		}
		catch (SqlException e)
		{
			found = false;
			Console.WriteLine("ERROR: {0}", e.Message);

		}
		catch (Exception e)
		{
			found = false;
			Console.WriteLine("ERROR: {0}", e.Message);
		}
		finally
		{
			connection.Close();
		}

		return found;
	}

	public bool actualizarArticulo(ENArticulo en)
	{
		bool done = true;
		SqlConnection con = null;
		try
		{
			con = new SqlConnection(constring);
			con.Open();

			SqlCommand consulta = new SqlCommand("Insert INTO [dbo].[Articulo]" +
				"(codigo, nombre, precio, urlimagen, descripcion) " +
				"values (@codigo, @nombre, @precio, @urlimagen, @descripcion, @categoria)", con);

			consulta.Parameters.Add("@codigo", SqlDbType.Int).Value = en.cod;
			consulta.Parameters.Add("@Nombre", SqlDbType.Text).Value = en.nombre;
			consulta.Parameters.Add("@precio", SqlDbType.Text).Value = en.precio;
			consulta.Parameters.Add("@descripcion", SqlDbType.Text).Value = en.descripcion;
			consulta.Parameters.Add("@urlimagen", SqlDbType.Image).Value = en.urlimagen;
			consulta.Parameters.Add("@categoria", SqlDbType.Text).Value = en.categoria;

			consulta.ExecuteNonQuery();
		}
		catch (SqlException e)
		{
			done = false;
			Console.WriteLine("The operation has failed.Error: {0}", e.Message);
		}
		catch (Exception ex)
		{
			done = false;
			Console.WriteLine("The operation has failed.Error: {0}", ex.Message);
		}
        finally
        {
			con.Close();
        }
		return done;
	}


	public int obtenerUltimoId() {

		SqlConnection conn = new SqlConnection(constring);
		conn.Open();
		string comando = "SELECT cod FROM [dbo].[Articulo] ORDER BY cod DESC";
		SqlCommand command = new SqlCommand(comando, conn);
		SqlDataReader read = command.ExecuteReader();
        if(read.Read()) {
			return int.Parse(read["cod"].ToString());
        } else {
			return 0;
        }
    }

}
