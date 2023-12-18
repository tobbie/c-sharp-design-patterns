using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Facade.WorkerFacade.Entities
{
    public class WeatherFacadeResults
    {
        public int Fahrenheit { get; set; }
        public int Celsius { get; set; }
        public City City { get; set; }
        public State State { get; set; }
    }
}
