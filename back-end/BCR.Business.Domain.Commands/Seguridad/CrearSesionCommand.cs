using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.Business.Domain.Commands.Seguridad
{
    public class CrearSesionCommand
    {
        public Int64 IdUsuario { get; set; }

        // HACK: command output property
        public Int64 IdSesionCreada { get; set; }

        public String UserAgent { get; set; }
    }
}
