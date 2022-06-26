using MongoDB.Bson;
using MongoDB.Driver;
using OrderAPI.Entities;

namespace OrderAPI.Repositories
{
    public class MongoDbOrdersRepository : IOrderRepository
    {
        private const string databaseName = "order";
        private const string collectionName = "orders";
        private readonly IMongoCollection<Order> orderCollection;
        private readonly FilterDefinitionBuilder<Order> filterBuilder = Builders<Order>.Filter;
        public MongoDbOrdersRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            orderCollection = database.GetCollection<Order>(collectionName);
        }
        public async Task CreateOrderAsync(Order order)
        {
            await orderCollection.InsertOneAsync(order);
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            await orderCollection.DeleteOneAsync(filter);
        }

        public async Task<Order> GetOrderAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return await orderCollection.Find(filter).SingleOrDefaultAsync();

        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(string? customerFirstname, string? customerLastname, string phoneNumber)
        {
            var filterWithLastname = filterBuilder.Eq(item => item.User.Lastname, customerLastname);
            var filterWithFirstname = filterBuilder.Eq(item => item.User.Firstname, customerFirstname);
            var filterWithPhoneNumber = filterBuilder.Eq(item => item.User.TelephoneNumber, phoneNumber);
            if(customerLastname is not null) {
                return await orderCollection.Find(filterWithLastname).ToListAsync();
            }
            if (customerFirstname is not null)
            {
                return await orderCollection.Find(filterWithFirstname).ToListAsync();
            }
            if (phoneNumber is not null)
            {
                return await orderCollection.Find(filterWithPhoneNumber).ToListAsync();
            }
            return await orderCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var filter = filterBuilder.Eq(item => item.Id, order.Id);
            await orderCollection.ReplaceOneAsync(filter,order);
        }
    }
}
