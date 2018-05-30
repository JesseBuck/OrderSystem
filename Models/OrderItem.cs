using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Models
{
    public class OrderItem
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string CustomerNote { get; set; }
    }
}