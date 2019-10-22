using BCR.Business.Domain.Base;
using System.Collections.Generic;

namespace BCR.Business.Domain.Configuracion
{
    public class Configuracion : Entity
    {
        public string Nombre { get; set; }

        public bool Activa { get; set; }

        public IEnumerable<ParametroConfiguracion> Paramteros { get; set; }
    }
}
