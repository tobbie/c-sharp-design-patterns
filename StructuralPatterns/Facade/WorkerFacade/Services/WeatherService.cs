using StructuralPatterns.Facade.WorkerFacade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Facade.WorkerFacade.Services
{
   public class WeatherService
    {
        public int GetTempFahrenheit(City city, State state)
        {
            // call to service or db would go here

            return 53;
        }
    }
}
