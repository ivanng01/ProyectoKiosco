using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKiosco.Elementos
{
    public class Usuario
    {
        public string _Nombre { get; set; }
        public int _Edad { get; set; }
        public Usuario(string nombre, int edad)
        {
            this._Nombre = nombre;
            this._Edad = edad;
        }
    }
}
