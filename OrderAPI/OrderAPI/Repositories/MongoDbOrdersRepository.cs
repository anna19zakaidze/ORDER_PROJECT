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

        public async Task<Order> GetOrderAsync(Guid? id, string? customerFirstname, string? customerLastName, string? customerPhoneNumber)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            //filter &= (Builders<Order>.Filter.Eq(item => item.User.Firstname, customerFirstname) 
            //    | Builders<Order>.Filter.Eq(item => item.User.Lastname, customerLastName)
            //    | Builders<Order>.Filter.Eq(item=>item.User.TelephoneNumber, customerPhoneNumber));
            return await orderCollection.Find(filter).SingleOrDefaultAsync();

        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await orderCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var filter = filterBuilder.Eq(item => item.Id, order.Id);
            await orderCollection.ReplaceOneAsync(filter,order);
        }
    }
}
