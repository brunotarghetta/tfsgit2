using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.Service.Infrastructure
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
