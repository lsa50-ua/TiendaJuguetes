using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENLinped
    {
        private int _linea, _pedido, _articulo, _cantidad;
        public int Linea{
            get{ return _linea;}
            set { _linea = value; }
        }

        public int Pedido {
            get { return _pedido; }
            set { _pedido = value; }
        }

        public int Articulo {
            get { return _articulo; }
            set { _articulo = value; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public ENLinped() {
            Linea = 0;
            Pedido = 0;
            Articulo = 0;
            Cantidad = 0;
        }

        public ENLinped(int lin, int ped, int art, int im, int cant){
            Linea = lin;
            Pedido = ped;
            Articulo = art;
            Cantidad = cant;
        }

        public bool agregarLinea() {
            CADLinped linea = new CADLinped();

            if(linea.agregarLinea(this)) {
                return true;
            }
            else return false;
        }
    }
}
