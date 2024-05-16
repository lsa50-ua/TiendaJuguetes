using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CADLinCarrito
{

	private String constring;

	public CADLinCarrito()
    {
        constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
    }

    /*private void syncBaseDatos(ENLinCarrito en)
    {
		SqlConnection connection = null;

		try
		{
			connection = new SqlConnection(constring);
			connection.Open();

			string query = "Insert INTO [dbo].[LinCarrito] (id_prod, id_carr, cantidad) VALUES ('" + en.id_prod + "', '" + en.id_carr + "', " + en.cantidad + ")";
			SqlCommand queryCommand = new SqlCommand(query, connection);
			queryCommand.ExecuteNonQuery();

			connection.Close();
		}
	}*/
}

