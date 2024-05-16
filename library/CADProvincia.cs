using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace library
{
    public class CADProvincia
    {
        private string constring;
        public CADProvincia()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool getProvincia(ENProvincia en) {
            bool done = true;
            String comando = "Select * from [dbo].[Provincia] where cod= '" + en.Codp + "'";
            SqlConnection conn = null;

            try {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand command = new SqlCommand(comando, conn);
                SqlDataReader data = command.ExecuteReader();
                if(data.Read()) {
                    if(int.Parse(data["cod"].ToString()) == en.Codp) {
                        en.Comunidad = int.Parse(data["comunidad"].ToString());
                        en.Nombre = data["nombre"].ToString();
                    }
                }
                Console.WriteLine("Executed properly");
            } catch (SqlException sqlex) {
                done = false;
                Console.WriteLine("Requested operation failed. Error {0}", sqlex.Message);
            }
            finally {
                conn.Close();
            }

            return done;
        }
        public bool getProvinciaCod(ENProvincia en)
        {
            bool done = true;
            String comando = "Select * from [dbo].[Provincia] where nombre = '" + en.Nombre + "'";
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand command = new SqlCommand(comando, conn);
                SqlDataReader data = command.ExecuteReader();
                if (data.Read())
                {
                    if (data["nombre"].ToString() == en.Nombre)
                    {
                        en.Comunidad = int.Parse(data["comunidad"].ToString());
                        en.Codp = int.Parse(data["cod"].ToString());
                        
                    }
                }
                Console.WriteLine("Executed properly");
            }
            catch (SqlException sqlex)
            {
                done = false;
                Console.WriteLine("Requested operation failed. Error {0}", sqlex.Message);
            }
            finally
            {
                conn.Close();
            }

            return done;
        }
        public bool createProvincia(ENProvincia en){
            bool done = true;
            String comando = "INSERT INTO [dbo].[Provincia] (cod, comunidad, nombre) VALUES (" + en.Codp + ", " + en.Comunidad + ", '" + en.Nombre + "')";
            SqlConnection conn = null;

            try {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand command = new SqlCommand(comando, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Provincia added succesfully");
            } catch (SqlException sqlex) {
                done = false;
                Console.WriteLine("Error {0}", sqlex.Message);
            }
            finally {
                conn.Close();
            }

            return done;
        }
        public bool deleteProvincia(ENProvincia en){
            bool done = true;
            SqlConnection conn = null;
            string comando = "DELETE FROM [dbo].[Provincia] WHERE cod = " + en.Codp;

            try {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand command = new SqlCommand(comando, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Provincia deleted succesfully");
            } catch (SqlException sqlex) {
                done = false;
                Console.WriteLine("Error {0}", sqlex.Message);
            }
            finally {
                conn.Close();
            }


            return done;
        }

        public DataSet obtener()
        {
            SqlConnection conn = null;
            DataSet ds = new DataSet();
            string sentencia = "Select nombre, cod from Provincia order by nombre asc";
            try
            {
                conn = new SqlConnection(constring);
                SqlCommand command = new SqlCommand(sentencia, conn);
                SqlDataAdapter ad = new SqlDataAdapter(command);
                ad.Fill(ds);

            }catch (SqlException sqlex)
            {             
                Console.WriteLine("Requested operation failed. Error {0}", sqlex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
    }

    
}
