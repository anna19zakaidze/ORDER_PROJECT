using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Dtos.UpdateOrderDto
{
    public record UpdateItemDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
