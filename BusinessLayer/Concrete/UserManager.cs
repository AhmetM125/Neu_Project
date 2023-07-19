using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class UserManager : IUserService
	{
		readonly IUserDal _userdal;

		public UserManager(IUserDal userdal)
		{
			_userdal = userdal;
		}

		public User GetById(int id)
		{
			return _userdal.Get(x=> x.Id == id);
		}

		public List<User> GetListById(int id)
		{
			return _userdal.List(x=> x.Id == id);
		}

		public List<User> GetUsers()
		{
			return _userdal.List();
		}

		public void UserAddBl(User user)
		{
			_userdal.Insert(user);
		}

		public void UserRemoveBl(User user)
		{
			
			_userdal.Update(user);
			
		}

		public void UserUpdateBl(User user)
		{
			_userdal.Update(user);
		}
	}
}
