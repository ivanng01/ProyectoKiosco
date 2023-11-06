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
        public int _DineroAPagar { get; set; }
        public Usuario(string nombre, int edad, int dineroPagar)
        {
            this._Nombre = nombre;
            this._Edad = edad;
            this._DineroAPagar = dineroPagar;
        }
    }
}
