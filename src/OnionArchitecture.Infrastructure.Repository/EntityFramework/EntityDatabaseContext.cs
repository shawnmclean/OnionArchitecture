using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Infrastructure.Repository.EntityFramework
{
    using System.Data.Entity;

    using OnionArchitecture.Core.Domain;

    public class EntityDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
