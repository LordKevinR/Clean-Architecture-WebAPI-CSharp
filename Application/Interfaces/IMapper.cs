
namespace Application.Interfaces
{
    public interface IMapper<TDTO, TOutput>
    {
        public TOutput ToEntity(TDTO entity);
    }
}
