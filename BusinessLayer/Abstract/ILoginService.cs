using BusinessLayer.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ILoginService : IRepository<User>
    {
        User GetById(int id);
        User GetUser(string username, string password);
    }
}
