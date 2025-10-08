using Obligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public abstract class Publicacion : IValidate, IComparable<Publicacion>
    {
        private int _id;
        private static int s_ultId = 0;
        private string _nombre;
        private string _estado;
        private DateTime _fechaPublicacion;
        private List<Articulo> _articulos = new List<Articulo>();
        private Cliente _realizaCompra;
        private Cliente _finalizaCompra;
        private DateTime _fechaFinaliza;

        public int id
        {
            get { return _id; }
        }

        public string nombre
        {
            get { return _nombre; }
        }

        public DateTime fecha
        {
            get { return _fechaPublicacion.Date; }
        }

        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public List<Articulo> articulos
        {
            get { return _articulos; }
        }

        public Cliente realizaCompra
        {
            get { return _realizaCompra; }
            set { _realizaCompra = value; }
        }

        public Cliente finalizaCompra
        {
            get { return _finalizaCompra; }
            set { _finalizaCompra = value; }
        }

        public DateTime fechaFinaliza
        {
            get { return _fechaFinaliza; }
            set { _fechaFinaliza = value; }
        }

        public override string ToString()
        {
            return $"{_nombre} - Estado: {_estado}. \n Fecha de publicación {_fechaPublicacion}. \n Lista de artículos ";
        }

        public Publicacion(string nombre, string estado, DateTime fechaPublicacion, List<Articulo> articulos) 
        {
            _nombre = nombre;
            _estado = estado;
            _fechaPublicacion = fechaPublicacion;
            _articulos = articulos;
            _id = s_ultId++;
        }
        public void AltaArticulos(string nombre, string categoria, double precio)
        {
            Articulo articulo = new Articulo(nombre, categoria, precio);
            if (!_articulos.Contains(articulo))
            {
                _articulos.Add(articulo);
            }
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)){
                throw new Exception("El nombre es obligatorio");
            }
            if (string.IsNullOrEmpty(_estado)) {
                throw new Exception("El estado es obligatorio");
            }
            else if (_estado.ToUpper().Trim() != "ABIERTA" || _estado.ToUpper().Trim() != "CERRADA" || _estado.ToUpper().Trim() != "CANCELADA")
            {
                throw new Exception("El estado no tiene un valor válido");
            }
            
        }

        public abstract double CalcularPrecio();

        public int CompareTo(Publicacion? other)
        {
            return _fechaPublicacion.CompareTo(other._fechaPublicacion);
        }
    }
}
