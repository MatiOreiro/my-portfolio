using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public class Venta:Publicacion
    {
        private bool _oferta;

        public Venta(string nombre, string estado, DateTime fechaPublicacion, List<Articulo> articulos, bool oferta) : base(nombre, estado, fechaPublicacion, articulos)
        {
            _oferta = oferta;
        }

        public override double CalcularPrecio()
        {
            double precio = 0;
            foreach (Articulo articulo in articulos)
            {
                precio += articulo.precio;
            }
            if (_oferta)
            {
                precio = precio - (precio * 0.2);
            }
            return precio;
        }
    }
}
