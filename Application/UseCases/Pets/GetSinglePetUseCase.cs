using Application.Interfaces;

namespace Application.UseCases.Pets
{
    public class GetSinglePetUseCase<TEntity, TOutput>
    {
        private readonly IRepository<TEntity> repository;
        private readonly ISinglePresenter<TEntity, TOutput> presenter;

        public GetSinglePetUseCase(IRepository<TEntity> repository, ISinglePresenter<TEntity, TOutput> presenter)
        {
            this.repository = repository;
            this.presenter = presenter;
        }

        public async Task<TOutput> ExecuteAsync(int id)
        {
            var pet = await repository.GetByIdAsync(id);
            return presenter.Present(pet);
        }
    }
}
