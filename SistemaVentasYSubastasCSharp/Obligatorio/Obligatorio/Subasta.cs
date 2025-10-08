using Obligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public class Subasta:Publicacion
    {
        private List<Oferta> _ofertas=new List<Oferta>();

        public List<Oferta> ofertas
        {
            get { return _ofertas; }
        }

        public Subasta(string nombre, string estado, DateTime fechaPublicacion, List<Articulo> articulos) : base (nombre, estado, fechaPublicacion, articulos)
        {

        }

        public void AltaOferta(Cliente cliente, double monto, DateTime fecha)
        {
            Oferta oferta = new Oferta(cliente, monto, fecha);
            if (!_ofertas.Contains(oferta))
            {
                _ofertas.Add(oferta);
            }
        }

        public Oferta OfertaMasAlta()
        {
            Oferta ofertaAlta = null;
            foreach (Oferta oferta in _ofertas)
            {
                if (oferta.monto == _ofertas.Max(o => o.monto) && oferta.monto > 0)
                {
                    ofertaAlta = oferta;
                }
            }
            return ofertaAlta;
        }

        public double MontoOfertaMasAlta()
        {
            double monto = 0;
            foreach (Oferta oferta in _ofertas)
            {
                if (oferta.monto == _ofertas.Max(o => o.monto))
                {
                    monto = oferta.monto;
                }
            }
            return monto;
        }


        public override double CalcularPrecio()
        {
            return MontoOfertaMasAlta();
        }



    }
}
