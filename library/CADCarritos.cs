using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.SessionState;

public class CADCarritos
{
	private String constring;

	public CADCarritos()
	{
		constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
	}

    public void crearCarritoDB(ENCarritos en)
    {
        SqlConnection connection = null;

        try
        {
            connection = new SqlConnection(constring);
            connection.Open();


            string query = "INSERT INTO Carrito (numCarrito, importe) " +
                "VALUES (" + en.id + ", 0)";
            SqlCommand consulta = new SqlCommand(query, connection);
            consulta.ExecuteNonQuery();

            connection.Close();
        }
        catch (SqlException e)
        {
            Debug.WriteLine("ALVARO - ERRORSQL: ", e.Message);
        }
        catch (Exception e)
        {
            Debug.WriteLine("ALVARO - ERROREX: ", e.Message);
        }
    }

    public void calcularTotal(ENCarritos en)
    {
        SqlConnection connection = null;

        try
        {
            connection = new SqlConnection(constring);
            connection.Open();

            string query = "UPDATE Carrito SET importe = " + en.total
                + "WHERE numCarrito = " + en.id;
            SqlCommand consulta = new SqlCommand(query, connection);
            consulta.ExecuteNonQuery();
            connection.Close();

            HttpContext context = HttpContext.Current;
            context.Session["Carrito"] = en;

        }
        catch (SqlException e)
        {
            Console.WriteLine("ERROR: {0}", e.Message);

        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: {0}", e.Message);
        }

    }

    public int nextId(ENCarritos en)
    {
        int id = 0;
        SqlConnection connection = null;

        try
        {
            connection = new SqlConnection(constring);
            connection.Open();

            string query = "SELECT numCarrito FROM [dbo].[Carrito] ORDER BY numCarrito desc";
            SqlCommand queryCommand = new SqlCommand(query, connection);
            SqlDataReader read = queryCommand.ExecuteReader();

            if (read.Read())
            {
                id = int.Parse(read["numCarrito"].ToString()) + 1;
            } else
            {
                id = 1;
            }

            connection.Close();
        }
        catch (SqlException e)
        {
            Console.WriteLine("ERROR: {0}", e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: {0}", e.Message);
        }

        return id;
    }
    public bool borrarCarrito(ENCarritos en)
	{
        bool deleted = false;
        SqlConnection connection = null;

        try
        {
            connection = new SqlConnection(constring);
            connection.Open();

            string query = "DELETE * FROM [dbo].[LinCarrito] WHERE id_carr = '" + en.id + "'";
            SqlCommand consulta = new SqlCommand(query, connection);
            consulta.ExecuteNonQuery();
            deleted = true;
            connection.Close();

            en.articulos.Clear();
            en.calcularTotal();

            HttpContext context = HttpContext.Current;
            context.Session["Carrito"] = en;
        }
        catch (SqlException e)
        {
            deleted = false;
            Console.WriteLine("ERROR: {0}", e.Message);

        }
        catch (Exception e)
        {
            deleted = false;
            Console.WriteLine("ERROR: {0}", e.Message);
        }
        
        return deleted;
	}

	public bool anadirACarrito(ENCarritos en, int id_prod, bool existe)
	{
        bool anadido = true;
        SqlConnection connection = null;

        try
        {
            connection = new SqlConnection(constring);
            connection.Open();

            if (existe) { 
                for (int i = 0; i < en.articulos.Count; i++)
                {
                    if (id_prod == en.articulos[i].id_prod)
                    {
                        string query = "UPDATE LinCarrito SET cantidad = " + en.articulos[i].cantidad 
                            + "WHERE numCarrito = " + en.id + " AND numProducto = " + en.articulos[i].id_prod;
                        SqlCommand consulta = new SqlCommand(query, connection);
                        consulta.ExecuteNonQuery();
                        anadido = true;
                        connection.Close();
                        break;
                    }
                }
            } else {
                int pos = en.articulos.Count() - 1;
                ENArticulo articulo = en.idToArticulo(id_prod);
                string query = "INSERT INTO LinCarrito (cantidad, numCarrito, numProducto) " +
                    "VALUES (" + en.articulos[pos].cantidad + ", " + en.id + ", " + id_prod + ")";
                SqlCommand consulta = new SqlCommand(query, connection);
                consulta.ExecuteNonQuery();
                anadido = true;
                connection.Close();
            }

            HttpContext context = HttpContext.Current;
            context.Session["Carrito"] = en;

            return anadido;
        }
        catch (SqlException e)
        {
            anadido = false;
            Console.WriteLine("ERROR: {0}", e.Message);

        }
        catch (Exception e)
        {
            anadido = false;
            Console.WriteLine("ERROR: {0}", e.Message);
        }

        return anadido;
    }

    public bool borrarDelCarrito(ENCarritos en, int id_prod, int cantidad) //Sirve para quitarle cantidad a un producto
    {
        bool anadido = false;
        SqlConnection connection = null;

        try
        {
            connection = new SqlConnection(constring);
            connection.Open();

            for (int i = 0; i < en.articulos.Count; i++)
            {
                if (id_prod == en.articulos[i].id_prod)
                {
                    string query = "UPDATE LinCarrito SET cantidad = " + en.articulos[i].cantidad
                        + "WHERE numCarrito = " + en.id + " AND numProducto = " + en.articulos[i].id_prod; 
                    SqlCommand consulta = new SqlCommand(query, connection);
                    consulta.ExecuteNonQuery();
                    connection.Close();
                    anadido = true;
                    break;
                }
            }

            HttpContext context = HttpContext.Current;
            context.Session["Carrito"] = en;

        }
        catch (SqlException e)
        {
            anadido = false;
            Console.WriteLine("ERROR: {0}", e.Message);

        }
        catch (Exception e)
        {
            anadido = false;
            Console.WriteLine("ERROR: {0}", e.Message);
        }

        return anadido;
    
    }

    public bool borrarArticuloCarrito(ENCarritos en, int id_prod)
    {
        bool borrado = true;
        SqlConnection connection = null;

        try
        {
            connection = new SqlConnection(constring);
            connection.Open();
            string query = "DELETE FROM LinCarrito WHERE numProducto = " + id_prod + "AND numCarrito = " + en.id;
            SqlCommand consulta = new SqlCommand(query, connection);
            consulta.ExecuteNonQuery();

            HttpContext context = HttpContext.Current;
            context.Session["Carrito"] = en;
        }
        catch (SqlException e)
        {
            borrado = false;
            Console.WriteLine("ERROR: {0}", e.Message);
        }
        catch (Exception e)
        {
            borrado = false;
            Console.WriteLine("ERROR: {0}", e.Message);
        }

        return borrado;
    }

    public void syncDatos(ENCarritos en)
    {
        SqlConnection connection = null;

        try
        {
            connection = new SqlConnection(constring);
            connection.Open();
            string query = "DELETE * FROM LinCarrito WHERE id_carr = '" + en.id + "'";
            SqlCommand consulta = new SqlCommand(query, connection);
            consulta.ExecuteNonQuery();

            for (int i = 0; i < en.articulos.Count(); i++)
            {
                string query2 = "INSERT INTO LinCarrito (cantidad, numCarrito, numProducto) " +
                    "VALUES (" + en.articulos[i].cantidad + ", " + en.id + ", " + en.articulos[i].id_prod + ")";

                SqlCommand consulta2 = new SqlCommand(query2, connection);
                consulta2.ExecuteNonQuery();
            }

            HttpContext context = HttpContext.Current;
            context.Session["Carrito"] = en;
        }
        catch (SqlException e)
        {
            Console.WriteLine("ERROR: {0}", e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: {0}", e.Message);
        }

    }
}
