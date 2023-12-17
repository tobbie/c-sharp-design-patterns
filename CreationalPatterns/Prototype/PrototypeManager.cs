using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Prototype
{
    public class PrototypeManager
    {
        private Dictionary<string, Prototype> _prototypeLibrary = new Dictionary<string, Prototype>();

        public Prototype this[string key]
        {
            get { return _prototypeLibrary[key]; }
            set { _prototypeLibrary.Add(key, value); }
        }
    }
}
