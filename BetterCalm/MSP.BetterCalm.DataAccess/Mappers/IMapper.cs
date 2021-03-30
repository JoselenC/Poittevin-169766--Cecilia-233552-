using System.Data.Entity;

namespace MSP.BetterCalm.DataAccess
{
    public interface IMapper<D,T>
    {
        T DomainToDto(D obj, ContextDB context);

        D DtoToDomain(T obj, ContextDB context);

        void UpdateDtoObject<T, D>(T objToUpdate, D updatedObject, ContextDB context) where T : class;
    }
}