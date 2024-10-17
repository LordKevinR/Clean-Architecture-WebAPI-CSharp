
namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public Company Company { get; set; }
    }
    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public Geo Geo { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
    }
}
