using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Dtos.CreateOrderDto
{
    public record CreateItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
