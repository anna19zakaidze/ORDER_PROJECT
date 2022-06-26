//using OrderAPI.Entities;

//namespace OrderAPI.Repositories
//{
//    public class InMemOrderRepository : IOrderRepository
//    {
//        private readonly List<Order> orders = new()
//        {
//            new Order
//            {
//                Id = Guid.NewGuid(), OrderDate = DateTimeOffset.UtcNow,
//                Goods = new List<Item>
//                {
//                    new Item
//                    {
//                        Id = 1,
//                        Name="Top",
//                        Size="S",
//                        Color="Red",
//                        Quantity=1,
//                        Price=20
//                    }
//                },
//                User = new Customer
//                {
//                    Id = Guid.NewGuid(),
//                    Firstname="Anna",
//                    Lastname="Zakaidze",
//                    Address="Tbilisi, Liakhvi Street",
//                    TelephoneNumber="599243355"
//                }
//            },
//            new Order
//            {
//                Id = Guid.NewGuid(), OrderDate = DateTimeOffset.UtcNow,
//                Goods = new List<Item>
//                {
//                    new Item
//                    {
//                        Id = 2,
//                        Name="Skirt",
//                        Size="XS",
//                        Color="White",
//                        Quantity=1,
//                        Price=62
//                    }
//                },
//                User = new Customer
//                {
//                    Id = Guid.NewGuid(),
//                    Firstname="Nino",
//                    Lastname="Maisuradze",
//                    Address="Tbilisi, Ateni Street",
//                    TelephoneNumber="599132462"
//                }
//            },
//            new Order
//            {
//                Id = Guid.NewGuid(), OrderDate = DateTimeOffset.UtcNow,
//                Goods = new List<Item>
//                {
//                    new Item
//                    {
//                        Id = 3,
//                        Name="Trousers",
//                        Size="L",
//                        Color="Black",
//                        Quantity=1,
//                        Price=120
//                    }
//                },
//                User = new Customer
//                {
//                    Id = Guid.NewGuid(),
//                    Firstname="George",
//                    Lastname="Beridze",
//                    Address="Tbilisi, Tashkenti Street",
//                    TelephoneNumber="557893425"
//                }
//            }
//        };
//        public IEnumerable<Order> GetOrdersAsync()
//        {
//            return orders;
//        }
//        public Task<Order> GetOrderAsync(Guid? id, string? customerFirstname, string? customerLastName, string? customerPhoneNumber)
//        {
//            return await orders.Where(order => order.Id == id 
//            || order.User.Firstname == customerFirstname
//            || order.User.Lastname == customerLastName
//            || order.User.TelephoneNumber == customerPhoneNumber).SingleOrDefault();
//        }

//        public void CreateOrderAsync(Order order)
//        {
//            orders.Add(order);
//        }

//        public void UpdateOrderAsync(Order order)
//        {
//            var index = orders.FindIndex(existing => existing.Id == order.Id);
//            orders[index] = order;
//        }

//        public void DeleteOrderAsync(Guid id)
//        {
//            var index = orders.FindIndex(existing => existing.Id == id);

//            orders.RemoveAt(index);
//        }
//    }
//}
