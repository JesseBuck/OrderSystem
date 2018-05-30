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

            // TODO: Move DB-populating code to separate module
            if (context.Orders.Count() == 0)
            {
                context.Orders.Add(new Order
                {
                    TimeRecieved = DateTime.Now,
                    CustomerName = "Anon Ymous",
                    DestinationAddress = "123 Real St, Placeland, CO",
                    Cost = 15.89m,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem { Name = "Extra Large Food" },
                        new OrderItem { Name = "Drink Powder", CustomerNote = "Served wet" }
                    }
                });

                context.Orders.Add(new Order
                {
                    TimeRecieved = DateTime.Now.AddHours(-1),
                    CustomerName = "Imac Ustomer",
                    DestinationAddress = "Box around the corner",
                    Cost = 2.50m,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem { Name = "Glazed Donut" },
                        new OrderItem { Name = "Chocolate Donut" },
                        new OrderItem { Name = "Sprinkle Donut", CustomerNote = "No sprinkes" }
                    }
                });

                context.SaveChanges();
            }
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