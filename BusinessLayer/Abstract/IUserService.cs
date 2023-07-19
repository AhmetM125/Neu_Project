using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IUserService
	{
		
		List<User> GetUsers();
		void UserAddBl(User user);
		void UserRemoveBl(User user);
		void UserUpdateBl(User user);

		User GetById(int id);

		List<User> GetListById(int id);
	}
}
