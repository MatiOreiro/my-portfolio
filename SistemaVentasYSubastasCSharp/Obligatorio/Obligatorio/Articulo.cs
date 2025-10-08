using Obligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public class Articulo : IValidate
    {
        private int _id;
        private static int s_ultiId = 0;
        private string _nombre;
        private string _categoria;
        private double _precio;

        public string categoria
        {
            get { return _categoria; }
        }

        public int id
        {
            get { return _id; }
        }

        public double precio
        {
            get { return _precio; }
        }

        public override string ToString()
        {
            return $"{_nombre} - Precio ${_precio}.\n Categoría {_categoria}.";
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }
            if (string.IsNullOrEmpty(_categoria))
            {
                throw new Exception("La categoria es obligatoria");
            }
            if (_precio <= 0)
            {
                throw new Exception("El precio no puede ser menor a $0");
            }
        }

        public Articulo(string nombre, string categoria, double precio)
        {
            _id = Articulo.s_ultiId++;
            _nombre = nombre;
            _categoria = categoria;
            _precio = precio;
        }
    }
}
