using System.ComponentModel.DataAnnotations;

namespace FoodOrderSystem.Models
{
    public class FoodOrderItem
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string CustomerNote { get; set; }
    }
}