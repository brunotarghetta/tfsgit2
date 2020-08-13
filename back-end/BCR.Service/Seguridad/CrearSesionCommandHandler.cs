using BCR.Business.Domain.Commands.Seguridad;
using BCR.Crosscutting.Exceptions;
using BCR.Service.Infrastructure;
using System;

namespace BCR.Service.Seguridad
{
    public class CrearSesionCommandHandler : ICommandHandler<CrearSesionCommand>
    {
        public void Handle(CrearSesionCommand command)
        {
            Argument.ThrowIfNull(() => command);

            command.IdSesionCreada = new Random().Next();
        }
    }
}
