using Autofac;

namespace BCR.Service.Infrastructure
{
    public sealed class CommandProcessor : ICommandProcessor
    {
              private readonly IComponentContext context;

        public CommandProcessor(IComponentContext context)
        {
            this.context = context;
        }

        public void Process<TCommand>(TCommand command)
        {
            var handler = this.context.Resolve<ICommandHandler<TCommand>>();

            handler.Handle(command);
        }
    }
}
