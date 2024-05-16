using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENPedido
    {
        private int _numPedido, _importe;
        private string _usuario;

        public int numPedido
        {
            get
            {
                return _numPedido;
            }
            set
            {
                _numPedido = value;
            }
        }

        public int Importe {
            get { return _importe; }
            set { _importe = value; }
        }

        public string Usuario {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public ENPedido() {
            numPedido = 0;
            Importe = 0;
            Usuario = "";
        }

        public bool AgregarPedido(){
            bool done = true;
            CADPedido pedido = new CADPedido();

            if(pedido.AgregarPedido(this)) {
                done = true;
            }
            else done = false;


            return done;
        }

        public int obtenerUltimo() {
            CADPedido pedido = new CADPedido();
            return pedido.obtenerUltimo();
        }

    }
}
