using System.Collections.Generic;
using System.Linq;
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
        public void GetSetPlaylistCategoryDto()
        {
            CategoryDto category = new CategoryDto();
            category.PlaylistCategoriesDto = new List<PlaylistCategoryDto>();
            CollectionAssert.AreEqual(category.PlaylistCategoriesDto.ToList(), new List<PlaylistCategoryDto>());
        }
        
        [TestMethod]
        public void GetSetSongCategoryDto()
        {
            CategoryDto category = new CategoryDto();
            category.SongsCategoriesDto = new List<SongCategoryDto>();
            ICollection<SongCategoryDto> getcategorySong= category.SongsCategoriesDto;
            CollectionAssert.AreEqual(getcategorySong.ToList(), new List<PlaylistCategoryDto>());
        }
    }
}