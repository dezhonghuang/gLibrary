using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gLibrary.Models;
using System.Data.Entity.Validation;

namespace gLibrary.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Save();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private gMenuDB db;
        private Dictionary<Type, object> _repository;

        public UnitOfWork()
        {
            db = new gMenuDB();
            _repository = new Dictionary<Type, object>();
        }

        public GenericRepository<T> GetRepository<T>() where T:class
        {
            if (_repository.Keys.Contains(typeof(T)))
                return _repository[typeof(T)] as GenericRepository<T>;

            var repository = new GenericRepository<T>(db);
            _repository.Add(typeof(T), repository);

            return repository;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}