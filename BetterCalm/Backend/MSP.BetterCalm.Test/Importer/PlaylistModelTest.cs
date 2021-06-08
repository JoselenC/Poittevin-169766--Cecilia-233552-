using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Domain.Exceptions;
using MSP.BetterCalm.Importer;
using MSP.BetterCalm.Importer.Models;

namespace MSP.BetterCalm.Test.Importer
{
    [TestClass]
    public class PlaylistModelTest
    {
        [TestMethod]
        public void GetSetPlaylistModelName()
        {
            string playlistModelName = "Entrena tu mente";
            PlaylistModel playlistModel = new PlaylistModel();
            playlistModel.Name = "Entrena tu mente";
            string getPlaylistModelName = playlistModel.Name;
            Assert.AreEqual(playlistModelName, getPlaylistModelName);
        }
        
        [TestMethod]
        public void GetSetPlaylistModelDescriptionValidLength()
        {
            string playlistModelDescription = "Entrena tu mente";
            PlaylistModel playlistModel = new PlaylistModel();
            playlistModel.Description = "Entrena tu mente";
            string getDescription = playlistModel.Description;
            Assert.AreEqual(playlistModelDescription, getDescription);
        }
        
        
        [TestMethod]
        public void GetSetPlaylistModelUrlContent()
        {
            string description = "urlContentName";
            PlaylistModel playlistModel = new PlaylistModel();
            playlistModel.Description = "urlContentName";
            string getPlaylistModelDescription = playlistModel.Description;
            Assert.AreEqual(description, getPlaylistModelDescription);
        }

        
        [TestMethod]
        public void GetSetPlaylistModelUrlImage()
        {
            string ContentUrlImage = "https://www.google.com/search?q=paisaje&tbm=isch&ved=2ahUKEwifk_70vbHwAhWHMrkGHdFZCwUQ2-cCegQIABAA&oq=paisaje&gs_lcp=CgNpbWcQAzIECCMQJzIHCAAQsQMQQzIKCAAQsQMQgwEQQzIHCAAQsQMQQzIHCAAQsQMQQzIHCAAQsQMQQzIECAAQQzIECAAQQzICCAAyAggAOgUIABCxAzoICAAQsQMQgwFQrfQDWPD7A2CE_QNoAHAAeACAAY4CiAHRCZIBBTAuNS4ymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=cwGSYN-NCofl5OUP0bOtKA#imgrc=Mo3K6BpTEC_zGM";
            PlaylistModel Content = new PlaylistModel();
            Content.UrlImage = "https://www.google.com/search?q=paisaje&tbm=isch&ved=2ahUKEwifk_70vbHwAhWHMrkGHdFZCwUQ2-cCegQIABAA&oq=paisaje&gs_lcp=CgNpbWcQAzIECCMQJzIHCAAQsQMQQzIKCAAQsQMQgwEQQzIHCAAQsQMQQzIHCAAQsQMQQzIHCAAQsQMQQzIECAAQQzIECAAQQzICCAAyAggAOgUIABCxAzoICAAQsQMQgwFQrfQDWPD7A2CE_QNoAHAAeACAAY4CiAHRCZIBBTAuNS4ymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=cwGSYN-NCofl5OUP0bOtKA#imgrc=Mo3K6BpTEC_zGM";
            string getContentUrlImage = Content.UrlImage;
            Assert.AreEqual(ContentUrlImage, getContentUrlImage);
        }
        
        [TestMethod]
        public void GetSetPlaylistModelEmptyUrlImage()
        {
            string ContentUrlImage = "";
            PlaylistModel Content = new PlaylistModel();
            Content.UrlImage = "";
            string getContentUrlImage = Content.UrlImage;
            Assert.AreEqual(ContentUrlImage, getContentUrlImage);
        }

        [TestMethod]
        public void GetSetPlaylistModelCategories()
        {
            List<Category> categories = new List<Category>();
            PlaylistModel playlistModel = new PlaylistModel();
            playlistModel.Categories = categories;
            List<Category> getCategories = playlistModel.Categories;
            Assert.AreEqual(categories, getCategories);
        }
        
    }
}