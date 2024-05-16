using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENFactura
    {
        private string _usuario;
        private int _id;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public int Id {
            get { return _id; }
            set { _id = value; }
        }
        

        public ENFactura() {
            Id = 0;
            Usuario = "";
        }

        public bool addFactura() {
            CADFactura factura = new CADFactura();
            if(factura.addFactura(this)) {
                return true;
            }
            else return false;
        }

        public int getLastId() {
            CADFactura factura = new CADFactura();
            return factura.getLastId();
        }
    }
}
