using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;

namespace ImporterXml
{
    public class ImporterFromXml:IImporter
    {

        public string GetImporterName()
        {
            return "Xml";
        }

        public List<Content> ImportContent(string path)
        {
            List<Content> contents = new List<Content>();
            var xmlReader = XmlReader.Create(path);
            var xmlSerializer = new XmlSerializer(typeof(Content));
            Content contentParse = (Content)xmlSerializer.Deserialize(xmlReader);
            contents.Add(contentParse);
            xmlReader.Close();
            return contents;
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