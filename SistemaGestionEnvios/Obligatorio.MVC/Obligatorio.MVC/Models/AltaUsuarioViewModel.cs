using Microsoft.AspNetCore.Mvc.Rendering;
using Obligatorio.DTOs.DTOs.DTOUsuario;

namespace Obligatorio.MVC.Models
{
    public class AltaUsuarioViewModel
    {
        public AltaUsuarioDTO Dto { get; set; }
        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>() { 
            new SelectListItem { Value = "0", Text = "Administrador" },
            new SelectListItem { Value = "1", Text = "Funcionario" },
            new SelectListItem { Value = "2", Text = "Cliente" }
        };
    }
}
