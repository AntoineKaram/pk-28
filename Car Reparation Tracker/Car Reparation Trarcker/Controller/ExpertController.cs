using CRT.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRT.Controller
{
    public class ExpertController : ApiController
    {
        [Route("api/Expert/getCars")]
        [HttpPost]
        public List<Car> getCars([FromBody]string immatriculation)
        {
            List<Car> cars = new List<Car>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("USP_Get_Cars", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Immatriculation", immatriculation);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Car car = new Car();
                car.username = reader.GetString(0);
                car.Marque = reader.GetString(1);
                car.Couleur = reader.GetString(2);
                car.Annee = reader.GetString(3);
                car.Immatriculation = reader.GetString(4);
                cars.Add(car);
            }
            conn.Close();
            return cars;
        }
    }
}
