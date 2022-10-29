using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica
{
    public class Producto
    {

        int id { get; set; }
        public int cantidad { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string sede { get; set; }


        public Producto(int _id)
        {
            id = _id;
            nombre = "";
            precio = 0;
            cantidad = 0;
            sede = "";


        }

    }
}