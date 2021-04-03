
using Microsoft.EntityFrameworkCore;

namespace MSP.BetterCalm.DataAccess
{
    public interface IMapper<D,T> where T: class 
    {
        T DomainToDto(D obj,DbSet<T> entity);

        D DtoToDomain(T obj,DbSet<T> entity);

        void UpdateDtoObject(T objToUpdate, D updatedObject, DbSet<T> entity);
    }
}