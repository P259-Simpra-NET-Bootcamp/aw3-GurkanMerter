using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Data.Context;
using WS.Data.Repositories.Base;

namespace WS.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WSDbContext _context;
        private bool disposed;
        public UnitOfWork(WSDbContext context)
        {
            _context= context;
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
        private void Clean(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
            GC.SuppressFinalize(this);
        }
        public void Dispose()
        {
            Clean(true);
        }

        public IGenericRepository<Entity> Repository<Entity>() where Entity : class
        {
            return new GenericRepository<Entity>(_context);
        }
    }
}
