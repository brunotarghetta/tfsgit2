using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BCR.Business.Queries;
using BCR.Crosscutting.Exceptions;
using StructureMap;

namespace BCR.Service.Infrastructure
{
    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly IContainer container;

        public QueryProcessor(IContainer container)
        {
            Argument.ThrowIfNull(() => container);

            this.container = container;
        }

        //[DebuggerStepThrough]
        public TResult Process<TResult>(IQuery<TResult> query)
        {
            Argument.ThrowIfNull(() => query);

            Type handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = this.container.GetInstance(handlerType);

            return handler.Handle((dynamic)query);
        }
    }
}
