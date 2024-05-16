using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProvincia
    {
        private int _codp;
        public int Codp
        {
            get
            {
                return _codp;
            }
            set
            {
                _codp = value;
            }
        }

        private int _comunidad;

        public int Comunidad{
            get{ return _comunidad; }
            set { _comunidad = value; }
        }
            
            
            
        private string _nombre;
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        public ENProvincia()
        {
            Codp = 0;
            Comunidad = 0;
            Nombre = "";
        }

        public ENProvincia(int codp, int comunidad, string nombre)
        {
            Codp = codp;
            Comunidad = comunidad;
            Nombre = nombre;
        }

        public bool getProvincia() {
            CADProvincia provincia = new CADProvincia();

            if(provincia.getProvincia(this)) {
                return true;
            } return false;
        }
        public bool getProvinciaCod()
        {
            CADProvincia provincia = new CADProvincia();

            if (provincia.getProvincia(this))
            {
                return true;
            }
            return false;
        }

        public bool createProvincia(){
            CADProvincia provincia = new CADProvincia();

            if(provincia.createProvincia(this)) {
                return true;
            } return false;
        }
        public bool deleteProvincia(){
            CADProvincia provincia = new CADProvincia();

            if(provincia.deleteProvincia(this)) {
                return true;
            } return false;
        }

        public DataSet obtener()
        {
            CADProvincia p = new CADProvincia();
            DataSet ds = p.obtener();

            return ds;
        }

    }
}
