using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.DataAccessLayer.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly EntityContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(EntityContext entityContext)
        {
            context = entityContext;
            dbSet = context.Set<TEntity>();
        }

        public void Delete(object id)
        {
            var entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public IQueryable<TEntity> Get()
        {
            return dbSet;
        }

        public TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entityToInsert)
        {
            dbSet.Add(entityToInsert);
        }

        public void InsertOrUpdate(Expression<Func<TEntity, object>> id, params TEntity[] entities)
        {
            dbSet.AddOrUpdate(id, entities);
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Update(TEntity entityToInsert)
        {
            dbSet.Attach(entityToInsert);
            context.Entry(entityToInsert).State = EntityState.Modified;
        }
    }
}
