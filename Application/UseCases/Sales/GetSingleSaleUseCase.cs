using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Sales
{
    public class GetSingleSaleUseCase
    {
        private readonly IRepository<Sale> repository;

        public GetSingleSaleUseCase(IRepository<Sale> repository)
        {
            this.repository = repository;
        }

        public async Task<Sale> ExecuteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestValidationException("Id must be greater than 0");

            return await repository.GetByIdAsync(id);
        }
    }
}
