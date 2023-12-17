using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Prototype
{
    public abstract class Prototype
    {
        public abstract Prototype ShallowCopy();
        // public abstract Prototype Clone();
        public abstract void Debug();

        public abstract Prototype DeepCopy();

    }
}
