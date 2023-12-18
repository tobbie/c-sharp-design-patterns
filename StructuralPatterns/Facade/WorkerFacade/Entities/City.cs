using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Facade.WorkerFacade.Entities
{
    public class City
    {
        public City GetCityForZipCode(string zipCode)
        {
            // service or db lookup would go here
            return new City();
        }

        public string Name => "Ikeja";
    }
}
