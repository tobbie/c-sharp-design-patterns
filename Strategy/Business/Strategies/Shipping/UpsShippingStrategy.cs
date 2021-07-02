using System;
using System.Net.Http;
using Strategy.Business.Models;
using static System.Console;

namespace Strategy.Business.Strategies.Shipping
{
    public class UpsShippingStrategy : IShippingStrategy
    {       
        public void Ship(Order oredr)
        {
            using (var client = new HttpClient())
            {
                /// TODO : Implement DHL Shipping Integration

                WriteLine("Order is shipped with UPS");
            }
        }
    }
}
