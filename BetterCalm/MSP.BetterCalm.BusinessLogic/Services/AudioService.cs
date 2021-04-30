using System;
using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class AudioService:IAudioService
    {
        private ManagerAudioRepository repository;

        public AudioService(ManagerAudioRepository vRepository)
        {
            repository = vRepository;
        }
        
        public List<Audio> GetAudios()
        {
            return repository.Audios.Get();
        }

        private bool AlreadyExistThisAudio(Audio audio)
        {
            try
            {
                repository.Audios.FindById(audio.Id);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
                
        }

        public void AddAudio(Audio audio)
        {
            if (!AlreadyExistThisAudio(audio))
                repository.Audios.Add(audio);
            else
                throw new AlreadyExistThisAudio();
        }

        public List<Audio> GetAudiosByName(string audioName)
        {
            List<Audio> audios = new List<Audio>();
            foreach (var audio in repository.Audios.Get())
            {
                if(audio.IsSameAudioName(audioName))
                    audios.Add(audio);
            }
            if (audios.Count == 0)
                throw new NotFoundAudio();
            return audios;
        }

        public List<Audio> GetAudiosByAuthor(string authorName)
        {
            List<Audio> audios = new List<Audio>();
            foreach (var audio in repository.Audios.Get())
            {
                if(audio.IsSameAuthorName(authorName))
                    audios.Add(audio);
            }
            if (audios.Count == 0)
                throw new NotFoundAudio();
            return audios;
        }

        public List<Audio> GetAudiosByCategoryName(string categroyName)
        {
            List<Audio> audios = new List<Audio>();
            foreach (Audio audio in repository.Audios.Get())
            {
                if(audio.IsSameCategoryName(categroyName))
                    audios.Add(audio);
            }
            if (audios.Count == 0)
                throw new NotFoundAudio();
            return audios;
        }

        public void UpdateAudioById(int id, Audio audioUpdated)
        {
            try
            {
                Audio audioToUpdate = repository.Audios.FindById(id);
                repository.Audios.Update(audioToUpdate, audioUpdated);
            }
            catch (KeyNotFoundException)
            {
                throw new ObjectWasNotUpdated();
            }
        }
        
        public void DeleteAudio(List<Audio> playlistAudio)
        {
            if (playlistAudio != null)
            {
                foreach (var audio in playlistAudio)
                {
                    DeleteAudio(audio.Id);
                }
            }
        }

       public void DeleteAudio(int id)
        {
            try
            {
                Audio audioToDelete = repository.Audios.FindById(id);
                repository.Audios.Delete(audioToDelete);
            }
            catch (KeyNotFoundException)
            {
                throw new ObjectWasNotDeleted();
            }
        }

       public Audio GetAudioById(int id)
       {
           try
           {
               return repository.Audios.FindById(id);
           }
           catch (KeyNotFoundException)
           {
               throw new NotFoundId();
           }
       }
    }
}
    