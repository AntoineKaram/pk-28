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
    public class MyCarsController : ApiController
    {
        [Route("api/MyCars/getCars")]
        [HttpGet]
        public List<Car> getCars( )
        {
            if (HttpContext.Current.Session["ID"] == null) return null;
            int userId = (int)HttpContext.Current.Session["ID"] ;
            List<Car> cars = new List<Car>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("Select v.Barcode,v.Couleur,v.Annee,v.Immatriculation,m.Marque,s.[status] from Voitures v inner join Marque m on m.MarqueId = v.MarqueId inner join statut s on s.status_Id = v.Statut where v.User_Id = '"+userId+"'", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Car car = new Car();
                car.Barecode = reader.GetInt32(0);
                car.Couleur = reader.GetString(1);
                car.Annee = reader.GetString(2);
                car.Immatriculation = reader.GetString(3);
                car.Marque = reader.GetString(4);
                car.status = reader.GetString(5);
                cars.Add(car);
            }
            conn.Close();
            return cars;
        }
    }
}
