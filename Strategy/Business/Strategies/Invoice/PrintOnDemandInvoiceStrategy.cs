using System;
using System.Net.Http;
using Newtonsoft.Json;
using Strategy.Business.Models;

namespace Strategy.Business.Strategies.Invoice
{
    public class PrintOnDemandInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            using (var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(order);
                client.BaseAddress = new Uri("http://pluralsight.com");
                client.PostAsync("/print-on-demand", new StringContent(content));

            }
        }
    }
}
