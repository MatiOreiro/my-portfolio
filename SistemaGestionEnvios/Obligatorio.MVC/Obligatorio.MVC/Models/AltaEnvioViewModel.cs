using Microsoft.AspNetCore.Mvc.Rendering;
using Obligatorio.DTOs.DTOs.DTOEnvio;

namespace Obligatorio.MVC.Models
{
    public class AltaEnvioViewModel
    {
        public AltaEnvioDTO Dto { get; set; }

        public List<SelectListItem> TipoEnvio { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem { Value = "comun", Text = "Común" },
            new SelectListItem { Value = "urgente", Text = "Urgente" }
        };

        public List<SelectListItem> Agencias { get; set; } = new List<SelectListItem>();

    }
}
