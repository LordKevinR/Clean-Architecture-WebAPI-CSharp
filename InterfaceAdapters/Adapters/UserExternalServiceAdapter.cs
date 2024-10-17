using Application.Interfaces;
using Domain.Entities;
using InterfaceAdapters.DTOs.Users;

namespace InterfaceAdapters.Adapters
{
    public class UserExternalServiceAdapter : IExternalServiceAdapter<User>
    {
        private readonly IExternalService<UserServiceDTO> externalService;

        public UserExternalServiceAdapter(IExternalService<UserServiceDTO> externalService)
        {
            this.externalService = externalService;
        }
        public async Task<IEnumerable<User>> GetDataAsync()
        {
            var userServicesDTO = await externalService.GetContentAsync();
            var users = userServicesDTO.Select(u => new User
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Phone = u.Phone,
                Username = u.Username,
                Address = new Address
                {
                    City = u.Address.City,
                    Street = u.Address.Street,
                    Geo = new Geo
                    {
                        Lat = u.Address.Geo.Lat,
                        Lng = u.Address.Geo.Lng,
                    }
                },
                Company = new Company
                {
                    Name = u.Company.Name
                }
            });

            return users;
        }
    }
}
