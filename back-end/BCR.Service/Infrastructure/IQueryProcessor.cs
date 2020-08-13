using BCR.Business.Domain.Queries;

namespace BCR.Service.Infrastructure
{
    public interface IQueryProcessor
    {
        TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
