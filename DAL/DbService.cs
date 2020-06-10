using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut13.Entities;
using tut13.Models.Requests;
using tut13.Models.Responses;
using tut13.Services;

namespace tut13.DAL
{
    public class DbService : IDbService
    {
        private readonly CustomerDbContext _context;
        private readonly Random _random;

        public DbService(CustomerDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public List<OrderResp> GetAllOrders()
        {
            return _context
                .Orders
                .Select(o => new OrderResp
                {
                    IdOrder = o.IdOrder,
                    ConfectioneryNames = _context
                        .ConfectioneryOrders
                        .Include(co => co.Confectionery)
                        .Where(co => co.IdOrder == o.IdOrder)
                        .Select(co => co.Confectionery.Name)
                        .ToList()
                })
                .ToList();
        }

        public List<OrderResp> GetOrdersFor(string name)
        {
            var allOrders = GetAllOrders();
            var ids = _context
                .Orders
                .Include(o => o.Customer)
                .Where(o => o.Customer.Name.Equals(name))
                .Select(o => o.Customer.IdClient)
                .ToList();

            var result = allOrders
                .Where(o => ids.Contains(o.IdOrder))
                .ToList();

            return result;
        }

        public List<OrderResp> AddOrder(int id, AddOrderReq request)
        {

            var newOrder = _context.Orders.Add(new Order
            {
                DateAccepted = request.DateAccepted,
                DateFinished = request.DateAccepted.AddDays(14),
                Notes = request.Notes,
                IdClient = id,
                IdEmployee = _context.Employees.ToList()[_random.Next(0, _context.Employees.Count())].IdEmployee
            });

            _context.SaveChanges();


            foreach (var c in request.Confectionery) 
            {
                if (!_context.Confectioneries.Any(conf => conf.Name == c.Name)) return null;

                _context.ConfectioneryOrders.Add(new Confectionery_Order
                {
                    IdConfectionery = _context.Confectioneries.First(c => c.Name.Equals(c.Name)).IdConfectionery,
                    IdOrder = newOrder.Entity.IdOrder,
                    Quantity = c.Quantity,
                    Notes = c.Notes
                });
            }

            _context.SaveChanges();
            return GetAllOrders();
        }
    }
}
