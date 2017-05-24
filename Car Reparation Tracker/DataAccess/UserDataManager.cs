using CRT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRT.Models;

namespace CRT.DataAccess
{
    public class UserDataManager : DataManagerBase, IUserDataManager
    {
        public bool addUser(User user)
        {
            bool result;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@Prenom", user.Prenom);
            dict.Add("@Nom", user.Nom);
            dict.Add("@Username", user.Username);
            dict.Add("@Password", user.Password);
            dict.Add("@role", user.Role);
            result = ExecuteCommand("USP_Insert_User", dict);
            return result;
        }

        public bool editUser(User user)
        {
            bool result;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@Id", user.userId);
            dict.Add("@Prenom", user.Prenom);
            dict.Add("@Nom", user.Nom);
            dict.Add("@Username", user.Username);
            dict.Add("@role", user.Role);
            result = ExecuteCommand("USP_Edit_User", dict);
            return result;
        }

        public List<User> getUsers( )
        {
            List<User> users = new List<User>();
            users = ExecuteCollection<User>("USP_Get_Users",
                (reader) =>
                {
                    User tempUser = new User()
                    {
                        Nom = (string)reader.GetValue(0),
                        Prenom = (string)reader.GetValue(1),
                        userId = (int)reader.GetValue(2),
                        Role = (string)reader.GetValue(3),
                        Username = (string)reader.GetValue(4)

                    };
                    return tempUser;
                });
            if (users.Count > 0)
            {
                return users;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public bool removeUser(int userId)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@Id", userId);
            return ExecuteCommand("USP_Remove_User", dict);
        }
    }
}
