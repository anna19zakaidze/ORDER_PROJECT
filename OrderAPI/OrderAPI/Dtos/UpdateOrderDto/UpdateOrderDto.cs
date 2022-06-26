using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Dtos.UpdateOrderDto
{
    public record UpdateOrderDto
    {
        [Required]
        public CreateCustomerDto User { get; set; }
        public List<UpdateItemDto>? Goods { get; set; }
    }
}
