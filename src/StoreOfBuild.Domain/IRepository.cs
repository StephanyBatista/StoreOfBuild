using System.Collections.Generic;

namespace StoreOfBuild.Domain
{
    public interface IRepository<TEntity>
    {
         TEntity GetById(int id);
         IEnumerable<TEntity> All();
         void Save(TEntity entity);
    }
}