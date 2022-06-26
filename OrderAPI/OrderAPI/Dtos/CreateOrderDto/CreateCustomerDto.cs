using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Dtos.UpdateOrderDto
{
    public record CreateCustomerDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
    }
}
