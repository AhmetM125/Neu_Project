using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class UserManager : Repository<User>, IUserService
    {


        public User GetById(int id)
        {
            return base.Get(x => x.Id == id);
        }

        public List<User> GetListById(int id)
            => base.List(x => x.Id == id);


        public List<User> GetUsers()
            => base.List();

        public User Login(string username, string password)
        {
            var user = base.Get(x => x.Username == username && x.Password == password);
            return user;
        }

        public void UserAddBl(User user)
            => base.Insert(user);


        public void UserRemoveBl(User user)
            => base.Update(user);


        public void UserUpdateBl(User user)
            => base.Update(user);

    }
}
