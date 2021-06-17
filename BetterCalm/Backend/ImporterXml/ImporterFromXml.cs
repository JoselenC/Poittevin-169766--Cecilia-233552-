using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;
using MSP.BetterCalm.Importer.Models;

namespace ImporterXml
{
    public class ImporterFromXml:IImporter
    {

        public string GetImporterName()
        {
            return "Xml";
        }

        public ListContentModel ImportContent(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlNodeList xmlReader= xDoc.GetElementsByTagName("ListContentModels");
            ListContentModel contentParse = new ListContentModel();
            if (xmlReader.Count > 0)
            {
                for (int j = 0; j < xmlReader.Item(0).ChildNodes.Count; j = j + 8)
                {
                    XmlNode content = xmlReader.Item(0);
                    ContentModel contentModel = new ContentModel();
                    contentModel.Name = content.ChildNodes[j].InnerText;
                    contentModel.Duration = content.ChildNodes[j+1].InnerText;
                    contentModel.UrlImage = content.ChildNodes[j+2].InnerText;
                    contentModel.UrlArchive = content.ChildNodes[j+3].InnerText;
                    contentModel.Type = content.ChildNodes[j+4].InnerText;
                    contentModel.CreatorName = content.ChildNodes[j+5].InnerText;
                    XmlNodeList categories = content.ChildNodes[j+6].ChildNodes;
                    contentModel.Categories = new List<Category>();
                    foreach (XmlNode category in categories)
                    {
                        contentModel.Categories.Add(new Category() {Name = category.ChildNodes[0].InnerText});
                    }

                    XmlNodeList playlists = content.ChildNodes[j+7].ChildNodes;
                    contentModel.Playlists = new List<PlaylistModel>();
                    for (int i = 0; i < playlists.Count; i = i + 4)
                    {
                        PlaylistModel playlistModel = new PlaylistModel();
                        playlistModel.Name = playlists[i].InnerText;
                        playlistModel.Description = playlists[i + 1].InnerText;
                        playlistModel.UrlImage = playlists[i + 2].InnerText;
                        XmlNodeList playlistCategroie = playlists[i + 3].ChildNodes;
                        playlistModel.Categories = new List<Category>();
                        foreach (XmlNode category in playlistCategroie)
                        {
                            playlistModel.Categories.Add(new Category() {Name = category.InnerText});
                        }

                        contentModel.Playlists.Add(playlistModel);
                    }

                    contentParse.ListContentModels.Add(contentModel);
                }
            }

            return contentParse;
        }

        public List<Parameter> GetParameters()
        {
            return new List<Parameter> 
            {
                new Parameter {
                    Name = "Path",
                    Type  = "string"
                }
            };
        }
    }
}