﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut13.Entities
{
    public class Order
    {
        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Confectionery_Order> Confectionery_Orders { get; set; }
    }
}
