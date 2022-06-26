namespace OrderAPI.Entities
{
    public class Customer
    {
        public Guid Id { get; init; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
    }
}
