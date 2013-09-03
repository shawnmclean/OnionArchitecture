using OnionArchitecture.Core.Domain;

namespace OnionArchitecture.Core.Service
{
    public interface IUserService
    {
        void CreateUser(User user);
        User GetUser(int userId);
    }
}
