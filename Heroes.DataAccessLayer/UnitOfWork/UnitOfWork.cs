using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes.DataAccessLayer.GenericRepository;

namespace Heroes.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private object contextLock = new object();

        public UnitOfWork(EntityContext entityContext)
        {
            context = entityContext;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!repositories.Keys.Contains(typeof(T)))
            {
                repositories.Add(typeof(T), new GenericRepository<T>(context));
            }
            return repositories[typeof(T)] as IGenericRepository<T>;
        }

        public void Save()
        {
            lock (contextLock)
            {
                context.SaveChanges();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    lock (contextLock)
                    {
                        context.Dispose();
                    }
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
