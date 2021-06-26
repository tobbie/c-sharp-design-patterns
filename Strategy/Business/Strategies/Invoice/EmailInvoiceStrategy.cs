using System;
using Strategy.Business.Models;

namespace Strategy.Business.Strategies.Invoice
{
    public class EmailInvoiceStrategy : InvoiceStrategy
    {  
        public override void Generate(Order order)
        {
            var body = GenerateTextInvoice(order);

            // send email with body
        }
    }
}
