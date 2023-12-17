using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Prototype
{
    public class OrderInfo
    {
        public int Id { get; private set; }
        public OrderInfo(int id)  => this.Id = id;

        public void UpdateId(int id) => this.Id = id;
    }
}
