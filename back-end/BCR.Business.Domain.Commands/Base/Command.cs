using System;

namespace BCR.Business.Domain.Commands.Base
{
    public abstract class Command<TId>
    {
        protected Command()
        {

        }

        public TId Id { get; set; }
    }

    public abstract class Command : Command<Int64>
    {
        protected Command()
        {

        }
    }
}
