using Autofac;
using BCR.Business.Domain.Queries;

namespace BCR.Service.Infrastructure
{
    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly IComponentContext context;

        public QueryProcessor(IComponentContext context)
        {
            this.context = context;
        }

        public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = this.context.Resolve<IQueryHandler<TQuery, TResult>>();

            return handler.Handle(query);
        }
    }
}
