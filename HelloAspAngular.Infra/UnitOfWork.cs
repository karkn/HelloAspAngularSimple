using HelloAspAngular.Common;
using HelloAspAngular.Domain;
using HelloAspAngular.Domain.TodoLists;
using HelloAspAngular.Infra.TodoLists;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAspAngular.Infra
{
    public class UnitOfWork<TContext>: IUnitOfWork, IDisposable where TContext: DbContext
    {
        private TContext _context;

        internal TContext Context {
            get { return _context; }
        }

        private bool _isDisposed = false;

        public UnitOfWork(TContext context)
        {
            _context = context;
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
                if (_context != null)
                {
                    _context.Dispose();
                }

                _context = null;
                _isDisposed = true;
            }
        }
        
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IUnitOfWorkTransaction BeginTransaction()
        {
            return new UnitOfWorkTransaction(_context.Database.BeginTransaction());
        }
    }
}
