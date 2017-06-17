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
    public class RemorqueController : ApiController
    {
        [Route("api/Remorque/getCars")]
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
            reader.Close();
            SqlCommand cmd = new SqlCommand("SELECT v.[Immatriculation] ,a.Barecode FROM [ProjetFinal].[dbo].[Voitures] v inner join[ProjetFinal].[dbo].Accident a on a.Barecode = v.Barcode where v.[Immatriculation] = '"+ immatriculation+"'", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string immatriculationTemp = rdr.GetString(0);
                int count = cars.Count();
                for (int i = 0; i < count; i++)
                {
                    if (!cars[i].Immatriculation.Equals(immatriculationTemp))
                    {
                        cars.Remove(cars[i]);
                    }
                }
            }

            conn.Close();
            if (cars.Count > 0)
            {
                return cars;
            }
            else
            {
                return null;
            }
        }

        [Route("api/Remorque/debutRemorque")]
        [HttpPost]
        public bool debutRemorque([FromBody]string immatriculation)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("UPDATE Accident SET Debut_Remorque = SYSDATETIME() where Barecode = (select Barcode from Voitures where Immatriculation = '"+immatriculation+"')", conn);
            SqlCommand command2 = new SqlCommand("UPDATE Voitures SET Statut = 3 where Immatriculation = '" + immatriculation + "'",conn);
            int result = command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }
    }
}
