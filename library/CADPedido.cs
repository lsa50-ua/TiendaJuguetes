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
    public class CADPedido
    {
        private string constring;

        public CADPedido() {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool AgregarPedido(ENPedido en){
            bool done = true;
            SqlConnection conn = new SqlConnection(constring);
            string comando = "INSERT INTO [dbo].[Pedido] (numPedido, usuario, importe) VALUES (" + en.numPedido + ", '"
                + en.Usuario + "', " + en.Importe + ")";
            try {
                conn.Open();
                SqlCommand commando = new SqlCommand(comando, conn);
                commando.ExecuteNonQuery();
            } catch (SqlException e) {
                Console.WriteLine("Error. {0}", e.Message);
            }
            finally {
                conn.Close();
            }



            return done;
        }

        public int obtenerUltimo() {
            String comando = "SELECT numPedido FROM [dbo].[Pedido] ORDER BY numPedido DESC";
            SqlConnection conn = new SqlConnection(constring);
            try {
                conn.Open();
                SqlCommand command = new SqlCommand(comando, conn);
                SqlDataReader read = command.ExecuteReader();
                if(read.Read()) {
                    return int.Parse(read["numPedido"].ToString());
                }
            }
            catch (SqlException e){
                Console.WriteLine("Error {0}" + e.Message);
            }
            finally {
                conn.Close();
            }



            return 0;
        }
    }
}
