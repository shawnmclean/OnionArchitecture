using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArchitecture.Common;

namespace OnionArchitecture.Service
{
    public interface IUserService
    {
        void CreateUser(User user);
        User GetUser(int userId);
    }
}
