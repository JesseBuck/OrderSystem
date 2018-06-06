using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Models
{
    public class Order
    {
        public long Id { get; set; }

        [Required]
        public DateTime TimeRecieved { get; set; }

        [Required]
        public bool Completed { get; set; }  = false;

        public DateTime TimeCompleted { get; set; }

        public string CustomerName { get; set; }

        public string DestinationAddress { get; set; }

        [Required]
        public Decimal Cost { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}