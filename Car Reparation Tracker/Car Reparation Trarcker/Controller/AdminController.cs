using CRT.Business;
using CRT.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CRT.Controller
{
    public class AdminController : ApiController
    {
        protected UserManager userManager = new UserManager();

        [HttpGet]
        public List<User> getUsers( )
        {
            return userManager.getUsers();
        }

        [Route("api/Admin/removeUser")]
        [HttpPost]
        public HttpResponseMessage removeUser([FromBody]int userId)
        {
            if (userManager.removeUser(userId))
            {
                return Request.CreateResponse("Succeeded");
            }
            else
            {
                return Request.CreateResponse("Failed");
            }
        }

        [Route("api/Admin/addUser")]
        [HttpPost]
        public HttpResponseMessage addUser(User user)
        {
            if (userManager.addUser(user))
            {
                return Request.CreateResponse("Succeeded");
            }
            else
            {
                return Request.CreateResponse("Failed");
            }
        }

        [Route("api/Admin/editUser")]
        [HttpPost]
        public HttpResponseMessage editUser([FromBody]User user)
        {
            if (userManager.editUser(user))
            {
                return Request.CreateResponse("Succeeded");
            }
            else
            {
                return Request.CreateResponse("Failed");
            }
        }
    }
}
