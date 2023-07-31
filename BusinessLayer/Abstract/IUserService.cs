using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IUserService : IRepository<User>
    {
        User Login(string username, string password);

        List<User> GetUsers(bool AllStatus);
        void UserAddBl(User user);
        void UserRemoveBl(User user);
        void UserUpdateBl(User user);

        User GetById(int id);

        List<User> GetListById(int id);
    }
}
