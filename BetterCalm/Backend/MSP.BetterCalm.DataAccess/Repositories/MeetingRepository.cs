using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Repositories
{
    public class MeetingRepository : ManagerMeetingRepository
    {
        
        public MeetingRepository(IMapper<Meeting, MeetingDto> mapper, ContextDb context)
        {
            Meetings = new DataBaseRepository<Meeting, MeetingDto>(mapper, context.Meeting, context);
        }
    }
}