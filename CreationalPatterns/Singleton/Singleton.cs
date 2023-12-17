using System;
using System.Diagnostics;


namespace CreationalPatterns.Singleton
{
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> _lazy = new  Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance
        {
            get 
            {
                Debug.WriteLine("Instance called. ");
                return _lazy.Value;
            }
        }
        private Singleton()
        {
            Name = "Oluwatobi";
            Debug.WriteLine("Constructor Invoked");
        }

        public string Name { get; private set; }
    }
}
