using System.Linq;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Mappers
{
    public class AdministratorMapper: IMapper<Administrator, AdministratorDto>
    {
        public AdministratorDto DomainToDto(Administrator obj, ContextDb context)
        {
            AdministratorDto administratorDto = context.Administrators.FirstOrDefault(
                x => x.Email == obj.Email);
            if (administratorDto is null)
                administratorDto = new AdministratorDto()
                {
                    Name = obj.Name,
                    LastName = obj.LastName,
                    Email = obj.Email,
                    Password = obj.Password,
                    Token = obj.Token
                };
            return administratorDto;
        }

        public Administrator DtoToDomain(AdministratorDto obj, ContextDb context)
        {
            return new Administrator()
            {
                AdministratorId = obj.AdministratorDtoId,
                Name = obj.Name,
                LastName = obj.LastName,
                Email = obj.Email,
                Password = obj.Password,
                Token = obj.Token
            };
        }

        public Administrator GetById(ContextDb context, int id)
        {
            throw new System.NotImplementedException();
        }

        public AdministratorDto UpdateDtoObject(AdministratorDto objToUpdate, Administrator updatedObject, ContextDb context)
        {
            objToUpdate.Name = updatedObject.Name;
            objToUpdate.LastName = updatedObject.LastName;
            objToUpdate.Password = updatedObject.Password;
            objToUpdate.Token = updatedObject.Token;
            return objToUpdate;
        }
    }
}