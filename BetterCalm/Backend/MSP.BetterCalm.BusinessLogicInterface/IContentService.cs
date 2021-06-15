using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogicInterface
{
    public interface IContentService
    {
        public List<Content> GetContents();
        public void SetContents(List<Content> contents);
        public Content SetContent(Content content);
        public List<Content> GetContentsByName(string contentName);
        public List<Content> GetContentsByAuthor(string authorName);
        public List<Content> GetContentsByCategoryName(string categoryName);
        public void DeleteContent(int id);
        public Content GetContentById(int id);
        public void UpdateContentById(int id, Content contentUpdated);
    }
}