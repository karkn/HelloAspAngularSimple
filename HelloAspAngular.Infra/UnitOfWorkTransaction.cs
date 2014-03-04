using HelloAspAngular.Common;
using HelloAspAngular.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAspAngular.Infra
{
    internal class UnitOfWorkTransaction : IUnitOfWorkTransaction, IDisposable
    {
        private DbContextTransaction _transaction;

        private bool _isDisposed = false;

        public UnitOfWorkTransaction(DbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                }

                _transaction = null;
                _isDisposed = true;
            }
        }
    }
}
