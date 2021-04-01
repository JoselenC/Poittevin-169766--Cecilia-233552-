
namespace MSP.BetterCalm.DataAccess
{
    public interface IMapper<D,T>
    {
        T DomainToDto(D obj);

        D DtoToDomain(T obj);

        void UpdateDtoObject<T, D>(T objToUpdate, D updatedObject) where T : class;
    }
}