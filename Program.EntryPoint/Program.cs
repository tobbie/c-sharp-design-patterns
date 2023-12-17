using static System.Console;
using CreationalPatterns.Prototype;
using CreationalPatterns.Singleton;

namespace Program.EntryPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // RunPrototype();
            // RunNaiveSingleton();
            RunProperSingleton();
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

            PrototypeManager manager = new PrototypeManager();
            manager["2/3/2023"] = new FoodOrder("Steve", false, new string[] { "Peppersoup", "Beetroot Juice" }, 
                                        new OrderInfo(8839));

            WriteLine("Manager clone");
            FoodOrder managerClone = (FoodOrder)manager["2/3/2023"].DeepCopy();
            managerClone.Debug(); 
           
        }

        static void RunNaiveSingleton()
        {
            var one = NaiveSingleton.Instance;
            var two = NaiveSingleton.Instance;
            var three = NaiveSingleton.Instance;

            WriteLine($"singleton one is the same as singleton two? {one.Equals(two)}");
            WriteLine($"singleton two is the same as singleton three? {two.Equals(three)}");
        }

        static void RunProperSingleton()
        {
            var one = Singleton.Instance;
            var two = Singleton.Instance;
            var three = Singleton.Instance;

            WriteLine($"singleton one is the same as singleton two? {one.Equals(two)}");
            WriteLine($"singleton two is the same as singleton three? {two.Equals(three)}");
        }
    }
}
