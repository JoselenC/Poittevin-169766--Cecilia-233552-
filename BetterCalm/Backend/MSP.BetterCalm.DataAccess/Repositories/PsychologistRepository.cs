using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Repositories
{
    public class PsychologistRepository: ManagerPsychologistRepository
    {
        public PsychologistRepository(IMapper<Psychologist, PsychologistDto> mapper, ContextDb context)
        {
            Psychologists =
                new DataBaseRepository<Psychologist, PsychologistDto>(mapper, context.Psychologists, context);
        }
    }
}