using System;
using System.Collections.Generic;
using System.Linq;
using OrderSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OrderSystem.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext context;

        public OrderController(OrderContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Order> GetAll()
        {
            return context.Orders.Include(order => order.OrderItems).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetById(long id)
        {
            Order item = context.Orders.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

    }
}