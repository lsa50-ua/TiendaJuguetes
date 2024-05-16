using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADComunidad
    {
        private string constring;
        public CADComunidad()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool getComunidad(ENComunidad comunidad) {
            bool done = true;

            String comando = "SELECT * FROM [dbo].[Comunidad] WHERE cod =" + comunidad.Cod;
            SqlConnection conn = null;

            try {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand command = new SqlCommand(comando, conn);
                SqlDataReader data = command.ExecuteReader();
                if(data.Read()) {
                    comunidad.Nombre = data["nombre"].ToString();
                }
                Console.WriteLine("Executed properly");
            }
            catch (SqlException e){
                done = false;
                Console.WriteLine("Error. {0}", e.Message);
            }
            finally{
                conn.Close();
            }

            return done;
        }
    }
}