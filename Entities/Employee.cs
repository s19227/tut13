using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut13.Entities
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
