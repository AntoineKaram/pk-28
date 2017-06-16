using CRT.Business;
using CRT.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CRT.Controller
{
    public class AdminController : ApiController
    {
        protected carManager carManager = new carManager();
        protected UserManager userManager = new UserManager();


        [Route("api/Admin/getMarque")]
        [HttpGet]
        public List<Marque> getMarque( )
        {
            List<Marque> marques = new List<Marque>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Marque",conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Marque marque = new Marque();
                marque.MarqueId = reader.GetInt32(0);
                marque.MarqueName = reader.GetString(1);
                marque.MarqueModel = reader.GetString(2);
                marques.Add(marque);
            }
            conn.Close();
            return marques;
        }


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
        [Route("api/Admin/addCar")]
        [HttpPost]
        public HttpResponseMessage addCar(Car car)
        {
            if (carManager.addCar(car))
            {
                return Request.CreateResponse("Succeeded");
            }

            return Request.CreateResponse("Failed");
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
