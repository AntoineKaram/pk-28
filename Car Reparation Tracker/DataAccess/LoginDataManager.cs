using CRT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRT.Models;

namespace CRT.DataAccess
{
    public class LoginDataManager : DataManagerBase, ILoginDataManager
    {
        public User Login(User user)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@Username", user.Username);
            dict.Add("@Password", user.Password);
            User userInfo = ExecuteSingleton<User>("USP_Login",
                (reader) =>
                {
                    User tempUser = new User()
                    {
                        Nom = (string)reader.GetValue(0),
                        Prenom = (string)reader.GetValue(1),
                        userId = (int)reader.GetValue(2),
                        Role = (string)reader.GetValue(3),
                        Username = user.Username,
                        Password = user.Password

                    };
                    return tempUser;
                }, dict);
            return userInfo;
        }
    }
}
