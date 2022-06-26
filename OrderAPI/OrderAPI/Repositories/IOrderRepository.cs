using OrderAPI.Entities;

namespace OrderAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderAsync(Guid id);
        Task<IEnumerable<Order>> GetOrdersAsync(string customerFirstname, string customerLastname, string phoneNumber);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Guid id);
    }
}