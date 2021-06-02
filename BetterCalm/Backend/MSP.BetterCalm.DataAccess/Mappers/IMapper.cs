namespace MSP.BetterCalm.DataAccess.Mappers
{
    public interface IMapper<D,T> where T: class 
    {
        T DomainToDto(D obj,ContextDb context);

        D DtoToDomain(T obj,ContextDb context);
        
        D GetById(ContextDb context, int id);

        T UpdateDtoObject (T objToUpdate, D updatedObject,ContextDb context);
    }
}