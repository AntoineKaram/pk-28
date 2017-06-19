using CRT.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CRT.Controller
{
    public class GaragisteController : ApiController
    {
        [HttpGet]
        public List<Car> getCars( )
        {

            if (HttpContext.Current.Session["ID"] == null) return null;
            int user_id = (int)HttpContext.Current.Session["ID"];
            List<Car> cars = new List<Car>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_Get_CarsbyGarage", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userId", user_id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Car car = new Car();
                car.Barecode = reader.GetInt32(0);
                car.Marque = reader.GetString(1) + " " + reader.GetString(2);
                car.Immatriculation = reader.GetString(3);
                car.Couleur = reader.GetString(4);
                car.username = reader.GetString(5);
                car.status = reader.GetString(6);
                cars.Add(car);
            }
            conn.Close();
            return cars;
        }

        [Route("api/Garagiste/saveStatus")]
        [HttpPost]
        public HttpResponseMessage saveStatus(Indata indata)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("UPDATE Voitures SET Statut = "+indata.status+" where Barcode = '" + indata.barecode + "'", conn);
            int result = command.ExecuteNonQuery();
            command.ExecuteNonQuery();
            conn.Close();
            return Request.CreateResponse("SAved");
        }
        [Route("api/Garagiste/EndReparation")]
        [HttpPost]
        public HttpResponseMessage EndReparation([FromBody]int barecode)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("UPDATE Voitures SET Statut =  8   where Barcode = '" + barecode + "'", conn);
            command.ExecuteNonQuery();
            conn.Close();
            return Request.CreateResponse("SAved");
        }

        [Route("api/Garagiste/addCar")]
        [HttpPost]
        public bool addCar([FromBody]Car car)
        {

            if (HttpContext.Current.Session["ID"] == null) return false;
            int user_id = (int)HttpContext.Current.Session["ID"];
            string sdate = car.estimeeFinReparation.ToShortDateString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("UPDATE Accident SET Debut_Reparation = SYSDATETIME(),Fin_Remorque = SYSDATETIME(),EstimeeFinReparation = '" + sdate + "',Garage_Id=(select TOP 1 Garage_Id from Garage where [user_Id] ="+user_id+") where Barecode = " + car.Barecode + " ", conn);
            SqlCommand commad2 = new SqlCommand("UPDATE Voitures SET Statut =  4   where Barcode = '" + car.Barecode+ "'",conn);
            int result = command.ExecuteNonQuery();
            commad2.ExecuteNonQuery();
            conn.Close();
            return result > 0;

        }

    }
    public class Indata{
        public int status;
        public int barecode;
    }

    
}
