using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Dtos.CreateOrderDto
{
    public record CreateOrderDto
    {
        public UpdateCustomerDto User { get; set; }
        public List<CreateItemDto>? Goods { get; set; }
    }
}
