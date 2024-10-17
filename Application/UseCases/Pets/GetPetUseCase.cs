using Application.Interfaces;

namespace Application.UseCases.Pets
{
    public class GetPetUseCase<TEntity, TOutput>
    {
        private readonly IRepository<TEntity> repository;
        private readonly IPresenter<TEntity, TOutput> presenter;

        public GetPetUseCase(IRepository<TEntity> repository, IPresenter<TEntity, TOutput> presenter)
        {
            this.repository = repository;
            this.presenter = presenter;
        }

        public async Task<IEnumerable<TOutput>> ExecuteAsync()
        {
            var pets =  await repository.GetAllAsync();
            return presenter.Present(pets);
        }
    }
}
