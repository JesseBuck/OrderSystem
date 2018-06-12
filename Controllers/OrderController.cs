using System;
using System.Collections.Generic;
using System.Linq;
using OrderSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OrderSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("{id}", Name = "GetOrder")]
        public ActionResult<Order> GetById(long id)
        {
            Order order = context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPut("{id}")]
        public ActionResult SetCompleted(long id, [FromBody] Order updatedOrder)
        {
            Order order = context.Orders.Find(id);
            if (order == null)
            {
                return BadRequest("Existing order not found.");
            }

            if (updatedOrder.Completed == true)
            {
                updatedOrder.TimeCompleted = DateTime.Now;
            }
            else
            {
                updatedOrder.TimeCompleted = null;
            }

            order.Completed = updatedOrder.Completed;

            context.Orders.Update(order);
            context.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Order order)
        {
            order.TimeRecieved = DateTime.Now;
            context.Add(order);
            context.SaveChanges();

            return CreatedAtRoute("GetOrder", new {id = order.Id}, order);
        }
    }
}