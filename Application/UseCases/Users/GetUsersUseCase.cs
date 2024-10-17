
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Users
{
    public class GetUsersUseCase
    {
        private readonly IExternalServiceAdapter<User> adapter;

        public GetUsersUseCase(IExternalServiceAdapter<User> adapter)
        {
            this.adapter = adapter;
        }

        public async Task<IEnumerable<User>> ExecuteAsync()
        {
            return await adapter.GetDataAsync();
        }
    }
}
