using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;


namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class CategoryDTOTest
    {
        [TestMethod]
        public void SetGetCategoryDtoId()
        {
            CategoryDto categoryDto = new CategoryDto();
            categoryDto.CategoryDtoID = 1;
            Assert.AreEqual(1, categoryDto.CategoryDtoID);
        }

        [TestMethod]
        public void SetGetName()
        {
            CategoryDto categoryDto = new CategoryDto();
            categoryDto.Name = "food";
            Assert.AreEqual("food", categoryDto.Name);
        }

        [TestMethod]
        public void SetGetSongDtoId()
        {
            CategoryDto categoryDto = new CategoryDto();
            categoryDto.SongDtoID = 1;
            Assert.AreEqual(1, categoryDto.SongDtoID);
        }
        [TestMethod]
        public void SetGePlaylistDtoId()
        {
            CategoryDto categoryDto = new CategoryDto();
            categoryDto.PlaylistDtoID = 1;
            Assert.AreEqual(1, categoryDto.PlaylistDtoID);
        }
        
        [TestMethod]
        public void SetGetSongDto()
        {
            CategoryDto categoryDto = new CategoryDto();
            SongDto songDto = new SongDto();
            categoryDto.SongDto = songDto;
            Assert.AreEqual(songDto, categoryDto.SongDto);
        }
        
        [TestMethod]
        public void SetGetPlaylistDtoDto()
        {
            CategoryDto categoryDto = new CategoryDto();
            PlaylistDto playlistDto = new PlaylistDto();
            categoryDto.PlaylistDto = playlistDto;
            Assert.AreEqual(playlistDto, categoryDto.PlaylistDto);
        }
    }
}