using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class MeetingRepository : ManagerMeetingRepository
    {
        
        public MeetingRepository(IMapper<Meeting, MeetingDto> mapper, ContextDB context)
        {
            Meetings = new DataBaseRepository<Meeting, MeetingDto>(mapper, context.Meeting, context);
        }
    }
}