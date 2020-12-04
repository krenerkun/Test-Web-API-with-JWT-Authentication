using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.Model;

namespace WebAPI.Repositories.Common
{
    
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseModel
    {

        protected RefreshTokenContext _refreshTokenContext;
        protected DbSet<TEntity> dbSet;


        public GenericRepository(RefreshTokenContext refreshTokenContext)
        {
            _refreshTokenContext = refreshTokenContext;
            dbSet = refreshTokenContext.Set<TEntity>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
            ) {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var listOfProperties = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var includeProperty in listOfProperties)
            {
                query.Include(includeProperty);
            }

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();

        }

        public TEntity GetByID(object Id) {
            return dbSet.Find(Id);
        }

        public long Insert(TEntity entity) {
            dbSet.Add(entity);
            return entity.ID;
        }

        public void Update(TEntity entityToUpdate) {
            dbSet.Attach(entityToUpdate);
            _refreshTokenContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void UpdateAll(IEnumerable<TEntity> entitiesToUpdate) {
            foreach (var entity in entitiesToUpdate)
            {
                this.Update(entity);
            }
        }
        public void Delete(object Id) {
            var entityToDelete = dbSet.Find(Id);
            this.Delete(entityToDelete);
        }
        public void Delete(TEntity entityToDelete) {
            if (_refreshTokenContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            dbSet.Remove(entityToDelete);
        }
    }

}
