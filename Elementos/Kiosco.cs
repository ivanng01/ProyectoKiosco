using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKiosco.Elementos
{
    public class Kiosco
    {

        public List<Productos> _productos = new List<Productos>();
        public List<string> _productosVendidos = new List<string>();
        private object _lock = new object();
        private bool _Veda = false;
        private int CajaInicial;
        private int TotalRecaudado = 0;
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
        public int InicializarCaja(int IniciarCaja)
        {
            CajaInicial = IniciarCaja;
            return CajaInicial;
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
                Console.WriteLine("VEDA ELECTORAL - ¡PROHIBIDO VENDER PRODUCTOS!");
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

            double vuelto = 0;
            if (user._DineroAPagar < (pVenta._Precio*cant))
            {
                Console.WriteLine($"Cliente {user._Nombre} no tiene suficiente dinero para comprar {cant} Producto {pVenta._Nombre}");
                return;
            }
            if (user._DineroAPagar >= (pVenta._Precio * cant))
            {
                lock (_lock)
                {
                    pVenta._Stock -= cant;
                }
                vuelto = user._DineroAPagar - (pVenta._Precio * cant);
                Console.WriteLine($"Cliente {user._Nombre} Compro {cant} Producto {pVenta._Nombre} | PagaCon: ${user._DineroAPagar} | Total: ${pVenta._Precio * cant} | Vuelto: ${vuelto}");
                TotalRecaudado = TotalRecaudado + ((int)(pVenta._Precio * cant));
                _productosVendidos.Add(pVenta._Nombre + "          " + cant);
                return;
            }
        }
        public int totalRecaudado () 
        {
            Console.WriteLine();
            return TotalRecaudado + CajaInicial;
        }

        public void VedaElectoral(bool enVeda)
        {
            _Veda = enVeda;
        }

        public void ListadoProductosEnKiosco()
        {
            Console.WriteLine("STOCK ACTUAL PRODUCTOS EN KIOSCO");
            Console.WriteLine($"PRODUCTO      CANTIDAD");
            foreach (var productos in _productos)
            {
                Console.WriteLine($"{productos._Nombre}              {productos._Stock}");
            }
        }

        public void ListadoProductosVendidos()
        {
            Console.WriteLine("PRODUCTOS VENDIDOS");
            Console.WriteLine($"PRODUCTO  -  CANTIDAD");

            foreach (var prodVendidos in _productosVendidos)
            {
                Console.WriteLine($"{prodVendidos}");
            }
        }
    }
}
