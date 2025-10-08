using Obligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public class Cliente:Usuario
    {
        private double _saldo;

        public double saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public Cliente(string nombre, string apellido, string email, string password) : base(nombre, apellido, email, password)
        {

        }

        public Cliente() : base(){ }

        public override string ObtenerRol()
        {
            return "Cliente";
        }

        public void CargarSaldo(double saldo)
        {
            _saldo += saldo;
        }

    }


}
