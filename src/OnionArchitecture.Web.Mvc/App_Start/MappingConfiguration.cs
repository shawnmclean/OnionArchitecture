using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Infrastructure.DependencyResolution
{
    using AutoMapper;

    using OnionArchitecture.Core.Domain;
    using OnionArchitecture.Web.Mvc.Models;

    public class MappingConfig
    {
        public static void ConfigureMapping()
        {
            Mapper.CreateMap<User, UserDetailsModel>();
            Mapper.CreateMap<UserCreateModel, User>();
        }
    }
}
