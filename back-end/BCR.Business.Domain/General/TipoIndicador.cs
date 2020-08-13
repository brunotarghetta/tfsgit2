using BCR.Business.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.Business.Domain.General
{
    public class TipoIndicador : Entity
    {
        public string Nombre { get; set; }

        public string ProcedimientoAlmacenado { get; set; }
    }
}
