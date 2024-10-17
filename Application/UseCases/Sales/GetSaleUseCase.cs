using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Sales
{
    public class GetSaleUseCase
    {
        private readonly IRepository<Sale> repository;

        public GetSaleUseCase(IRepository<Sale> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Sale>> ExecuteAsync()
        {
            return await repository.GetAllAsync();
        }
    }
}
