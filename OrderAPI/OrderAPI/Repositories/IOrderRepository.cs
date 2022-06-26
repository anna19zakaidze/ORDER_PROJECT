using OrderAPI.Entities;

namespace OrderAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderAsync(Guid? id, string? customerFirstname, string? customerLastName, string? customerPhoneNumber);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Guid id);
    }
}