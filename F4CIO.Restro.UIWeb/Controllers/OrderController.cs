using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using F4CIO.Restro.Entities;
using F4CIO.Restro.BusinessLogic;

namespace F4CIO.Restro.UIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IHandlerForOrders _blHandlerForOrders;
        public OrderController(IHandlerForOrders blHandlerForOrders)
        {
            _blHandlerForOrders = blHandlerForOrders;
        }
        [HttpGet]
        public List<Order> GetOrders()
        {
            return _blHandlerForOrders.GetOrders();
        }
        [HttpPost]
        public void AddOrder(Order oer)
        {
            _blHandlerForOrders.InsertOrder(oer);
        }
    }
}