using StructuralPatterns.Facade.WorkerFacade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Facade.WorkerFacade
{
    public interface IWeatherFacade
    {
        WeatherFacadeResults GetTempInCity(string zipCode);
    }
}
