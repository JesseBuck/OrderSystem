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

            Random random = new Random(121);

            for(int i = 0; i < 30; i++)
            {
                context.Orders.Add(generateStaticOrder(random));
            }

            context.SaveChanges();
        }

        private static Order generateStaticOrder(Random random)
        {

            List<OrderItem> orderItems = new List<OrderItem>();
            for (int i = 0; i < random.Next(8); i++)
            {
                orderItems.Add(new OrderItem
                {
                    Name = $"Item {random.Next()}",
                    CustomerNote = random.Next() % 5 == 0 ? $"Note {random.Next()}" : null
                });
            }

            Order order = new Order
            {
                TimeRecieved = DateTime.Now.AddHours(random.Next(-24, 24)),
                CustomerName = $"Customer {random.Next()}",
                DestinationAddress = $"Address {random.Next()}",
                Cost = (decimal)random.NextDouble()*40,
                OrderItems = orderItems
            };

            return order;
        }
    }
}