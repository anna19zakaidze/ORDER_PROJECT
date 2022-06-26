using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Dtos.CreateOrderDto
{
    public record UpdateCustomerDto
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
    }
}
