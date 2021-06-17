using System.Collections.Generic;
using System.IO;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;
using MSP.BetterCalm.Importer.Models;
using MSP.BetterCalm.WebAPI.Dtos;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ImporterJson
{
    public class ImporterFromJson:IImporter
    {
        
        public string GetImporterName()
        {
            return "Json";
        }

        public ListContentModel ImportContent(string path)
        {
            FileInfo jsonFile = new FileInfo(path);
            var jsontString = File.ReadAllText(jsonFile.FullName);
            ListContentModel listContentModels =JsonConvert.DeserializeObject<ListContentModel>(jsontString);
            return listContentModels;
           
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