using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut13.Models.Requests
{
    public class AddOrderReq
    {
        public DateTime DateAccepted { get; set; }
        public string Notes { get; set; }
        public List<ConfectioneryData> Confectionery { get; set; }
        
        public struct ConfectioneryData 
        {
            public int Quantity { get; set; }
            public string Name { get; set; }
            public string Notes { get; set; }
        }

    }
}
