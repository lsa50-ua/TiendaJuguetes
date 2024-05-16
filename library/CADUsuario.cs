using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class CADUsuario
    {
        private string constring;

        public CADUsuario()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool createUsuario(ENUsuario en)
        {
            bool usuario;
            try
            {
                SqlConnection connecion = new SqlConnection(constring);
                connecion.Open();
                SqlCommand crear = new SqlCommand("INSERT INTO [dbo].[Usuario](email, PIN, nombre, apellidos, DNI, telefono, calle, codPostal, provincia, administrador) VALUES ('" + en.EMAIL + "', '" + en.CONTRASENA + "', '" + en.NOMBRE + "', '" + en.APELLIDOS + "', '" + en.NIF +"',  '" + en.TELEFONO + "', '" + en.CALLE + "', '" + en.CODPOSTAL + "', '" + en.PROVINCIA + "', '" + false + "')", connecion);
                crear.ExecuteNonQuery();
                usuario = true;
                connecion.Close();
            }
            catch (SqlException e)
            {
                usuario = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                usuario = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            return usuario;

        }

        public bool modificarUsuario(ENUsuario en)
        {
            bool usuario;
            try
            {
                SqlConnection connecion = new SqlConnection(constring);
                connecion.Open();
                SqlCommand crear = new SqlCommand("UPDATE [dbo].[Usuario] SET email= '" + en.EMAIL + "', nombre='" + en.NOMBRE + "' ,apellidos='" + en.APELLIDOS + "' WHERE DNI = '" + en.NIF + "'", connecion);
                crear.ExecuteNonQuery();
                usuario = true;
                connecion.Close();
            }
            catch (SqlException e)
            {
                usuario = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                usuario = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            return usuario;
        }

        public bool readAllUsu(ENUsuario en)
        {
            bool usuario = false;
            try
            {
                SqlConnection connecion = new SqlConnection(constring);
                connecion.Open();
                SqlCommand leer = new SqlCommand("SELECT * FROM [dbo].[Usuario] WHERE email = '" + en.EMAIL + "'", connecion);
                SqlDataReader read = leer.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    if (read["email"].ToString() == en.EMAIL)
                    {
                        usuario = true;
                        
                        en.NOMBRE = read["nombre"].ToString();
                        en.APELLIDOS = read["apellidos"].ToString();
                        en.NIF = read["DNI"].ToString();
                        en.TELEFONO = int.Parse(read["telefono"].ToString());
                        
                        en.CONTRASENA = int.Parse(read["PIN"].ToString());
                        en.PROVINCIA = int.Parse(read["provincia"].ToString());
                        en.CALLE = read["calle"].ToString();
                        en.CODPOSTAL = int.Parse(read["codPostal"].ToString());
                        
                    }
                }
                read.Close();
                connecion.Close();
            }
            catch (SqlException e)
            {
                usuario = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                usuario = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            return usuario;
        }
        public bool readUsuarioDNI(ENUsuario en)
        {
            bool usuario = false;
            try
            {
                SqlConnection connecion = new SqlConnection(constring);
                connecion.Open();
                SqlCommand leer = new SqlCommand("SELECT * FROM [dbo].[Usuario] WHERE DNI = '" + en.NIF + "'", connecion);
                SqlDataReader read = leer.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    if (read["DNI"].ToString() == en.NIF)
                    {
                        usuario = true;
                    }
                }
                read.Close();
                connecion.Close();
            }
            catch (SqlException e)
            {
                usuario = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                usuario = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            return usuario;
        }

        public bool readUsuarioEmail(ENUsuario en)
        {
            bool usuario = false;
            try
            {
                SqlConnection connecion = new SqlConnection(constring);
                connecion.Open();
                SqlCommand leer = new SqlCommand("SELECT * FROM [dbo].[Usuario] WHERE email = '" + en.EMAIL + "'", connecion);
                SqlDataReader read = leer.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    if (read["email"].ToString() == en.EMAIL)
                    {
                        usuario = true;
                    }
                }
                read.Close();
                connecion.Close();
            }
            catch (SqlException e)
            {
                usuario = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                usuario = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            return usuario;
        }

        public bool readUsuarioAdmin(ENUsuario en)
        {
            bool usuario = false;
            try
            {
                SqlConnection connecion = new SqlConnection(constring);
                connecion.Open();
                SqlCommand leer = new SqlCommand("SELECT * FROM [dbo].[Usuario] WHERE email = '" + en.EMAIL + "'", connecion);
                SqlDataReader read = leer.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    if (read["nombre"].ToString() == "admin")
                    {
                        usuario = true;
                    }
                }
                read.Close();
                connecion.Close();
            }
            catch (SqlException e)
            {
                usuario = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                usuario = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            return usuario;
        }


        public bool deleteUsuario(ENUsuario en)
        {
            bool borrar = false;
            try
            {
                borrar = true;
                SqlConnection connecion = new SqlConnection(constring);
                connecion.Open();
                SqlCommand delete = new SqlCommand("DELETE FROM [dbo].[Usuarios] WHERE DNI = '" + en.NIF + "'");
                delete.ExecuteNonQuery();
                connecion.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            return borrar;
        }

        public bool validarUsuario(ENUsuario en)
        {
            bool validar = false;
            try
            {
                SqlConnection connecion = new SqlConnection(constring);
                connecion.Open();
                SqlCommand login = new SqlCommand("Select PIN from Usuario where email = '" + en.EMAIL +  "'", connecion);
                SqlDataReader dr = login.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if(en.CONTRASENA == int.Parse(dr["PIN"].ToString()))
                    {
                        validar = true;
                    }
                }
                dr.Close();
                connecion.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }

            return validar;
        }

        public bool registrarUsuario(ENUsuario en)
        {
            bool registrado = false;

            return registrado;
        }
    }
}
