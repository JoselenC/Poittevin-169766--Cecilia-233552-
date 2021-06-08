#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;
using MSP.BetterCalm.Importer.Models;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public class ImportService:IImportService
    {
        private IContentService _contentService;

        private IPlaylistService _playlistService;
        private string _path=@"../MSP.BetterCalm.WebAPI/Parser/";
       
        public ImportService(IContentService contentService,IPlaylistService playlistService)
        {
            _contentService = contentService;
            _playlistService = playlistService;
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

        public ListContentModel ImportContent(Import import)
        {
            var directory = new DirectoryInfo(_path);
            FileInfo[] files = directory.GetFiles("*.dll");
            foreach (var file in files)
            {
                Assembly assembly = Assembly.LoadFile(file.FullName);
                Type type = assembly.GetTypes().FirstOrDefault(t => typeof(IImporter).IsAssignableFrom(t) && t.IsClass)!;
                if (typeof(IImporter).IsAssignableFrom(type))
                {
                    IImporter importer = (Activator.CreateInstance(type) as IImporter)!;
                    if (importer.GetImporterName() == import.Name)
                    {
                        ListContentModel listContentModels =
                            importer.ImportContent(import.Path) ?? new ListContentModel();
                        foreach (var contentModel in listContentModels.ListContentModels)
                        {
                            SetContent(contentModel);
                        }

                        return listContentModels;
                    }
                }
            }
            
            throw new NotImplementedImport();
        }

        private bool IsDurationValid(string duration)
        {
            string pattern = @"^([0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9])[hms]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(duration);
        }

        public int SetDuration(string Duration)
        {
            if (IsDurationValid(Duration.ToLower()))
            {
                if (Duration.ToLower().Contains('h'))
                    return Int32.Parse(Duration.ToLower().Split('h')[0]) * 60 * 60;
                else if (Duration.ToLower().Contains('m'))
                    return Int32.Parse(Duration.ToLower().Split('m')[0]) * 60;
                else if (Duration.ToLower().Contains('s'))
                    return Int32.Parse(Duration.ToLower().Split('s')[0]);
            }
            throw new InvalidDurationFormat();
        }
        
        public void SetContent(ContentModel contentModel)
        {
            Content content = new Content()
            {
                Name = contentModel.Name,
                CreatorName = contentModel.CreatorName,
                Duration = SetDuration(contentModel.Duration),
                UrlArchive = contentModel.UrlArchive,
                UrlImage = contentModel.UrlImage,
                Categories = contentModel.Categories,
                Type= contentModel.Type
            };
            
            if (contentModel.Playlists != null)
            {
                if (contentModel.Playlists.Count > 0)
                    content.AssociatedToPlaylist = true;
                foreach (var playlist in contentModel.Playlists)
                {
                    Playlist playlistToAdd = new Playlist()
                    {
                        Categories = playlist.Categories,
                        Contents = new List<Content>() {content},
                        Description = playlist.Description,
                        Name = playlist.Name,
                        UrlImage = playlist.UrlImage
                    };
                    _playlistService.SetPlaylist(playlistToAdd);
                }
            }
            _contentService.SetContent(content);
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