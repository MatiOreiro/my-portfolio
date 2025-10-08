using Obligatorio.LogicaNegocio.CustomExceptions;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.VO.Usuarios
{
    [ComplexType]
    public record NombreCompleto
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }
        public NombreCompleto(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }
        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new NombreNoValidoException("El nombre no puede estar vacío.");
            if (string.IsNullOrEmpty(Apellido))
                throw new NombreNoValidoException("El apellido no puede estar vacío.");

        }
    }
}
