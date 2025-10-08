using Obligatorio;
namespace InterfazVentas
{
    internal class Program
    {
        private static Sistema sistema = new Sistema();

        static void Main(string[] args)
        {
            int opc = -1;
            while (opc != 0)
            {
                MostrarMenu();
                Console.WriteLine("Seleccione una opción: ");
                int.TryParse(Console.ReadLine(), out opc);
                EvaluarOpcionSeleccionada(opc);
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("1 - Listado de clientes");
            Console.WriteLine("2 - Listar artículos por categoría");
            Console.WriteLine("3 - Dar de alta un artículo");
            Console.WriteLine("4 - Listar publicaciónes dadas dos fechas");
            Console.WriteLine("0 - Salir");
        }


        //Seleccionar opción 
        static void EvaluarOpcionSeleccionada(int opc)
        {
            switch (opc)
            {
                case 1:
                    ListadoDeClientes();
                    break;
                case 2:
                    ListadoDeArticulosPorCategoria();
                    break;
                case 3:
                    DarAltaDeArticulo();
                    break;
                case 4:
                    ListarPublicacionesEntreFechas();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }

        //RF1 - Listado de todos los clientes.
        static void ListadoDeClientes()
        {
            Console.Clear();
            foreach(Usuario usuario in sistema.ObtenerClientes())
            {
                Console.WriteLine(usuario);
            }

        }

        //RF2 - Dado un nombre de categoría listar todos los artículos de esa categoría.
        static void ListadoDeArticulosPorCategoria()
        {
            Console.Clear();
            Console.WriteLine("Escriba la categoría");
            string categoria = Console.ReadLine();
            foreach (Articulo articulo in sistema.ListaDeArticulosPorCategoria(categoria))
            {
                Console.WriteLine(articulo);
            }
        }

        //RF3 - Alta de artículo.
        static void DarAltaDeArticulo()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del artículo");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la categoría");
            string categoria = Console.ReadLine();
            Console.WriteLine("Ingrese el precio");
            double.TryParse(Console.ReadLine(), out double precio);
            sistema.AltaArticulo(nombre, categoria, precio);
            Console.WriteLine("Artículo añadido con éxito");

        }

        //RF4 - Dadas dos fechas, listar las publicaciones entre esas fechas. Mostrar Id, nombre estado y fecha de publicación.
        static void ListarPublicacionesEntreFechas()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la fecha de inicio (Formato YYYY-MM-DD)");
            DateTime fechaInicial = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de fin (Formato YYYY-MM-DD)");
            DateTime fechaFinal = DateTime.Parse(Console.ReadLine());
            foreach (Publicacion publicacion in sistema.ObtenerPublicacionesPorFecha(fechaInicial, fechaFinal))
            {
                Console.WriteLine(publicacion);
            }
        }

    }
}
