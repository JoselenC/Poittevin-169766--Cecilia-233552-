using System.Collections.Generic;

namespace MSP.BetterCalm.Importer.Models
{
    public class ListContentModel
    {
        public List<ContentModel> ListContentModels { get; set; }

        public ListContentModel()
        {
            ListContentModels = new List<ContentModel>();
        }
    }
}