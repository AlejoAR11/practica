using System;
using System.Collections.Generic;

namespace Practica
{
    class Program
    {
        public static void Main(string[] args)
        {


            static void Facturas(List<Producto> bill, Trabajador x, double total)
            {

                Console.WriteLine("Facturas \n");

                foreach (Producto item in bill)
                {
                    Console.WriteLine("nombre.  precio.  cantidad.");
                    Console.WriteLine(item.nombre + "   " + item.precio + "  " + item.cantidad);



                }
                Console.WriteLine("total" + total);

            }

            static void VenderProd(List<Producto> _producto, Trabajador x)
            {

                string produc = "";
                double total = 0;
                int cont = 0, otra = 0;
                bool stock = false, fin = false;

                do
                {
                    Console.WriteLine("Vender producto. \n");

                    Inventario(_producto, x);
                    Console.WriteLine("\n");
                    Console.WriteLine("Ingrese el nombre del producto a vender:  \n");
                    produc = Console.ReadLine();
                    do
                    {
                        foreach (Producto sell in _producto)
                        {
                            if (produc == sell.nombre)
                            {
                                stock = true;
                                Console.WriteLine("¿Qué cantidad quiere vender?\n");
                                cont = int.Parse(Console.ReadLine());

                                if (cont <= sell.cantidad)
                                {
                                    total = 0;

                                    Random fact = new Random();
                                    int factura = fact.Next(1000, 9999);

                                    Producto v1 = new Producto(factura);
                                    v1.nombre = sell.nombre;
                                    v1.cantidad = sell.cantidad;
                                    v1.precio = sell.precio * cont;

                                    total += v1.precio;

                                    sell.cantidad -= cont;

                                    

                                    Console.WriteLine("Si quiere vender nuevamente precione 1.");
                                    otra = int.Parse(Console.ReadLine());
                                    if (otra != 1) { fin = true; }


                                }
                                else
                                {
                                    Console.WriteLine("La cantidad ingresada no está disponible \n");
                                }


                            }
                            else
                            {
                                Console.WriteLine("El producto no se encuentra. Para intenter nuevamente precione 1.");
                                otra = int.Parse(Console.ReadLine());
                                if (otra != 1) { fin = true; }

                            }


                        }

                    } while (otra == 1);






                } while (fin == false);



            }

            static void Inventario(List<Producto> _producto, Trabajador x)
            {
                Console.WriteLine(" Inventario  \n");
                Console.WriteLine("\n \nNombre  Precio  Cantidad  Sede");
                foreach (Producto f in _producto)
                {

                    Console.WriteLine(f.nombre + "  " + f.precio + "    " + f.cantidad + "  " + f.sede);

                }

            }

            static void EditarInv(List<Producto> _producto, Trabajador x)
            {
                bool fin = false;
                int opt = 0, id = 0;
                Random n = new Random();
                id = n.Next(1000, 9999);


                do
                {
                    Console.WriteLine("Control de inventario \n 1. Crear nuevo producto. \n 2. Mostrar productos existentes." +
                     "3. Modificar un producto. \n 4. Eliminar un producto. \n 5. salir.");
                    opt = int.Parse(Console.ReadLine());

                    switch (opt)
                    {

                        case 1:


                            Producto prod = new Producto(id);

                            Console.WriteLine("Crear un producto: \n");

                            Console.WriteLine("Ingrese el nombre del producto: ");
                            prod.nombre = Console.ReadLine();

                            Console.WriteLine("Ingrese el precio del producto: ");
                            prod.precio = double.Parse(Console.ReadLine());

                            Console.WriteLine("Ingrese La cantidad a agregar del producto: ");
                            prod.cantidad = int.Parse(Console.ReadLine());

                            Console.WriteLine("Ingrese la sede a la que irá el producto: ");
                            prod.sede = Console.ReadLine();

                            _producto.Add(prod);

                            Console.WriteLine("Producto agregado correctamente.");

                            break;

                        case 2:

                            Inventario(_producto, x);

                            break;
                        case 3:

                            string nombre = "";
                            bool stock = false;

                            Console.WriteLine("Modificar un producto: \n");

                            Console.WriteLine("Ingrese el nombre del producto que quiere modificar: ");
                            nombre = Console.ReadLine();

                            foreach (Producto pro in _producto)
                            {
                                if (nombre == pro.nombre)
                                {

                                    stock = true;
                                    int opc = 0;
                                    string name = "";
                                    double valor = 0;
                                    int cant = 0;
                                    string local = "";

                                    Console.WriteLine("Seleccione el dato a modificar \n " +
                                    "1. Nombre. \n 2. Precio. \n 3. Cantidad. \n 4. Sede. \n 5. salir");
                                    opc = int.Parse(Console.ReadLine());

                                    switch (opc)
                                    {

                                        case 1:
                                            Console.WriteLine("Modificar nombre: \n");
                                            name = Console.ReadLine();
                                            pro.nombre = name;
                                            break;

                                        case 2:
                                            Console.WriteLine("Modificar precio: \n");
                                            valor = double.Parse(Console.ReadLine());
                                            pro.precio = valor;
                                            break;

                                        case 3:
                                            Console.WriteLine("Modificar cantidad: \n");
                                            cant = int.Parse(Console.ReadLine());
                                            pro.cantidad = cant;
                                            break;

                                        case 4:
                                            Console.WriteLine("Modificar la sede: \n");
                                            local = Console.ReadLine();
                                            pro.sede = local;
                                            break;
                                        case 5:
                                            fin = true;
                                            break;

                                        default:
                                            Console.WriteLine("¿? MMmmno \n");
                                            break;

                                    }
                                    Console.WriteLine("Producto modificado correctamente. \n");

                                }

                                if (stock != true)
                                {
                                    Console.WriteLine("El producto no existe \n");

                                }

                            }

                            stock = false;

                            break;
                        case 4:
                            string nom = "";
                            bool supply = false;

                            Console.WriteLine("Eliminar producto: \n");
                            Console.WriteLine("Ingrese el nombre del producto a eliminar: \n");
                            nom = Console.ReadLine();

                            foreach (Producto del in _producto)
                            {

                                if (nom == del.nombre)
                                {
                                    supply = true;
                                    _producto.Remove(del);
                                    Console.WriteLine("Producto eliminado correctamente \n");
                                }
                                if (supply != true)
                                {

                                    Console.WriteLine("El producto no existe \n");
                                }

                                supply = false;
                            }


                            break;
                        case 5:
                            Console.WriteLine("Modificaciones en el inventario han terminado. \n");
                            fin = true;
                            break;

                        default:
                            Console.WriteLine("¿?Mmnn No \n");
                            break;
                    }

                } while (fin == false);


            }

            static void Menus(List<Producto> _producto, Trabajador x)
            {
                bool fin = false;
                int o = 0;

                if (x.tipo == "administrador")
                {
                    do
                    {

                        Console.WriteLine("\n\n Menu ADMINISTRADOR: \n 1. editar inventario \n 2. Vender producto. \n 3. Salir. \n");
                        o = int.Parse(Console.ReadLine());


                        switch (o)
                        {

                            case 1:
                                EditarInv(_producto, x);
                                break;

                            case 2:
                                VenderProd(_producto, x);

                                break;
                            case 3:
                                fin = true;
                                break;
                            default:
                                Console.WriteLine("¿? Mmno.\n");
                                break;

                        }


                    } while (fin == false);

                }
                else if (x.tipo != "administrador")
                {

                    Console.WriteLine("Menu EMPLEADOS\n 1. Ver Productos. \n 2. Salir.");
                    o = int.Parse(Console.ReadLine());
                    switch (o)
                    {
                        case 1:
                            Inventario(_producto, x);
                            break;

                        case 2:
                            fin = true;
                            break;
                        default:
                            Console.WriteLine("¿? Mmno.\n");
                            break;

                    }



                }

            }

            //Listas a usar
            List<Producto> _producto = new List<Producto>();
            List<Trabajador> personal = new List<Trabajador>();
           List<Producto> bill = new List<Producto>();
            // Controles para el menu
            bool salir = false;
            int op = 0;
            //menu
            do
            {

                Console.WriteLine("1. Iniciar sesión. \n 2. Registrarse. \n 3. Salir.\n");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {

                    case 1:

                        int doc;
                        string contra;

                        Console.WriteLine("Ingrese su documento.\n");
                        doc = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese una contraseña.\n");
                        contra = Console.ReadLine();

                        foreach (Trabajador x in personal)
                        {

                            if (x.id == doc && x.password == contra)
                            {
                                Console.Clear();
                                Console.WriteLine("Bienvenido " + x.nombre + " :).");
                                Menus(_producto, x);


                            }
                            else
                            {
                                Console.WriteLine("Usuario no encontrado:(");

                            }
                        }

                        break;

                    case 2:

                        int id = 0;
                        string name = "", pass = "", rol = "";

                        Console.WriteLine("Registro.\n");

                        Console.WriteLine("Ingrese su nombre.\n");
                        name = Console.ReadLine();

                        Console.WriteLine("Ingrese su documento.\n");
                        id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese una contraseña.\n");
                        pass = Console.ReadLine();

                        Console.WriteLine("Ingrese el tipo de usuario.\n Empleado / Administrador / Distribuidor. \n");
                        rol = Console.ReadLine();
                        string temp = rol.ToLower();
                        rol = temp;

                        personal.Add(new Trabajador(id, name, pass, rol));

                        Console.WriteLine("Usuario registrado correctamente.");

                        break;
                    case 3:
                        Console.WriteLine("Hasta la luego.\n");
                        salir = true;

                        break;
                    default:
                        Console.WriteLine("¿? Mmno.\n");
                        break;

                }

            } while (salir == false);

        }
    }
}