using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADFactura
    {
        private string constring;


        public CADFactura()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool addFactura(ENFactura en) {
            bool done = true;
            string comando = "INSERT INTO [dbo].[Factura] (id, usuario) VALUES (" + en.Id + ", '" + en.Usuario + "')";
            SqlConnection conn = new SqlConnection(constring);

            try {
                conn.Open();
                SqlCommand command = new SqlCommand(comando, conn);
                command.ExecuteNonQuery();
            } catch (SqlException e) {
                Console.WriteLine("Error. {0}", e.Message);
            }
            finally {
                conn.Close();
            }

            return done;
        }

        public int getLastId() {
            String comando = "SELECT id FROM [dbo].[Factura] ORDER BY id DESC";
            SqlConnection conn = new SqlConnection(constring);
            try {
                conn.Open();
                SqlCommand command = new SqlCommand(comando, conn);
                SqlDataReader read = command.ExecuteReader();
                if(read.Read()) {
                    return int.Parse(read["id"].ToString());
                }
            }
            catch(SqlException e) {
                Console.WriteLine("Error {0}" + e.Message);
            }
            finally {
                conn.Close();
            }

            return 0;
        }

    }
}

