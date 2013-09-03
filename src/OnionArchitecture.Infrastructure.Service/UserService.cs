using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArchitecture.Core.Domain;
using OnionArchitecture.Core.Repository;
using OnionArchitecture.Core.Service;

namespace OnionArchitecture.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<User> userRepository;

        public UserService(IUnitOfWork unitOfWork, IGenericRepository<User> userRepository)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            if (userRepository == null) throw new ArgumentNullException("userRepository");
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
