using System;
using Strategy.Business.Models;

namespace Strategy.Business.Strategies.Invoice
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);
    }
}
