using BCR.Business.Domain.Base;
using System.Collections.Generic;

namespace BCR.Business.Domain
{
    public class Indicador : Entity
    {
        public ConfiguracionUnidadNegocio CongiuracionUnidadNegocio { get; set; }

        public TipoIndicador TipoIndicador { get; set; }

        public IEnumerable<Escala> Escalas { get; set; }
    }
}
