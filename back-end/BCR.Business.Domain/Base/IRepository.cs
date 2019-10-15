using System;
using System.Linq;

namespace BCR.Business.Domain.Base
{
    public interface IRepository<TEntity>
     where TEntity : Entity
    {
        void Add(TEntity entity);

        IQueryable<TEntity> All();

        TEntity Get(Int64 id);

        void Remove(TEntity entity);
    }
}
