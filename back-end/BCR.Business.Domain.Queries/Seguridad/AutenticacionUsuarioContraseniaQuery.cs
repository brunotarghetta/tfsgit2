using System.ComponentModel.DataAnnotations;

namespace BCR.Business.Domain.Queries
{
    public class AutenticacionUsuarioContraseniaQuery : IQuery<AutenticacionUsuarioContraseniaDataView>
    {
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Contrasenia { get; set; }
    }
}
