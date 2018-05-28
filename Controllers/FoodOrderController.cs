using System;
using System.Collections.Generic;
using System.Linq;
using FoodOrderSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystem.Controllers
{
    [Route("api/[controller]")]
    public class FoodOrderController : ControllerBase
    {
        private readonly FoodOrderContext context;

        public FoodOrderController(FoodOrderContext context)
        {
            this.context = context;

            // TODO: Move DB-populating code to separate module
            if (context.FoodOrders.Count() == 0)
            {
                context.FoodOrders.Add(new FoodOrder
                {
                    TimeRecieved = DateTime.Now,
                    CustomerName = "Anon Ymous",
                    DestinationAddress = "123 Real St, Placeland, ZX",
                    Cost = 1_000_000_000m,
                    OrderItems = new List<FoodOrderItem>
                    {
                        new FoodOrderItem { Name = "Extra Large Food" },
                        new FoodOrderItem { Name = "Drink Powder", CustomerNote = "served wet, plz" }
                    }
                });

                context.SaveChanges();
            }
        }



        [HttpGet]
        public List<FoodOrder> GetAll()
        {
            return context.FoodOrders.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<FoodOrder> GetById(long id)
        {
            FoodOrder item = context.FoodOrders.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

    }
}