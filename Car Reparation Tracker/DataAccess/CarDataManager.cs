using CRT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRT.Models;

namespace CRT.DataAccess
{
    public class CarDataManager : DataManagerBase, ICarDataManager
    {
        public bool addCar(Car car)
        {
            bool result;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@Barecode", car.Barecode);
            dict.Add("@Marque", car.Marque);
            dict.Add("@Username", car.username);
            dict.Add("@Annee", car.Annee);
            dict.Add("@couleur", car.Couleur);
            dict.Add("@Immatriculation", car.Immatriculation);
            result = ExecuteCommand("USP_Insert_Car", dict);
            return result;
        }
    }
}
