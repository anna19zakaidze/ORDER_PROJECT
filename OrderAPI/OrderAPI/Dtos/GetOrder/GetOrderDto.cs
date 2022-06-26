namespace OrderAPI.Dtos.GetOrderDto
{
    public record GetOrderDto
    {
        public Guid OrderId { get; init; }
        public DateTimeOffset OrderDate { get; set; }
        public GetCustomerDto User { get; set; }
        public List<GetItemDto>? Goods { get; set; }
    }
}
