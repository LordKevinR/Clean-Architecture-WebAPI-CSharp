namespace InterfaceAdapters.DTOs.Users
{
    public class UserServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public AddressDTO Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public CompanyDTO Company { get; set; }
    }
    public class GeoDTO
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class AddressDTO
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public GeoDTO Geo { get; set; }
    }

    public class CompanyDTO
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
