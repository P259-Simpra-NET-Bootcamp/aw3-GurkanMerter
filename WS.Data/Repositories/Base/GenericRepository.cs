using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Data.Context;

namespace WS.Data.Repositories.Base
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        protected readonly WSDbContext _context;
        private bool _disposed;
        public GenericRepository(WSDbContext context)
        {
            _context = context;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void CompleteWithTransaction()
        {
            using (var dbDcontextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbDcontextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbDcontextTransaction.Rollback();
                }
            }
        }

        public void Delete(Entity entity)
        {
            _context.Set<Entity>().Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = _context.Set<Entity>().Find(id);
            _context.Set<Entity>().Remove(entity);
        }

        public List<Entity> GetAll()
        {
            return _context.Set<Entity>().ToList();
        }

        public Entity GetById(int id)
        {
            return _context.Set<Entity>().Find(id);
        }

        public void Insert(Entity entity)
        {

            _context.Set<Entity>().Add(entity);
        }

        public void Update(Entity entity)
        {
            _context.Set<Entity>().Update(entity);
        }
    }
}
