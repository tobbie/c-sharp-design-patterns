using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable


namespace CreationalPatterns.Singleton
{
    public sealed class NaiveSingleton
    {
        private static NaiveSingleton? _instance;

        public static NaiveSingleton Instance
        {
            get
            {
                return _instance ??=  new NaiveSingleton();            
            }         
        }
        private NaiveSingleton()
        {
            Name = "Oluwatobi";
           
            Debug.WriteLine("Constructor invoked");
        }

        public string Name { get; private set; }
    }
}
