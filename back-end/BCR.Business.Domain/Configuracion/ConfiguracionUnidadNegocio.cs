using BCR.Business.Domain.Base;
using System.Collections.Generic;

namespace BCR.Business.Domain
{
    public class ConfiguracionUnidadNegocio : Aggregate
    {
        public string Nombre { get; set; }

        public bool Activa { get; set; }

        public UnidadNegocio UnidadNegocio { get; set; }

        public IEnumerable<Indicador> Indicadores { get; set; }
    }
}
