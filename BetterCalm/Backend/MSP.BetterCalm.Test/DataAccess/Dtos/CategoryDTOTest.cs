using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;


namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class CategoryDTOTest
    {
        [TestMethod]
        public void SetGetCategoryDtoId()
        {
            CategoryDto categoryDto = new CategoryDto();
            categoryDto.CategoryDtoId = 1;
            Assert.AreEqual(1, categoryDto.CategoryDtoId);
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
            category.ContentsCategoriesDto = new List<ContentCategoryDto>();
            ICollection<ContentCategoryDto> getcategorySong= category.ContentsCategoriesDto;
            CollectionAssert.AreEqual(getcategorySong.ToList(), new List<PlaylistCategoryDto>());
        }
        
    }
}