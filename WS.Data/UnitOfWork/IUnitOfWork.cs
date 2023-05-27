using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Data.Domain;
using WS.Data.Repositories.Base;

namespace WS.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Entity> Repository<Entity>() where Entity : class;

        void Complete();
        void CompleteWithTransaction();
    }
}
