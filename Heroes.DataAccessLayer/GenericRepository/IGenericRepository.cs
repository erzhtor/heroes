using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.DataAccessLayer.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        IQueryable<TEntity> Get();
        TEntity GetById(object id);
        void Insert(TEntity entityToInsert);
        void InsertRange(IEnumerable<TEntity> entities);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToInsert);
        void InsertOrUpdate(Expression<Func<TEntity, object>> id, params TEntity[] entities);
    }
}
