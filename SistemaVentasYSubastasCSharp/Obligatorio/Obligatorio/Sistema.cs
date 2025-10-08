using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio
{
    public class Sistema
    {
        public List<Usuario> _usuarios = new List<Usuario>();

        public List<Publicacion> _publicaciones = new List<Publicacion>();

        public List<Articulo> _articulos = new List<Articulo>();

        private static Sistema _instancia;

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }

        public Sistema()
        {
            PrecargaDeUsuarios();
            PrecargaDeArticulos();
            PrecargaDePublicaciones();
            PrecargaDeOfertas();
        }

        //Métodos para precargar
        public void AltaCliente(string nombre, string apellido, string email, string password)
        {
            Cliente cliente = new Cliente(nombre, apellido, email, password);
            cliente.Validar();
            if (!_usuarios.Contains(cliente)){
                _usuarios.Add(cliente);
            }
            
        }

        private void AltaAdministrador(string nombre, string apellido, string email, string password)
        {
            Usuario administrador = new Usuario(nombre, apellido, email, password);
            administrador.Validar();
            _usuarios.Add(administrador);
        }

        private void AltaVenta(string nombre, string estado, DateTime fechaPublicacion, Articulo articulo, bool oferta)
        {
            List<Articulo> articulos = new List<Articulo>();
            articulos.Add(articulo);
            Venta venta = new Venta(nombre, estado, fechaPublicacion, articulos, oferta);
            //            venta.Validar();
            _publicaciones.Add(venta);
        }

        private void AltaSubasta(string nombre, string estado, DateTime fechaPublicacion, Articulo articulo)
        {
            List<Articulo> articulos = new List<Articulo>();
            articulos.Add(articulo);
            Subasta subasta = new Subasta(nombre, estado, fechaPublicacion, articulos);
            //            subasta.Validar();
            _publicaciones.Add(subasta);
        }
        public void AgregarOfertaASubasta(int idCliente, double monto, DateTime fecha, int idSubasta)
        {
            Subasta subasta = BuscarSubasta(idSubasta);
            Cliente cliente = BuscarCliente(idCliente);
            if (idCliente != null && idSubasta != null)
            {
                subasta.AltaOferta(cliente, monto, fecha);
            }
        }
        public void AgregarArticulosAPublicacion(int idPublicacion, string nombre, string categoria, double precio)
        {
            Publicacion publicacion = BuscarPublicacion(idPublicacion);
            if (idPublicacion != null)
            {
                publicacion.AltaArticulos(nombre, categoria, precio);
            }
        }

        public void AltaArticulo(string nombre, string categoria, double precio)
        {
            Articulo articulo = new Articulo(nombre, categoria, precio);
            articulo.Validar();
            if (!_articulos.Contains(articulo))
            {
                _articulos.Add(articulo);
            }
        }

        //Métodos para los controller
        public void InscribirCliente(Cliente cliente)
        {
            cliente.Validar();
            if (!_usuarios.Contains(cliente))
            {
                _usuarios.Add(cliente);
            }
            else
            {
                throw new Exception("El cliente ya existe");
            }
        }

        public void ComprarVenta(int idVenta, Cliente comprador)
        {
            Venta venta = BuscarVenta(idVenta);
            if (venta != null)
            {
                if (comprador.saldo >= venta.CalcularPrecio())
                {
                    comprador.saldo -= venta.CalcularPrecio();
                    venta.estado = "CERRADA";
                    venta.realizaCompra = comprador;
                    venta.fechaFinaliza = DateTime.Now;
                }
                else
                {
                    throw new Exception("Saldo insuficiente");
                }

            }
        }

        public void CerrarSubasta(int idSubasta, Cliente mejorOfertante)
        {
            Subasta subasta = BuscarSubasta(idSubasta);
            if (subasta != null)
            {
                if (mejorOfertante.saldo >= subasta.OfertaMasAlta().monto)
                {
                    mejorOfertante.saldo -= subasta.OfertaMasAlta().monto;
                    subasta.estado = "CERRADA";
                    subasta.finalizaCompra = mejorOfertante;
                    subasta.fechaFinaliza = DateTime.Now;
                }
                else
                {
                    throw new Exception("Saldo insuficiente");
                }
            }
        }

        //Métodos para buscar en las clases
        public Subasta BuscarSubasta(int idSubasta)
        {
            Subasta subasta = null;
            int i = 0;
            while(i<_publicaciones.Count && subasta == null)
            {
                if (_publicaciones[i].id == idSubasta && _publicaciones[i] is Subasta)
                {
                    subasta = (Subasta) _publicaciones[i];
                }
                i++;
            }
            return subasta;
        }

        public Venta BuscarVenta(int idVenta)
        {
            Venta venta = null;
            int i = 0;
            while (i < _publicaciones.Count && venta == null)
            {
                if (_publicaciones[i].id == idVenta && _publicaciones[i] is Venta)
                {
                    venta = (Venta)_publicaciones[i];
                }
                i++;
            }
            return venta;
        }

        public Articulo BuscarArticulo(int idArticulo)
        {
            Articulo articulo = null;
            int i = 0;
            while (i < _articulos.Count && articulo == null)
            {
                if (_articulos[i].id == idArticulo)
                {
                    articulo = _articulos[i];
                }
                i++;
            }
            return articulo;
        }

        public Cliente BuscarCliente(int idCliente)
        {
            Cliente cliente = null;
            int i = 0;
            while (i < _usuarios.Count && cliente == null)
            {
                if (_usuarios[i].id == idCliente && _usuarios[i] is Cliente)
                {
                    cliente = (Cliente)_usuarios[i];
                }
                i++;
            }
            return cliente;
        }

        public Cliente BuscarClientePorEmail(string email)
        {
            Cliente cliente = null;
            int i = 0;
            while (i < _usuarios.Count && cliente == null)
            {
                if (_usuarios[i].email == email && _usuarios[i] is Cliente)
                {
                    cliente = (Cliente)_usuarios[i];
                }
                i++;
            }
            return cliente;
        }

            public Usuario BuscarUsuarioParaLogin(string email, string password)
        {
            Usuario usuario = null;
            int i = 0;
            while (i < _usuarios.Count && usuario == null)
            {
                if (_usuarios[i].email == email && _usuarios[i].password == password)
                {
                    usuario = _usuarios[i];
                }
                i++;
            }
            return usuario;
        }


        public Publicacion BuscarPublicacion(int idPublicacion)
        {
            Publicacion publicacion = null;
            int i = 0;
            while (i < _publicaciones.Count && publicacion == null)
            {
                if (_publicaciones[i].id == idPublicacion)
                {
                    publicacion = _publicaciones[i];
                }
                i++;
            }
            return publicacion;
        }

        //Métodos para devolver listas
        public List<Publicacion> ObtenerPublicaciones()
        {
            return _publicaciones;
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente> ();
            int i = 0;
            while (i < _usuarios.Count)
            {
                if (_usuarios[i] is Cliente)
                {
                    clientes.Add((Cliente)_usuarios[i]);
                }
                i++;
            }
            return clientes;
        }

        public List<Articulo> ListaDeArticulosPorCategoria(string categoria)
        {
            List<Articulo> articulos = new List<Articulo> ();
            int i = 0;
            while (i < _articulos.Count && !string.IsNullOrEmpty(categoria))
            {
                if (_articulos[i].categoria.ToUpper().Trim() == categoria.ToUpper().Trim())
                {
                    articulos.Add(_articulos[i]);
                }
                i++;
            }
            return articulos;
        }

        public List<Publicacion> ObtenerPublicacionesPorFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            int i = 0;
            while (i < _publicaciones.Count)
            {
                if (_publicaciones[i].fecha >= fechaInicio && _publicaciones[i].fecha <= fechaFinal)
                {
                    publicaciones.Add(_publicaciones[i]);
                }
                i++;
            }
            return publicaciones;
        }

        public List<Subasta> ObtenerSubastasOrdenadasPorFecha()
        {
            List<Subasta> subastas = new List<Subasta>();
            int i = 0;
            while (i < _publicaciones.Count)
            {
                if (_publicaciones[i] is Subasta)
                {
                    subastas.Add((Subasta)_publicaciones[i]);
                }
                i++;
            }
            subastas.Sort();
            return subastas;
        }



        //Precarga de todos los datos separados por tipo
        private void PrecargaDeUsuarios()
        {
            AltaCliente("Juan", "Pérez", "juan.perez@example.com", "contrasena123");
            AltaCliente("Ana", "Gómez", "ana.gomez@example.com", "contrasena456");
            AltaCliente("Carlos", "Fernández", "carlos.fernandez@example.com", "contrasena789");
            AltaCliente("Laura", "Martínez", "laura.martinez@example.com", "laura2023");
            AltaCliente("Javier", "López", "javier.lopez@example.com", "javier2023");
            AltaCliente("Marta", "Rodríguez", "marta.rodriguez@example.com", "marta1234");
            AltaCliente("José", "Torres", "jose.torres@example.com", "jose5678");
            AltaCliente("Sofia", "Díaz", "sofia.diaz@example.com", "sofia910");
            AltaCliente("Luis", "Morales", "luis.morales@example.com", "luis1111");
            AltaCliente("Patricia", "Jiménez", "patricia.jimenez@example.com", "patricia2222");
            AltaAdministrador("Ricardo", "Alvarez", "ricardo.alvarez@example.com", "ricardo3333");
            AltaAdministrador("Elena", "Sánchez", "elena.sanchez@example.com", "elena4444");
        }

        private void PrecargaDeArticulos()
        {
            AltaArticulo("Vestido de verano", "Ropa", 85.60);
            AltaArticulo("Collar de perlas", "Joyería", 200.00);
            AltaArticulo("Botas de cuero", "Calzado", 120.90);
            AltaArticulo("Lampara LED", "Hogar", 95.00);
            AltaArticulo("Bicicleta de montaña", "Deportes", 550.00);
            AltaArticulo("Crema hidratante", "Belleza", 70.00);
            AltaArticulo("Set de herramientas", "Jardinería", 45.20);
            AltaArticulo("Gorro de invierno", "Accesorios", 33.80);
            AltaArticulo("Laptop Ultra Book", "Electrónica", 1200.40);
            AltaArticulo("Pantalones jeans", "Ropa", 55.25); //10
            AltaArticulo("Pulsera de acero", "Joyería", 95.60);
            AltaArticulo("Sandalias veraniegas", "Calzado", 65.70);
            AltaArticulo("Juego de toallas", "Hogar", 150.90);
            AltaArticulo("Raqueta de tenis", "Deportes", 85.00);
            AltaArticulo("Maquillaje compacto", "Belleza", 45.50);
            AltaArticulo("Pantalones jeans", "Ropa", 55.25);
            AltaArticulo("Pantalones jeans", "Ropa", 55.25);
            AltaArticulo("Pantalones jeans", "Ropa", 55.25);
            AltaArticulo("Pantalones jeans", "Ropa", 55.25);
            AltaArticulo("Pantalones jeans", "Ropa", 55.25); //20
            AltaArticulo("Maquillaje compacto", "Belleza", 45.50);
            AltaArticulo("Kit de jardinería", "Jardinería", 70.00);
            AltaArticulo("Bolso de mano", "Accesorios", 27.30);
            AltaArticulo("Altavoz Bluetooth", "Electrónica", 400.00);
            AltaArticulo("Chaqueta de invierno", "Ropa", 75.30);
            AltaArticulo("Aretes de oro", "Joyería", 150.00);
            AltaArticulo("Sneakers de moda", "Calzado", 90.40);
            AltaArticulo("Cuadro decorativo", "Hogar", 60.50);
            AltaArticulo("Set de pesas", "Deportes", 110.00);
            AltaArticulo("Gel exfoliante", "Belleza", 55.90); //30
            AltaArticulo("Fertilizante orgánico", "Jardinería", 40.00);
            AltaArticulo("Cinturón de cuero", "Accesorios", 22.90);
            AltaArticulo("Monitor 24”", "Electrónica", 300.00);
            AltaArticulo("Falda larga", "Ropa", 30.00);
            AltaArticulo("Broche de cristal", "Joyería", 85.60);
            AltaArticulo("Chanclas de playa", "Calzado", 95.80);
            AltaArticulo("Manta suave", "Hogar", 210.50);
            AltaArticulo("Kit de yoga", "Deportes", 75.10);
            AltaArticulo("Mascarilla facial", "Belleza", 35.00);
            AltaArticulo("Set de semillas", "Jardinería", 50.40); //40
            AltaArticulo("Reloj de pulsera", "Accesorios", 60.70);
            AltaArticulo("Proyector portátil", "Electrónica", 500.00);
            AltaArticulo("Pijama de seda", "Ropa", 45.00);
            AltaArticulo("Pulsera de cuero", "Joyería", 160.00);
            AltaArticulo("Botines de gamuza", "Calzado", 80.50);
            AltaArticulo("Mesa de café", "Hogar", 95.00);
            AltaArticulo("Smartphone X10", "Electrónica", 300.20);
            AltaArticulo("Camiseta de algodón", "Ropa", 25.50);
            AltaArticulo("Anillo de plata", "Joyería", 120.75);
            AltaArticulo("Zapatillas deportivas", "Calzado", 75.90); //50
        }

        private void PrecargaDePublicaciones()
        {
            AltaVenta("Venta 1", "ABIERTA", new DateTime(2024, 10, 08), BuscarArticulo(3), false);
            AltaVenta("Venta 2", "ABIERTA", new DateTime(2023, 05, 18), BuscarArticulo(7), true);
            AltaVenta("Venta 3", "ABIERTA", new DateTime(2021, 01, 07), BuscarArticulo(21), false);
            AltaVenta("Venta 4", "ABIERTA", new DateTime(2022, 09, 09), BuscarArticulo(17), false);
            AltaVenta("Venta 5", "ABIERTA", new DateTime(2023, 12, 03), BuscarArticulo(41), false);
            AltaVenta("Venta 6", "ABIERTA", new DateTime(2022, 02, 01), BuscarArticulo(44), false);
            AltaVenta("Venta 7", "ABIERTA", new DateTime(2023, 04, 29), BuscarArticulo(7), false);
            AltaVenta("Venta 8", "ABIERTA", new DateTime(2021, 01, 23), BuscarArticulo(2), true);
            AltaVenta("Venta 9", "ABIERTA", new DateTime(2020, 04, 28), BuscarArticulo(13), false);
            AltaVenta("Venta 10", "ABIERTA", new DateTime(2019, 09, 18), BuscarArticulo(33), false);
            AltaSubasta("Subasta 1", "ABIERTA", new DateTime(2017, 07, 07), BuscarArticulo(5));
            AltaSubasta("Subasta 2", "ABIERTA", new DateTime(2020, 11, 07), BuscarArticulo(45));
            AltaSubasta("Subasta 3", "ABIERTA", new DateTime(2023, 06, 06), BuscarArticulo(14));
            AltaSubasta("Subasta 4", "ABIERTA", new DateTime(2024, 02, 08), BuscarArticulo(22));
            AltaSubasta("Subasta 5", "ABIERTA", new DateTime(2024, 11, 09), BuscarArticulo(48));
            AltaSubasta("Subasta 6", "ABIERTA", new DateTime(2023, 12, 11), BuscarArticulo(37));
            AltaSubasta("Subasta 7", "ABIERTA", new DateTime(2024, 02, 01), BuscarArticulo(32));
            AltaSubasta("Subasta 8", "ABIERTA", new DateTime(2022, 03, 22), BuscarArticulo(12));
            AltaSubasta("Subasta 9", "ABIERTA", new DateTime(2024, 05, 08), BuscarArticulo(35));
            AltaSubasta("Subasta 10", "ABIERTA", new DateTime(2024, 10, 18), BuscarArticulo(36));
        }

        private void PrecargaDeOfertas()
        {
            AgregarOfertaASubasta(1, 10, new DateTime(2024, 10, 08), 11);
            AgregarOfertaASubasta(3, 44, new DateTime(2024, 07, 18), 15);
        }
    }
}
