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
            //if (HttpContext.Current.Session != null)
            //{
                return userManager.getUsers();
            //}
            //else
            //{
                //HttpContext.Current.Response.Redirect("http://localhost:53999/View/Users/Default/index.html");
                return null;
            //}
        }

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

    }
}
