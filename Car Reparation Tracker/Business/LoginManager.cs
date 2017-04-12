using CRT.Data;
using CRT.DataAccess;
using CRT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT.Business
{
    public class LoginManager
    {
        private readonly ILoginDataManager _iLoginDataManager;

        public LoginManager( ) : this(new LoginDataManager())
        {}

        public LoginManager(ILoginDataManager loginDataManager)
        {
            _iLoginDataManager = loginDataManager;
        }

        public User Login(User user)
        {
            return _iLoginDataManager.Login(user);
        }
    }
}
