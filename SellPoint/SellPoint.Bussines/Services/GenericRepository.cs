using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SellPoint.Bussines.Interfaces;
using SellPoint.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SellPoint.Bussines.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;

        public GenericRepository(ApplicationDbContext context)
        {

            Context = context;
            DbSet = Context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetById<V>(V Id) where V : struct
        {
            return await DbSet.FindAsync(Id);
        }

        public async Task<bool> Add(T entity)
        {
            await DbSet.AddAsync(entity);
            return await CommitChanges();
        }

        public async Task<bool> Delete(T entity)
        {
            DbSet.Remove(entity);
            return await CommitChanges();
        }

        public async virtual Task<bool> Update(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Attach(entity);
            }
            Context.Entry(entity).State = EntityState.Modified;
            return await CommitChanges();
        }

        public async Task<T> FindWhere(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] properties)
        {
            IQueryable<T> Data = null;
            System.Text.RegularExpressions.Regex regex = new(@"^\w+[.]");
            bool isPredicateAndInclude = predicate != null && properties != null;

            if (predicate != null && properties != null)
            {
                AddRageEntities();
                return await Data.FirstOrDefaultAsync();
            }
            if (properties != null)
            {
                AddRageEntities();
                return await Data.FirstOrDefaultAsync();
            }
            if (predicate != null)
            {
                return await DbSet.FirstOrDefaultAsync(predicate);
            }
  
            return await DbSet.FirstOrDefaultAsync();

            void AddRageEntities()
            {
                foreach (var property in properties)
                {
                    if (isPredicateAndInclude)
                        Data = DbSet.Where(predicate).Include($"{regex.Replace(property.Body.ToString(), "")}");
                    else
                        Data = DbSet.Include($"{regex.Replace(property.Body.ToString(), "")}");
                }
            }
        }

        public async Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] properties)
        {
            IQueryable<T> Data = null;
            System.Text.RegularExpressions.Regex regex = new(@"^\w+[.]");
            bool isPredicateAndInclude = predicate != null && properties != null;
            if (isPredicateAndInclude)
            {
                AddRageEntities();
                return Data;
            }
            if (properties != null)
            {
                AddRageEntities();
                return Data;
            }
            if (predicate != null)
            {
                return await DbSet.Where(predicate).ToListAsync();
            }

            return await DbSet.ToListAsync();

            void AddRageEntities()
            {
                foreach (var property in properties)
                {
                    if (isPredicateAndInclude)
                        Data = DbSet.Where(predicate).Include($"{regex.Replace(property.Body.ToString(), "")}");
                    else
                        Data = DbSet.Include($"{regex.Replace(property.Body.ToString(), "")}");
                }
            }


        }

        public async Task<bool> Exists(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null)
            {
                return await DbSet.AnyAsync(predicate);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CommitChanges()
        {
            if (await Context.SaveChangesAsync() >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
