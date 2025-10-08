using Obligatorio.LogicaNegocio.VO.Agencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Agencia
    { 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Ubicacion Ubicacion { get; set; }

        public Agencia() { }


        public Agencia(string nombre, string direccion, Ubicacion ubicacion)
        {
            Nombre = nombre;
            Direccion = direccion;
            Ubicacion = ubicacion;
        }
    }
}
