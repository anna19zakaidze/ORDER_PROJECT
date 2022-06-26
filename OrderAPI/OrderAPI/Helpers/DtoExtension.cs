using OrderAPI.Dtos;
using OrderAPI.Dtos.GetOrderDto;
using OrderAPI.Entities;

namespace OrderAPI.Helpers
{
    public static class DtoExtension
    {
        public static GetOrderDto AsDto(this Order order)
        {
            return new GetOrderDto
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate,
                User = new GetCustomerDto
                {
                    Id = order.User.Id,
                    Firstname = order.User.Firstname,
                    Lastname = order.User.Lastname,
                    TelephoneNumber = order.User.TelephoneNumber,
                    Address = order.User.Address
                },
                Goods = (List<GetItemDto>)order.Goods.Select(good => new GetItemDto
                {
                    Id = good.Id,
                    Name = good.Name,
                    Price = good.Price,
                    Color = good.Color,
                    Size = good.Size,
                    Quantity = good.Quantity
                })

            };
        }
    }
}
