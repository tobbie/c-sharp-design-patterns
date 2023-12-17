using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CreationalPatterns.Prototype
{
    public class FoodOrder : Prototype
    {
        public string customerName { get; private set; }
        public bool isDelivery { get; private set; }
        public string[] orderContents { get; private set; }

        public OrderInfo info { get; private set; }

        public FoodOrder(string name, bool delivery, string[] contents, OrderInfo info)
        {
            this.customerName = name;
            this.isDelivery = delivery;
            this.orderContents = contents;
            this.info = info;
        }

        public override void Debug()
        {
            WriteLine("--------- Prototype Food Order------------");
            WriteLine("\nName: {0} \nDelivery: {1}", this.customerName, this.isDelivery);
            WriteLine("ID: {0}", this.info.Id);
            WriteLine("Order Contents: " + string.Join(",", orderContents) + "\n");
        }
        public override Prototype ShallowCopy()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public void UpdateCustomerName(string customerName) => this.customerName = customerName;

        public override Prototype DeepCopy()
        {
            FoodOrder clonedOrder = (FoodOrder)this.MemberwiseClone();
            clonedOrder.info = new OrderInfo(this.info.Id);

            return clonedOrder;

        }
    }
}
