using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoKiosco.Elementos
{
    public class Productos
    {
        public int _Id;
        public string _Nombre;
        public double _Precio;
        public int _Stock;
        public bool _PermitidoAMenores;
        public bool _PoseeAlcohol;
        
        public Productos(int id, string nombre, double precio, int stock, bool permitidoAMenores, bool poseeAlcohol)
        {
            _Id = id;
            _Nombre = nombre;
            _Precio = precio;
            _Stock = stock;
            _PermitidoAMenores = permitidoAMenores;
            _PoseeAlcohol = poseeAlcohol;
        }
    }
}

