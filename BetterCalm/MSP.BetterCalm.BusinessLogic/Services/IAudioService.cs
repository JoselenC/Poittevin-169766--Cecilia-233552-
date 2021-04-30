using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface IAudioService
    {
        public List<Audio> GetAudios();
        public void AddAudio(Audio audio);
        public List<Audio> GetAudiosByName(string audioName);
        public List<Audio> GetAudiosByAuthor(string authorName);
        public List<Audio> GetAudiosByCategoryName(string categoryName);
        public void DeleteAudio(int id);
        void DeleteAudio(List<Audio> playlistAudio);
        public Audio GetAudioById(int id);
        public void UpdateAudioById(int id, Audio audioUpdated);
    }
}