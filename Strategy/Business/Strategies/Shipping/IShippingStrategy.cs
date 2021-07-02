using System;
using Strategy.Business.Models;

namespace Strategy.Business.Strategies.Shipping
{
    public interface IShippingStrategy
    {
        public void Ship(Order oredr);
    }
}
