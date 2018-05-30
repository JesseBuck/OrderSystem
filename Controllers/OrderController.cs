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
                    DestinationAddress = "123 Real St, Placeland, ZX",
                    Cost = 1_000_000_000m,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem { Name = "Extra Large Food" },
                        new OrderItem { Name = "Drink Powder", CustomerNote = "served wet, plz" }
                    }
                });

                context.SaveChanges();
            }
        }



        [HttpGet]
        public List<Order> GetAll()
        {
            return context.Orders.ToList();
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