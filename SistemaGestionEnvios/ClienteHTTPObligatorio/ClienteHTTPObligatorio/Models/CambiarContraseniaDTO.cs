namespace ClienteHTTPObligatorio.Models
{
    public class CambiarContraseniaDTO
    {
        public string AnteriorContrasenia { get; set; }
        public string NuevaContrasenia { get; set; }

        public CambiarContraseniaDTO(string anteriorContrasenia, string nuevaContrasenia)
        {
            AnteriorContrasenia = anteriorContrasenia;
            NuevaContrasenia = nuevaContrasenia;
        }
    }
}
