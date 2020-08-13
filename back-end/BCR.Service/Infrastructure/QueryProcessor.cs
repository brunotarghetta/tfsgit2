using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Autofac;
using BCR.Business.Queries;
using BCR.Crosscutting.Exceptions;
//using StructureMap;

namespace BCR.Service.Infrastructure
{
    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly IComponentContext context;

        public QueryProcessor(IComponentContext context)
        {
            this.context = context;
        }

        public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult> // where TResult : DataView
        {
            var handler = this.context.Resolve<IQueryHandler<TQuery, TResult>>();

            return handler.Handle(query);
        }

        //public TResult Process<TResult>(IQuery<TResult> query)
        //{
        //    var handler = this.context.Resolve<IQueryHandler<IQuery<TResult>, TResult>>();

        //    return handler.Handle(query);
        //}
    }
}
