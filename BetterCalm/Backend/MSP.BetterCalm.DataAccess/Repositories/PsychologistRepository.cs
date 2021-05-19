using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class PsychologistRepository: ManagerPsychologistRepository
    {
        public PsychologistRepository(IMapper<Psychologist, PsychologistDto> mapper, ContextDB context)
        {
            Psychologists =
                new DataBaseRepository<Psychologist, PsychologistDto>(mapper, context.Psychologists, context);
        }
    }
}