using Obligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public class Usuario : IValidate, IEquatable<Usuario>
    {
        private int _id;
        private static int s_ultId = 0;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _password;

        public int id
        {
            get { return _id; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public override string ToString()
        {
            return $"{_nombre} {_apellido}. Mail: {_email}.";
        }



        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }
            if (string.IsNullOrEmpty(_apellido))
            {
                throw new Exception("El Apellido es obligatorio");
            }
            if (string.IsNullOrEmpty(_email))
            {
                throw new Exception("El email es obligatorio");
            }
            if (string.IsNullOrEmpty(_password))
            {
                throw new Exception("Ingrese una contraseña válida");
            }

        }

        public Usuario(string nombre, string apellido, string email, string contrasenia)
        {
            _nombre = nombre;
            _apellido = apellido;
            _email = email;
            _password = contrasenia;
            _id = s_ultId++;
        }

        public Usuario()
        {
            _id = s_ultId++;
        }

        public bool Equals(Usuario? other)
        {
            return _email == other._email;
        }

        public virtual string ObtenerRol()
        {   
            return "Administrador";
        }
    }
}
