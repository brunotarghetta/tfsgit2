using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.Service.Infrastructure
{
    public interface ICommandProcessor
    {
        void Process<TCommand>(TCommand command);
    }
}
