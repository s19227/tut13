using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tut13.Entities;
using tut13.Models.Requests;
using tut13.Services;

namespace tut13.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDbService _dbService;

        public CustomerController(IDbService dbService) 
        {
            _dbService = dbService;
        }

        [HttpGet("orders")]
        public IActionResult GetOrders(string name = null)
        {
            if (name is null)
            {
                var result = _dbService.GetAllOrders();
                return Ok(result);
            } 
            else
            {
                var result = _dbService.GetOrdersFor(name);

                if (result is null) return BadRequest();
                else return Ok(result);
            }
        }

        [HttpPost("clients/{id}/orders")]
        public IActionResult AddOrder(int id, AddOrderReq request)
        {
            var result = _dbService.AddOrder(id, request);

            if (result is null) return BadRequest();
            else return Ok(result);
        }
    }
}