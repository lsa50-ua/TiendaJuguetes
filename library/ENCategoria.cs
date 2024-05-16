using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library {
    public class ENCategoria {

        private int _categoria;

        public int Categoria {
            get {
                return _categoria;
            }
            set {
                _categoria = value;
            }
        }

        private string _nomCategoria;

        public string NomCategoria {
            get {
                return _nomCategoria;
            }
            set {
                _nomCategoria = value;
            }
        }



        public ENCategoria() {
            Categoria = 0;
            NomCategoria = "";
        }

        public ENCategoria(int categoria, string nomCategoria) {
            Categoria = categoria;
            NomCategoria = nomCategoria;
        }

        public bool getCategoria() {
            CADCategoria categoria = new CADCategoria();
            if(categoria.getCategoria(this)) {
                return true;
            }
            return false;
        }

        public bool getCategoriaByName() {
            CADCategoria categoria = new CADCategoria();
            if(categoria.getCategoriaByName(this)) {
                return true;
            }
            return false;
        }


    }
}
