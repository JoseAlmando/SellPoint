using Microsoft.EntityFrameworkCore;
using SellPoint.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellPoint.Bussines.Services
{
    public class UnitOfWork : IDisposable
    {
        private Dictionary<string, object> repositories;
        public DbContext Db { get; }

        public UnitOfWork()
        {
            Db = new ApplicationDbContext();
        }   

        public GenericRepository<T> Repository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                object repositoryInstance = null;

                repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), Db);
                repositories.Add(type, repositoryInstance);

            }

            return (GenericRepository<T>)repositories[type];
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
