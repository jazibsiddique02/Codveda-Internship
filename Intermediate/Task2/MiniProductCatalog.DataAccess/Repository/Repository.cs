using Microsoft.EntityFrameworkCore;
using MiniProductCatalog.DataAccess.Data;
using MiniProductCatalog.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProductCatalog.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(int id)
        {
            var result = _dbSet.Find(id);
            return result;

        }

        public IEnumerable<T> GetAll()
        {
            var result = _dbSet.ToList();
            return result;
        }

        public void Remove(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

       
    }
}
