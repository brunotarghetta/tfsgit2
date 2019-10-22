using BCR.Business.Domain.Queries.Seguridad;
using BCR.Business.Queries;
using BCR.Crosscutting.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.DataAccess.Seguridad
{
    public class AutenticacionUsuarioContraseniaQueryHandler : IQueryHandler<AutenticacionUsuarioContraseniaQuery, AutenticacionUsuarioContraseniaDataView>
    {
        public AutenticacionUsuarioContraseniaDataView Handle(AutenticacionUsuarioContraseniaQuery query)
        {
            Argument.ThrowIfNull(() => query);

            return new AutenticacionUsuarioContraseniaDataView()
            {
                NombreUsuario = query.NombreUsuario
            };
        }
    }
}
