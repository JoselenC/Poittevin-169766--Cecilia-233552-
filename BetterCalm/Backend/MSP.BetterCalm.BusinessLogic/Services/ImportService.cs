#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public class ImportService:IImportService
    {
        private IContentService _contentService;

        public string _path=@"../MSP.BetterCalm.WebAPI/Parser/";
       
        public ImportService(IContentService contentService)
        {
            _contentService = contentService;
        }
        
        public List<string> GetImportersName()
        {
            List<string> names = new List<string>();
            var directory = new DirectoryInfo(_path);
            FileInfo[] files = directory.GetFiles("*.dll");
            foreach (var file in files)
            {
                Assembly assembly = Assembly.LoadFile(file.FullName);
                Type type = assembly.GetTypes().FirstOrDefault(t => typeof(IImporter).IsAssignableFrom(t) && t.IsClass)!;
                if (typeof(IImporter).IsAssignableFrom(type))
                {
                    try
                    {
                        var importer = Activator.CreateInstance(type) as IImporter;
                        if (importer != null) names.Add(importer.GetImporterName());
                    }
                    catch (Exception e)
                    {
                        throw new NotImplementedImport();
                    }
                }
            }
            return names;
        }

        public List<Content> ImportContent(Import import)
        {
            var directory = new DirectoryInfo(_path);
            FileInfo[] files = directory.GetFiles("*.dll");
            foreach (var file in files)
            {
                Assembly assembly = Assembly.LoadFile(file.FullName);
                Type type = assembly.GetTypes().FirstOrDefault(t => typeof(IImporter).IsAssignableFrom(t) && t.IsClass)!;
                if (typeof(IImporter).IsAssignableFrom(type))
                {
                    try
                    {
                        IImporter importer = (Activator.CreateInstance(type) as IImporter)!;
                        List<Content> importedContent = importer.ImportContent(import.Path);
                        _contentService.SetContents(importedContent);
                        return importedContent;
                    }
                    catch (Exception e)
                    {
                        throw new NotImplementedImport();
                    }
                }
            }
            throw new NotImplementedImport();
        }


        public List<Parameter> GetParameters()
        {
            var directory = new DirectoryInfo(_path);
            FileInfo[] files = directory.GetFiles("*.dll");
            foreach (var file in files)
            {
                Assembly assembly = Assembly.LoadFile(file.FullName);
                Type type = assembly.GetTypes()
                    .FirstOrDefault(t => typeof(IImporter).IsAssignableFrom(t) && t.IsClass)!;
                if (typeof(IImporter).IsAssignableFrom(type))
                {
                    try
                    {
                        IImporter importer = (Activator.CreateInstance(type) as IImporter)!;
                        return importer.GetParameters();
                    }
                    catch (Exception e)
                    {
                        throw new NotImplementedImport();
                    }
                }
            }
            throw new NotImplementedImport();
        }
    }
}