using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace library {
    public class CADCategoria {

        private string constring;

        public CADCategoria() {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }


        public bool getCategoria(ENCategoria en) {
            bool done = true;
            string comando = "SELECT * FROM [dbo].[Categoria] WHERE categoria=" + en.Categoria;
            SqlConnection conn = null; 
            try {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand command = new SqlCommand(comando, conn);
                SqlDataReader read = command.ExecuteReader();
                read.Read();
                if(int.Parse(read["categoria"].ToString()) == en.Categoria) {
                    en.NomCategoria = read["nombre"].ToString();
                }
            } catch (SqlException e) {
                done = false;
                Console.WriteLine("Error {0}", e.ToString());
            }
            finally {
                conn.Close();
            }

            return done;
        }

        public bool getCategoriaByName(ENCategoria en) {
            bool done = true;
            string comando = "SELECT * FROM [dbo].[Categoria] WHERE nombre='" + en.NomCategoria + "'";
            SqlConnection conn = null;
            try {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand command = new SqlCommand(comando, conn);
                SqlDataReader read = command.ExecuteReader();
                if(en.NomCategoria == read["nombre"].ToString()) {
                    en.Categoria = int.Parse(read["categoria"].ToString());
                }
            }
            catch(SqlException e) {
                done = false;
                Console.WriteLine("Error {0}", e.ToString());
            }
            finally {
                conn.Close();
            }

            return done;
        }


    }
}
