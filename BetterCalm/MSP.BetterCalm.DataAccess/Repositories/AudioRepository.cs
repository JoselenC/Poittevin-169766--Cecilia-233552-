using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class AudioRepository:ManagerAudioRepository
    {
        public AudioRepository(IMapper<Audio, AudioDto> mapper, ContextDB context)
        {
            Audios = new DataBaseRepository<Audio, AudioDto>(mapper, context.Audios, context);
        }
    }
}