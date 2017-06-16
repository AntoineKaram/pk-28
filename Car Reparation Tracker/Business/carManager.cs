using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRT.Models;
using CRT.Data;
using CRT.DataAccess;

namespace CRT.Business
{
    public class carManager
    {
        private readonly ICarDataManager _iCarDataManager;

        public carManager( ) : this(new CarDataManager())
        { }

        public carManager(ICarDataManager CarDataManager)
        {
            _iCarDataManager = CarDataManager;
        }

        public bool addCar(Car car)
        {
           return  _iCarDataManager.addCar(car);
        }
    }
}
