
using Microsoft.EntityFrameworkCore;

namespace MSP.BetterCalm.DataAccess
{
    public interface IMapper<D,T> where T: class 
    {
        T DomainToDto(D obj,ContextDB context);

        D DtoToDomain(T obj,ContextDB context);

        T UpdateDtoObject (T objToUpdate, D updatedObject,ContextDB context);
    }
}