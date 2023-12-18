using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Facade.WorkerFacade.Entities
{
  public class State
    {
        public State GetStateForZipCode(string zipCode)
        {
            // service or db lookup would go here
            return new State();
        }

        public string Name => "Lagos";
    }
}
