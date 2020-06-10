using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut13.Models.Requests;
using tut13.Models.Responses;

namespace tut13.Services
{
    public interface IDbService
    {
        public List<OrderResp> GetOrdersFor(string name);
        public List<OrderResp> GetAllOrders();

        public List<OrderResp> AddOrder(int id, AddOrderReq request);
    }
}
