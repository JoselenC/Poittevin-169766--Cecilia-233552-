using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public class ContentService:IContentService
    {
        private ManagerContentRepository _repository;

        public ContentService(ManagerContentRepository vRepository)
        {
            _repository = vRepository;
        }
        
        public List<Content> GetContents()
        {
            List<Content> contents = new List<Content>();
            foreach (var content in _repository.Contents.Get())
            {
                if(!content.AssociatedToPlaylist)
                    contents.Add(content);
            }
            return contents;
        }

        public void SetContents(List<Content> contents)
        {
            foreach (var content in contents)
            {
                SetContent(content);
            }
        }

        private bool AlreadyExistThisContent(Content content)
        {
            try
            {
                _repository.Contents.FindById(content.Id);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public Content SetContent(Content content)
        {
            if (!AlreadyExistThisContent(content))
                return _repository.Contents.Add(content);
            
            throw new AlreadyExistThisContent();
        }

        public List<Content> GetContentsByName(string contentName)
        {
            List<Content> contents = new List<Content>();
            foreach (var content in _repository.Contents.Get())
            {
                if(content.IsSameContentName(contentName) && !content.AssociatedToPlaylist)
                    contents.Add(content);
            }
            if (contents.Count == 0)
                throw new NotFoundContent();
            return contents;
        }

        public List<Content> GetContentsByAuthor(string authorName)
        {
            List<Content> contents = new List<Content>();
            foreach (var content in _repository.Contents.Get())
            {
                if(content.IsSameAuthorName(authorName)&& !content.AssociatedToPlaylist)
                    contents.Add(content);
            }
            if (contents.Count == 0)
                throw new NotFoundContent();
            return contents;
        }

        public List<Content> GetContentsByCategoryName(string categroyName)
        {
            List<Content> contents = new List<Content>();
            foreach (Content content in _repository.Contents.Get())
            {
                if(content.IsSameCategoryName(categroyName)&& !content.AssociatedToPlaylist)
                    contents.Add(content);
            }
            if (contents.Count == 0)
                throw new NotFoundContent();
            return contents;
        }

        public void UpdateContentById(int id, Content contentUpdated)
        {
            try
            {
                Content contentToUpdate = _repository.Contents.FindById(id);
                _repository.Contents.Update(contentToUpdate, contentUpdated);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundContent();
            }
        }
    
       public void DeleteContent(int id)
        {
            try
            {
                Content contentToDelete = _repository.Contents.FindById(id);
                _repository.Contents.Delete(contentToDelete);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundContent();
            }
        }

       public Content GetContentById(int id)
       {
           try
           {
               Content content = _repository.Contents.FindById(id);
               if (!content.AssociatedToPlaylist)
                   return content;
               throw new NotFoundId();
           }
           catch (KeyNotFoundException)
           {
               throw new NotFoundId();
           }
       }
    }
}
    