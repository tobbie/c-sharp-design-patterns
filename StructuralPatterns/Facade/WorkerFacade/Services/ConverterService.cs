﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Facade.WorkerFacade.Services
{
    public class ConverterService
    {
        public int ConvertFahrenheitToCelsius(int fahrenheit)
        {
            double celsius = (5.0 / 9.0) * (fahrenheit - 32);

            return (int)celsius;
        }

        public int ConvertCelsiusToFahrenheit(int celsius)
        {
            double fahrenheit = celsius * (1.8 + 32);

            return (int)fahrenheit;
        }
    }
}
