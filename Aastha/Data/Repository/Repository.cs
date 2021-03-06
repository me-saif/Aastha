using System;
using System.Collections.Generic;
using System.Linq;
using Aastha.Data.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Aastha.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AasthaContext _context;

        public Repository(AasthaContext context)
        {
            _context = context;
        }

        protected void Save()
        {
            _context.SaveChanges();
        }

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual T GetById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}