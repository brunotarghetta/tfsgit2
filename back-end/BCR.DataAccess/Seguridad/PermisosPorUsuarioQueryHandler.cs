using BCR.Business.Domain.Queries.Seguridad;
using BCR.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.DataAccess.Seguridad
{
    public class PermisosPorUsuarioQueryHandler : IQueryHandler<PermisosPorUsuarioQuery, IEnumerable<String>>
    {
        public IEnumerable<string> Handle(PermisosPorUsuarioQuery query)
        {
            return new List<string>() {
                "LaboratorioIndicadores"
            };
        }
    }
}
