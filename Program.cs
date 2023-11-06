using ProyectoKiosco.Elementos;

Kiosco proyKiosco = Kiosco.Instance;

Console.WriteLine("DINERO EN CAJA INICIAL: " + proyKiosco.InicializarCaja(1000));
Console.WriteLine();

Usuario user1 = new Usuario("Rodrigo",21,3600);
Usuario user2 = new Usuario("Juan Ignacio",17,1000);
Usuario user3 = new Usuario("Agustina", 31,1200);
Usuario user4 = new Usuario("Pablo",31,900);
Usuario user5 = new Usuario("Victoria",17,400);

Productos prod1 = new Productos(1, "Fresh", 700, 10, true, false);
Productos prod2 = new Productos(2, "Corona", 900, 20, false, false);
Productos prod3 = new Productos(3, "Philip morris", 900, 20, false, false);
Productos prod4 = new Productos(4, "Oreo", 400, 10, true, false);
Productos prod5 = new Productos(5, "Turron", 100, 4, true, false);

proyKiosco.AñadirProducto(prod1);
proyKiosco.AñadirProducto(prod2);
proyKiosco.AñadirProducto(prod3);
proyKiosco.AñadirProducto(prod4);
proyKiosco.AñadirProducto(prod5);

proyKiosco.ListadoProductosEnKiosco();
Console.WriteLine();

var act = new List<Task>();
act.Add(Task.Run(() => proyKiosco.VenderProducto(prod1, user1, 5)));
act.Add(Task.Run(() => proyKiosco.VenderProducto(prod2, user2, 1)));
act.Add(Task.Run(() => proyKiosco.VenderProducto(prod3, user3, 2)));
act.Add(Task.Run(() => proyKiosco.VenderProducto(prod4, user4, 2)));
act.Add(Task.Run(() => proyKiosco.VenderProducto(prod5, user5, 4)));


Task.WhenAll(act).Wait();

Console.WriteLine("TOTAL RECAUDADO: "+proyKiosco.totalRecaudado());
Console.WriteLine();

proyKiosco.ListadoProductosVendidos();
Console.WriteLine();
Console.WriteLine();
proyKiosco.ListadoProductosEnKiosco();