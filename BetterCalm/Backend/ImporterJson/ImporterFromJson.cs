using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;

namespace ImporterJson
{
    public class ImporterFromJson:IImporter
    {
        public string GetImporterName()
        {
            return "Json";
        }

        public List<Content> ImportContent(string path)
        {
            List<Content> contents = new List<Content>();
            FileInfo jsonFile = new FileInfo(path);
            var jsontString = File.ReadAllText(jsonFile.FullName);
            var contentParse = JsonSerializer.Deserialize<Content>(jsontString);
            Content content = new Content() {
                Name = contentParse.Name,
                Categories = contentParse.Categories,
                Duration = contentParse.Duration,
                CreatorName = contentParse.CreatorName,
                UrlArchive = contentParse.UrlArchive,
                UrlImage = contentParse.UrlImage,
                Type = "audio"
            };
            contents.Add(content);
            return contents;
        }

        public List<Parameter> GetParameters()
        {
            return new List<Parameter> 
            {
                new Parameter {
                    Name = "Path",
                    Type = "string"
                }
            };
        }
    }
}