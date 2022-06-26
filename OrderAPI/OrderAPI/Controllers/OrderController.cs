using Microsoft.AspNetCore.Mvc;
using OrderAPI.Dtos;
using OrderAPI.Dtos.CreateOrderDto;
using OrderAPI.Dtos.GetOrderDto;
using OrderAPI.Dtos.UpdateOrderDto;
using OrderAPI.Entities;
using OrderAPI.Helpers;
using OrderAPI.Repositories;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("Orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository repository;
        public OrderController(IOrderRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            var orders =await repository.GetOrdersAsync();
            return orders;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderAsync(Guid? id,string? customerFirstname, string? customerLastName, string? customerPhoneNumber)
        {
            var order = await repository.GetOrderAsync(id,customerFirstname, customerLastName, customerPhoneNumber);
            if(order is null)
            {
                return NotFound();
            }
            return order;
        }
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrderAsync(CreateOrderDto orderDto)
        {
            var goods = new List<Item>();
            foreach (var item in orderDto.Goods)
            {
                var quantity = item.Quantity;
                goods.Add(new Item()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price * quantity,
                    Color = item.Color,
                    Quantity = item.Quantity,
                    Size = item.Size
                });
            }
            Order order = new()
            {
                Id = Guid.NewGuid(),
                OrderDate = DateTimeOffset.UtcNow,
                User = new Customer()
                {
                    Id = Guid.NewGuid(),
                    Firstname = orderDto.User.Firstname,
                    Lastname = orderDto.User.Lastname,
                    TelephoneNumber = orderDto.User.TelephoneNumber,
                    Address = orderDto.User.Address
                },
                Goods = goods
            };
            await repository.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrderAsync),new {id=order.Id},order);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderAsync(Guid id, UpdateOrderDto order)
        {
            var orderToUpdate = repository.GetOrderAsync(id,null,null,null);
            if(orderToUpdate is null)
            {
                return NotFound();
            }
            var goods = new List<Item>();
            foreach (var item in order.Goods)
            {
                var quantity = item.Quantity;
                goods.Add(new Item()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price * quantity,
                    Color = item.Color,
                    Quantity = item.Quantity,
                    Size = item.Size
                });
            }
            Order updatedOrder = orderToUpdate.Result with
            {
                OrderDate = DateTimeOffset.UtcNow,
                User = new Customer
                {
                    Address = order.User.Address,
                    Firstname = order.User.Firstname,
                    Lastname = order.User.Lastname,
                    TelephoneNumber = order.User.TelephoneNumber
                },
                Goods = goods
            };
            await repository.UpdateOrderAsync(updatedOrder);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderAsync(Guid id)
        {
            var orderToUpdate = repository.GetOrderAsync(id, null, null, null);
            if (orderToUpdate is null)
            {
                return NotFound();
            }
            await repository.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
