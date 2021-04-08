using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;


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
            categoryDto.SongDto = new SongDto();
            Assert.AreEqual(new SongDto(), categoryDto.SongDto);
        }
        
        [TestMethod]
        public void SetGetPlaylistDtoDto()
        {
            CategoryDto categoryDto = new CategoryDto();
            categoryDto.PlaylistDto = new PlaylistDto();
            Assert.AreEqual(new PlaylistDto(), categoryDto.PlaylistDto);
        }
    }
}