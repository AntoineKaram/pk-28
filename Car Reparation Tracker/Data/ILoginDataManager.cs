using CRT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT.Data
{
    public interface ILoginDataManager
    {
        User Login(User user);
    }
}
