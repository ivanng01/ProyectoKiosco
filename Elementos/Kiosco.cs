using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKiosco.Elementos
{
    public class Kiosco
    {

        public List<Productos> _productos = new List<Productos>();
        private object _lock = new object();
        private bool _Veda = false;
        private readonly static Kiosco _instance = new Kiosco();

        private Kiosco()
        {
        }

        public static Kiosco Instance
        {
            get
            {
                return _instance;
            }
        }

        public void AñadirProducto(Productos newProd)
        {

            lock (_lock)
            {
                _productos.Add(newProd);
            }
        }
        public void VenderProducto(Productos pVenta, Usuario user, int cant)
        {
            
            if (this._Veda)
            {
                Console.WriteLine("VEDA ELECTORAL - ¡Prohibido vender Productos!");
                return;
            }

            if (pVenta._PoseeAlcohol && this._Veda)
            {
                Console.WriteLine($"Cliente {user._Nombre} desea comprar {cant} Producto {pVenta._Nombre} ¡ADVERTENCIA VEDA!");
                return;
            }

            if (pVenta._Stock < cant)
            {
                Console.WriteLine($"Cliente {user._Nombre} desea comprar {cant} Producto {pVenta._Nombre} pero no hay suficiente stock");
                return;
            }

            if (!pVenta._PermitidoAMenores && user._Edad < 18)
            {
                Console.WriteLine($"Cliente {user._Nombre} es menor, no puede comprar {cant} Producto {pVenta._Nombre}");
                return;
            }

            lock (_lock)
            {
                pVenta._Stock -= cant;
            }
            Console.WriteLine($"Cliente {user._Nombre} ha comprado {cant} Producto {pVenta._Nombre} ");
        }
        public void VedaElectoral(bool enVeda)
        {
            _Veda = enVeda;
        }

        public void ListadoProductosEnKiosco()
        {

            Console.WriteLine("Stock Actual de Productos en Kiosco");
            Console.WriteLine($"Producto          Cantidad");
            foreach (var productos in _productos)
            {
                Console.WriteLine($"{productos._Nombre}        {productos._Stock}");
            }
        }
    }
}
