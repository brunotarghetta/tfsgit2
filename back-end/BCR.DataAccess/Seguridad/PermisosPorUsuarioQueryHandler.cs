using BCR.Business.Domain.Queries;
using System;
using System.Collections.Generic;

namespace BCR.DataAccess
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
