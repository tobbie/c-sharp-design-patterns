using Strategy.Business.Models;
using Strategy.Business.Strategies.Invoice;
using Strategy.Business.Strategies.SalesTax;
using Strategy.Business.Strategies.Shipping;
using System;
using static System.Console;
using static System.Convert;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            WriteLine("Please select origin country: ");
            var origin = ReadLine().Trim();

            WriteLine("\nPlease select destination country: ");
            var destination = ReadLine().Trim();

            WriteLine("\nChoose one of the following shipping providers ");
            WriteLine("1. PostNord (Swedish Postal Service) ");
            WriteLine("2. DHL ");
            WriteLine("3. USPS ");
            WriteLine("4. Fedex ");
            WriteLine("5. UPS");
            WriteLine("Select shipping provider: ");
            var provider = ToInt32(ReadLine().Trim());

            WriteLine("\nChoose one of the following invoice delivery options ");
            WriteLine("1. Email");
            WriteLine("2. File (download later)");
            WriteLine("3. Mail ");
            WriteLine("Select invoice delivery options: ");
            var invoiceOption = ToInt32(ReadLine().Trim());

            WriteLine();
            #endregion

            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = origin,
                    DestinationCountry = destination,
                    DestinationState = "nyc"
                },

                InvoiceStrategy = GetInvoiceStrategyFor(invoiceOption),
                ShippingStrategy = GetShippingStrategyFor(provider),
                SalesTaxStrategy = GetSalesTaxStrategyFor(origin)             
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

            var tax = order.GetTax(order.SalesTaxStrategy);
            WriteLine($"Tax:  {tax}");
            WriteLine($"Total:  {order.TotalPrice + tax}");

            order.FinalizeOrder();

        }

        private static IShippingStrategy GetShippingStrategyFor(int provider) {
            switch (provider)
            {
                case 1: return new SwedishPostalServiceShippingStrategy();
                case 2: return new DhlShippingStrategy();
                case 3: return new UnitedStatesPostalServiceShippingStrategy();
                case 4: return new FedexShippingStrategy();
                case 5: return new UpsShippingStrategy();
                default: throw new Exception("Unsupported shipping method");                 
            }
        }

        private static ISalesTaxStrategy GetSalesTaxStrategyFor(string origin)
        {
            if (origin.ToLowerInvariant() == "sweden")
            {
                return new SwedenSalesTaxStrategy();
            }
            else if (origin.ToLowerInvariant() == "usa")
            {
                return new USASalesTaxStrategy();
            }
            else {
                throw new Exception("Unsupported region");
            }
        }

        private static IInvoiceStrategy GetInvoiceStrategyFor(int option)
        {
            switch (option)
            {
                case 1: return new EmailInvoiceStrategy();
                case 2: return new FileInvoiceStrategy();
                case 3: return new PrintOnDemandInvoiceStrategy();
                default: throw new Exception("Unsupported invoice method");
            }

        }

        

    }
}
