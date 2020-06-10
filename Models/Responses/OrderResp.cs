using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut13.Models.Responses
{
    public class OrderResp
    {
        public List<string> ConfectioneryNames { get; set; }
        public int IdOrder { get; set; }
    }
}
