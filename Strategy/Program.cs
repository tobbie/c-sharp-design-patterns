using Strategy.Business.Models;
using Strategy.Business.Strategies.Invoice;
using Strategy.Business.Strategies.SalesTax;
using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                }

               // SalesTaxStrategy = new SwedenSalesTaxStrategy()

                
            };

            /**
            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
            if (destination == "sweden")
            { 
                order.SalesTaxStrategy = new SwedenSalesTaxStrategy();
            }
            else if (destination =="us")
            {
                order.SalesTaxStrategy = new USASalesTaxStrategy();
            }
           **/
            
            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);

            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);
            order.SelectedPayments.Add(new Payment { PaymentProvider = PaymentProvider.Invoice });
            
            Console.WriteLine(order.GetTax(new SwedenSalesTaxStrategy()));


            order.InvoiceStrategy = new FileInvoiceStrategy();
            order.FinalizeOrder();

        }
    }
}
