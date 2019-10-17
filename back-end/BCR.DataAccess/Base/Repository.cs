using System.Linq;
using BCR.Business.Domain.Base;

namespace BCR.DataAccess.Base
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        public void Add(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TEntity> All()
        {
            throw new System.NotImplementedException();
        }

        public TEntity Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
