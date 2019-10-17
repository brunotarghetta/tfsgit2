namespace BCR.Business.Queries
{
    public interface IQueryHandler<TQuery, out TResult>
       where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
