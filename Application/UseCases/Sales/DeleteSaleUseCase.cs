using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Sales
{
    public class DeleteSaleUseCase
    {
        private readonly IRepository<Sale> repository;

        public DeleteSaleUseCase(IRepository<Sale> repository)
        {
            this.repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestValidationException("Id must be greater than 0");

            await repository.DeleteAsync(id);
        }
    }
}
