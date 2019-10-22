using BCR.Business.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCR.Business.Domain.Queries.Seguridad
{
    public class AutenticacionUsuarioContraseniaQuery : IQuery<AutenticacionUsuarioContraseniaDataView>
    {
        [Required]
        public String NombreUsuario { get; set; }

        [Required]
        public String Contrasenia { get; set; }
    }
}
