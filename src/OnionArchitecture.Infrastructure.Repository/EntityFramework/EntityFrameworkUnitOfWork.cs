using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArchitecture.Core.Repository;

namespace OnionArchitecture.Infrastructure.Repository.EntityFramework
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        public void Dispose()
        {
            context.Dispose();
        } 

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
