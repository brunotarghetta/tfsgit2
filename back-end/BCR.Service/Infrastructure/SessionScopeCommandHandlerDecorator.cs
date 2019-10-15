using BCR.Crosscutting.Exceptions;

namespace BCR.Service.Infrastructure
{
    public class SessionScopeCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> decorated;
        //private readonly BcrGixContext dbContext;

        public SessionScopeCommandHandlerDecorator(ICommandHandler<TCommand> decorated /*,BcrGixContext dbContext*/)
        {
            Argument.ThrowIfNull(() => decorated);

            this.decorated = decorated;
            //this.dbContext = dbContext;
        }

        public void Handle(TCommand command)
        {
            this.decorated.Handle(command);

            //this.dbContext.SaveChanges();
        }
    }
}
