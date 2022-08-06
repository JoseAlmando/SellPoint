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

        public async Task<bool> Delete<V>(V Id) where V : struct
        {
            var objectToDelete = await DbSet.FindAsync(Id);
            DbSet.Remove(objectToDelete);
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

        public async Task<T> FindWhere(Expression<Func<T, bool>> predicate = null, Expression<Func<T, dynamic>> include = null)
        {
            if (predicate != null && include != null)
            {
                return await DbSet.Include(include).Where(predicate).FirstOrDefaultAsync();
            }
            if (predicate != null)
            {
                return await DbSet.Where(predicate).FirstOrDefaultAsync();
            }
            if (include != null)
            {
                return await DbSet.Include(include).FirstOrDefaultAsync();
            }

            return await DbSet.FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate = null, Expression<Func<T, dynamic>> include = null)
        {
            if (predicate != null && include != null)
            {
                return await DbSet.Include(include).Where(predicate).ToListAsync();
            }
            if (predicate != null)
            {
                return await DbSet.Where(predicate).ToListAsync();
            }
<<<<<<< Updated upstream
            if (include != null)
=======

            return await DbSet.ToListAsync();

            void AddRageEntities()
>>>>>>> Stashed changes
            {
                return await DbSet.Include(include).ToListAsync();
            }

            return await DbSet.ToListAsync();
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
