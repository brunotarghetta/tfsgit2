using BCR.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.Business.Domain.Queries.Seguridad
{
    public class AutenticacionUsuarioContraseniaDataView : DataView
    {
        public Int64 IdSesion { get; set; }

        public String NombreUsuario { get; set; }
    }
}
