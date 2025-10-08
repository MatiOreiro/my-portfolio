using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Seguimiento
    {
        public int Id { get; set; }
        public Usuario Funcionario { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }

        public Seguimiento()
        {
        }
        public Seguimiento(Usuario funcionario, string comentario)
        {
            Funcionario = funcionario;
            Comentario = comentario;
            Fecha = DateTime.Now;
        }
    }
}
