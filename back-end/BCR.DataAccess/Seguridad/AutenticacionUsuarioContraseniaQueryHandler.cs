using BCR.Business.Domain.Queries;
using BCR.Crosscutting.Exceptions;

namespace BCR.DataAccess
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
