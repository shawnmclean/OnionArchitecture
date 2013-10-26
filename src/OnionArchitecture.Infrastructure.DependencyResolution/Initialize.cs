using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Infrastructure.DependencyResolution
{
    using System.Data.Entity;
    using System.Security.Principal;
    using System.Threading;

    using OnionArchitecture.Core.Repository;
    using OnionArchitecture.Core.Service;
    using OnionArchitecture.Infrastructure.Repository;
    using OnionArchitecture.Infrastructure.Repository.EntityFramework;
    using OnionArchitecture.Infrastructure.Service;

    using SimpleInjector;
    using SimpleInjector.Extensions;

    public class Initialize
    {

        public static Container Register()
        {
            // 1. Create a new Simple Injector container
            var container = new Container();


            container.RegisterPerWebRequest<DbContext, EntityDatabaseContext>();

            container.Register<IUnitOfWork, EntityFrameworkUnitOfWork>();
            container.RegisterOpenGeneric(typeof(IGenericRepository<>), typeof(EntityFrameworkGenericRepository<>));

            container.Register<IUserService, UserService>();

            return container;
        }
    }
}
