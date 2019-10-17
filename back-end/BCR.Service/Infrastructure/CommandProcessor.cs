using BCR.Crosscutting.Exceptions;
using StructureMap;
using System;
using System.Diagnostics;

namespace BCR.Service.Infrastructure
{
    public sealed class CommandProcessor : ICommandProcessor
    {
        private readonly IContainer container;

        public CommandProcessor(IContainer container)
        {
            Argument.ThrowIfNull(() => container);

            this.container = container;
        }

        [DebuggerStepThrough]
        public void Process<TCommand>(TCommand command)
        {
            Argument.ThrowIfNull(() => command);

            Type handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());

            dynamic handler = this.container.GetInstance(handlerType);

            handler.Handle((dynamic)command);
        }
    }
}
