using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENUsuario
    {
        private string email;
        private string nif;
        private string nombre;
        private string apellidos;
        private int contrasena;
        private string calle;
        private int provincia;
        private int codPostal;
        private int telefono;

        public string EMAIL
        {
            get { return email; }
            set { email = value; }
        }
        public string NIF
        {
            get { return nif; }
            set { nif = value; }
        }

        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string APELLIDOS
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        public string CALLE
        {
            get { return calle; }
            set { calle = value; }
        }

        public int CONTRASENA
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public int PROVINCIA
        {
            get { return provincia; }
            set { provincia = value; }
        }
        public int CODPOSTAL
        {
            get { return codPostal; }
            set { codPostal = value; }
        }
        public int TELEFONO
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public ENUsuario()
        {
            
            
        }

        public ENUsuario(string email, string nombre, string apellidos, string nif, int telefono, int contrasena, int provincia, string calle, int codPostal)
        {
            this.EMAIL = email;
            this.NOMBRE = nombre;
            this.APELLIDOS = apellidos;
            this.NIF = nif;
            this.TELEFONO = telefono;
            this.CONTRASENA = contrasena;
            this.PROVINCIA = provincia;
            this.CALLE = calle;
            this.CODPOSTAL = codPostal;
        }

        public bool createUsuario()
        {
            bool creado = false;
            CADUsuario ca = new CADUsuario();
            
            if (ca.readUsuarioDNI(this) == false && ca.readUsuarioEmail(this) == false)
            {
                creado = ca.createUsuario(this);
            }
            return creado;
        }

        public bool modificarUsuario()
        {
            bool usuario = false;
            bool leido = false;
            CADUsuario ca = new CADUsuario();
            leido = ca.modificarUsuario(this);
            if (leido == true)
            {
                usuario = true;
            }
            return usuario;
        }
        public bool deleteUsuario()
        {
            bool usuario = false;
            bool borrado = false;
            CADUsuario ca = new CADUsuario();
            borrado = ca.deleteUsuario(this);
            if (borrado == true)
            {
                usuario = true;
            }
            return usuario;
        }

        public bool readAllUsu()
        {
            bool usuario = false;
            bool leido = false;
            CADUsuario ca = new CADUsuario();
            leido = ca.readAllUsu(this);
            if (leido == true)
            {
                usuario = true;
            }
            return usuario;
        }
        public bool readUsuarioDNI()
        {
            bool usuario = false;
            bool leido = false;
            CADUsuario ca = new CADUsuario();
            leido = ca.readUsuarioDNI(this);
            if (leido == true)
            {
                usuario = true;
            }
            return usuario;
        }

        public bool readUsuarioEmail()
        {
            bool usuario = false;
            bool leido = false;
            CADUsuario ca = new CADUsuario();
            leido = ca.readUsuarioEmail(this);
            if (leido == true)
            {
                usuario = true;
            }
            return usuario;
        }

        public bool readUsuarioAdmin()
        {
            bool usuario = false;
            bool leido = false;
            CADUsuario ca = new CADUsuario();
            leido = ca.readUsuarioAdmin(this);
            if (leido == true)
            {
                usuario = true;
            }
            return usuario;
        }

        public bool validarUsuario()
        {
            CADUsuario u = new CADUsuario();
            bool validar = u.validarUsuario(this);
            return validar;
        }
        
    }
}
