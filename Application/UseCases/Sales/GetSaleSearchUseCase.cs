using Application.Interfaces;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.UseCases.Sales
{
    public class GetSaleSearchUseCase<TModel>
    {
        private readonly IRepositorySearch<TModel, Sale> repository;

        public GetSaleSearchUseCase(IRepositorySearch<TModel, Sale> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Sale>> ExecuteAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await repository.GetAsync(predicate);
        }
    }
}
