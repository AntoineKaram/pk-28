using CRT.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT.Data
{
    public interface IUserDataManager
    {
        List<User> getUsers( );
        bool removeUser(int userId);
        bool addUser(User user);
    }
}
