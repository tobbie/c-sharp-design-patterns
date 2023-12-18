using static System.Console;
using CreationalPatterns.Prototype;
using CreationalPatterns.Singleton;
using StructuralPatterns.Facade.BallOfMud;
using System.Data;
using StructuralPatterns.Facade.WorkerFacade.Entities;
using StructuralPatterns.Facade.WorkerFacade;
using StructuralPatterns.Facade.WorkerFacade.Services;


namespace Program.EntryPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // RunPrototype();
            // RunNaiveSingleton();
            //RunProperSingleton();
            //RunBigClass();
         //   RunBigClassFacade();
          //  RunWeatherFacade();
            RunWeatherServicesWithoutFacade();
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

        public static void RunBigClass()
        {
            var bigClass = new BigClass();
            bigClass.SetValueI(3);

            bigClass.IncrementI();
            bigClass.IncrementI();
            bigClass.IncrementI();

            bigClass.DecrememntI();
            WriteLine($"------------------Testing Bigclass-----------\n");

            WriteLine($"Final number is {bigClass.GetValueA()}");


        }

        public static void RunBigClassFacade()
        {
           var bigClassFacade = new  BigClassFacade();
            bigClassFacade.IncreaseBy(numberToAdd:50);
            bigClassFacade.DecreaseBy(numberToSubtract:20);
            
            WriteLine($"------------------Testing Bigclass Facade-----------\n");
            WriteLine($"Final number is {bigClassFacade.GetCurrentValue()}");

        }

        public static void RunWeatherFacade()
        {
            WriteLine($"------------------Testing Weather Facade-----------\n");
            const string zipCode = "98074";

            IWeatherFacade weatherFacade = new WeatherFacade();
            WeatherFacadeResults results = weatherFacade.GetTempInCity(zipCode);

            WriteLine("The current temperature is {0}F/{1}C in {2}, {3}",
                                results.Fahrenheit,
                                results.Celsius,
                                results.City.Name,
                                results.State.Name);
        }

        public static void RunWeatherServicesWithoutFacade()
        {
            const string zipCode = "98074";

            // call to service 1
            GeoLookupService geoLookupService = new GeoLookupService();
            City city = geoLookupService.GetCityForZipCode(zipCode);
            State state = geoLookupService.GetStateForZipCode(zipCode);

            // call to service 2
            WeatherService weatherService = new WeatherService();
            int fahrenheit = weatherService.GetTempFahrenheit(city, state);

            // call to service 3
            ConverterService metricConverter = new ConverterService();
            int celcius = metricConverter.ConvertFahrenheitToCelsius(fahrenheit);

            WriteLine($"------------------Testing Weather service without facade-----------\n");
            // bring the result of all service calls together
            WriteLine("The current temperature is {0} F / {1} C in {2}, {3}",
                                fahrenheit,
                                celcius,
                                city.Name,
                                state.Name);
        }
    }
}
