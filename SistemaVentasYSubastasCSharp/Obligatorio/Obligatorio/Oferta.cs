using Obligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public class Oferta : IValidate
    {
        private int _id;
        private static int s_ultId = 0;
        private Cliente _usuario;
        private double _monto;
        private DateTime _fecha;

        public Cliente usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public double monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
        public override string ToString()
        {
            return $"{_usuario} ofertó {_monto} el día {_fecha}.";
        }

        public void Validar()
        {
            if (_monto <= 0)
            {
                throw new Exception("La oferta debe ser mayor de 0");
            }
        }

        public Oferta(Cliente usuario, double monto, DateTime fecha)
        {
            _id = s_ultId++;
            _usuario = usuario;
            _monto = monto;
            _fecha = fecha;
        }


    }
}
