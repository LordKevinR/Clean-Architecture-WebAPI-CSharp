
namespace Application.Interfaces
{
    public interface ISinglePresenter<TEntity, TOutput>
    {
        public TOutput Present(TEntity entity);
    }
}
