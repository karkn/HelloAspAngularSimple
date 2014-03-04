using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelloAspAngular.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string[] includeProperties = null);

        Task<TEntity> FindAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string[] includeProperties = null);

        Task<TEntity> FindByIdAsync(object id);

        void Attach(TEntity entity);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(object id);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
    }
}
