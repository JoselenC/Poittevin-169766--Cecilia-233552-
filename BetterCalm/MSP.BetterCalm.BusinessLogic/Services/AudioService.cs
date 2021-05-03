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
            List<Audio> audios = new List<Audio>();
            foreach (var audio in repository.Audios.Get())
            {
                if(!audio.AssociatedToPlaylist)
                    audios.Add(audio);
            }
            return audios;
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

        public Audio SetAudio(Audio audio)
        {
            if (!AlreadyExistThisAudio(audio))
                return repository.Audios.Add(audio);
            else
                throw new AlreadyExistThisAudio();
        }

        public List<Audio> GetAudiosByName(string audioName)
        {
            List<Audio> audios = new List<Audio>();
            foreach (var audio in repository.Audios.Get())
            {
                if(audio.IsSameAudioName(audioName) && !audio.AssociatedToPlaylist)
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
                if(audio.IsSameAuthorName(authorName)&& !audio.AssociatedToPlaylist)
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
                if(audio.IsSameCategoryName(categroyName)&& !audio.AssociatedToPlaylist)
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
               Audio audio = repository.Audios.FindById(id);
               if (!audio.AssociatedToPlaylist)
                   return audio;
               throw new NotFoundId();
           }
           catch (KeyNotFoundException)
           {
               throw new NotFoundId();
           }
       }
    }
}
    