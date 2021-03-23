using InstaClone.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaClone.Infra.Data.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        protected readonly InstaContext _dbContext;
        public GenericRepository(InstaContext context)
        {
            _dbContext = context;
        }
        protected virtual async Task Insert(TEntity obj)
        {
            _dbContext.Set<TEntity>().Add(obj);
            await _dbContext.SaveChangesAsync();
        }

        protected virtual async Task Update(TEntity obj)
        {
            _dbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // TODO -> Check property
        //protected virtual void Update<TProperty>(TEntity obj, params PropertyEntry<TEntity>[] propsToIgnore)
        //{
        //    _dbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        //    foreach (var item in propsToIgnore)
        //        item.IsModified = false;

        //    _dbContext.SaveChanges();
        //}

        protected virtual async Task Delete(int id)
        {
            _dbContext.Set<TEntity>().Remove(await Select(id));
            await _dbContext.SaveChangesAsync();
        }

        protected virtual IList<TEntity> Select() =>
            _dbContext.Set<TEntity>().ToList();

        protected virtual async Task<TEntity> Select(int id) =>
            await _dbContext.Set<TEntity>().FindAsync(id);
    }
}
