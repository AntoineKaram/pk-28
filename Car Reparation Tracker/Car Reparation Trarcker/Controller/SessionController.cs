using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CRT.Controller
{
    public class SessionController : ApiController
    {
        [HttpGet]
        public string getAuth( )
        {
            if(HttpContext.Current.Session["ID"] == null)
            {
                return "../Default/index.html";
            }
            else
            {
                return "#";
            }
        }
    }
}
