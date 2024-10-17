
using InterfaceAdapters.Adapters;
using InterfaceAdapters.DTOs.Users;
using System.Text.Json;

namespace InterfaceAdapters.ExternalServices
{
    public class UserService : IExternalService<UserServiceDTO>
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions options;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }

        public async Task<IEnumerable<UserServiceDTO>> GetContentAsync()
        {
            var response = await httpClient.GetAsync(httpClient.BaseAddress);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();

            var postServiceDTO = JsonSerializer.Deserialize<IEnumerable<UserServiceDTO>>(responseData, options);
            return postServiceDTO;
        }
    }
}
