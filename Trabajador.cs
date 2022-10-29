using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica
{
    public class Trabajador
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
        public string tipo { get; set; }

        public Trabajador(int _id, string _nombre, string _password, string _tipo)
        {

            id = _id;
            nombre = _nombre;
            password = _password;
            tipo = _tipo;
        }



    }
}