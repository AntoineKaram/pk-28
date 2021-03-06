﻿using CRT.Business;
using CRT.Models;
using System.Web;
using System.Web.Http;


namespace CRT.Controller
{
    public class LoginController : ApiController
    {
        protected LoginManager loginManager = new LoginManager();

        [HttpPost]
        public string Login(User user)
        {
            User _user = loginManager.Login(user);
            HttpContext.Current.Session["ID"] = _user.userId;
            HttpContext.Current.Session["Role"] = _user.Role;
            if (_user.Role.Equals("Assurance"))
            {
                return "../Assurance/indexA.html";
            }
            else if (_user.Role.Equals("Expert") )
            {
                return "../Expert/HomeE.html";
            }
            else if (_user.Role.Equals("Garagist"))
            {
                return "../Garagiste/HomeG.html";
            }
            else if (_user.Role.Equals("Client"))
            {
                return "../Client/HomeC.html";
            }
            else if (_user.Role.Equals("Remorque"))
            {
                return "../Remorque/HomeR.html";
            }
            else
            {
                HttpContext.Current.Session.Clear();
                return "#";
            }
        }
    }
}
