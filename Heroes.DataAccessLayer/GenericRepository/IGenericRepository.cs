using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.DataAccessLayer.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetById(object id);
        void Insert(TEntity entityToInsert);
        void InsertRange(IEnumerable<TEntity> entities);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        void InsertOrUpdate(Expression<Func<TEntity, object>> id, params TEntity[] entities);
        void LoadCollection<TElement>(TEntity entity,
            Expression<Func<TEntity, ICollection<TElement>>> navigationProperty) where TElement : class;
    }
}
