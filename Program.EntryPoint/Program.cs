using static System.Console;
using CreationalPatterns.Prototype;

namespace Program.EntryPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunPrototype();
        }

        static void RunPrototype()
        {
            WriteLine("Original Order: ");
            FoodOrder savedOrder = new FoodOrder("Oluwatobi", true, 
                                    new string[] { "Pizza", "Orange Juice" }, new OrderInfo(3455));
            savedOrder.Debug();

            WriteLine("Cloned Order:");
            FoodOrder? clonedOrder = savedOrder.DeepCopy() as FoodOrder;
            clonedOrder.Debug();

            //Simulate the problem with a shallow copy
            WriteLine("Order changes:");
            savedOrder.UpdateCustomerName("Temitope");
            savedOrder.info.UpdateId(5555);

            savedOrder.Debug();
            clonedOrder.Debug();
            
        }
    }
}
