using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENComunidad
    {

        private int _cod;

        private string _nombre;

        public int Cod {
            get{ return _cod; }
            set{ _cod = value; }
        }

        public string Nombre {
            get{ return _nombre; }
            set{ _nombre = value; }
        }


        public ENComunidad() {
            Cod = 1;
            Nombre = "";
        }

        public ENComunidad(int cod, string nombre){
            Cod = cod;
            Nombre = nombre;
        }

        public bool getComunidad() {
            CADComunidad comunidad = new CADComunidad();

            if(comunidad.getComunidad(this)) {
                return true;
            }
            return false;
        }
    }
}
