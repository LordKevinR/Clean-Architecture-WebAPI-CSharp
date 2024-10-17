using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Sales
{
    public class GenerateSaleUseCase<TDTO>
    {
        private readonly IRepository<Sale> repository;
        private readonly IMapper<TDTO, Sale> mapper;

        public GenerateSaleUseCase(IRepository<Sale> repository, IMapper<TDTO, Sale> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task ExecuteAsync(TDTO saleDTO)
        {
            var sale = mapper.ToEntity(saleDTO);

            if (sale.Concepts.Count == 0)
            {
                throw new BadRequestValidationException("Concepts are mandatory for a sale");
            };

            if (sale.Total < 0)
            {
                throw new BadRequestValidationException("Total has to be grather than 0");
            };

            await repository.AddAsync(sale);
        }
    }
}