using System;
using System.Collections.Generic;
using System.Linq;
using OrderSystem.Models;

namespace OrderSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(OrderContext context)
        {
            context.Database.EnsureCreated();

            if (context.OrderItems.Any())
            {
                return;
            }

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
                    new OrderItem { Name = "Powdered Donut" },
                    new OrderItem { Name = "Sprinkle Donut", CustomerNote = "No sprinkes" },
                    new OrderItem { Name = "Plain Donut" },
                }
            });

            context.SaveChanges();
        }
    }
}