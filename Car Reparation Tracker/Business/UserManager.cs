using CRT.Models;
using CRT.Data;
using CRT.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT.Business
{
    public class UserManager
    {
        private readonly IUserDataManager _iUserDataManager;

        public UserManager( ) : this(new UserDataManager())
        { }

        public UserManager(IUserDataManager loginDataManager)
        {
            _iUserDataManager = loginDataManager;
        }

        public List<User> getUsers()
        {
            return _iUserDataManager.getUsers();
        }

        public bool removeUser(int userId)
        {
            return _iUserDataManager.removeUser(userId);
        }

        public bool addUser(User user)
        {
            return _iUserDataManager.addUser(user);
        }
    }
}
