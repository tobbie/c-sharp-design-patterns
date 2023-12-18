using StructuralPatterns.Facade.WorkerFacade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Facade.WorkerFacade.Services
{
   public class GeoLookupService
    {
       public City GetCityForZipCode(string zipCode)
        {
            // a lookup would occur here
            return new City();
        }
        public State GetStateForZipCode(string zipCode)
        {
            // a lookup would occur here
            return new State();
        }
        public City GetCityForCoordinates(double longitude, double latitude)
        {
            // a lookup would occur here
            return new City();
        }
        public City GetStateByCapital(string capital)
        {
            // a lookup would occur here
            return new City();
        }
    }
}
