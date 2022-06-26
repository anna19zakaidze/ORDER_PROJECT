using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Entities
{
    public record Order
    {
        public Guid Id { get; init; }
        public DateTimeOffset OrderDate { get; set; }
        public Customer User { get; set; }

        public List<Item>? Goods { get; set; }
    }
}
