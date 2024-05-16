using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace library
{
    public class CADLinped
    {
        private string constring;

        public CADLinped(){
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool agregarLinea(ENLinped en) {
            bool done = true;
            SqlConnection conn = new SqlConnection(constring);
            string comando = "INSERT INTO [dbo].[LinPedido] (numPedido, linea, numProducto, cantidad) VALUES (" +
                en.Pedido + ", " + en.Linea + ", " + en.Articulo + ", " + en.Cantidad + ")";
            try {
                conn.Open();
                SqlCommand commando = new SqlCommand(comando, conn);
                commando.ExecuteNonQuery();
            }
            catch(SqlException e) {
                Console.WriteLine("Error. {0}", e.Message);
            }
            finally {
                conn.Close();
            }



            return done;
        }

        
    }
}
