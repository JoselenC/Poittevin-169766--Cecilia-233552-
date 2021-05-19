using System.Collections.Generic;
using System.Linq;
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
        public void GetSetPlaylistCategoryDto()
        {
            CategoryDto category = new CategoryDto();
            category.PlaylistCategoriesDto = new List<PlaylistCategoryDto>();
            CollectionAssert.AreEqual(category.PlaylistCategoriesDto.ToList(), new List<PlaylistCategoryDto>());
        }
        
        [TestMethod]
        public void GetSetVideoCategoryDto()
        {
            CategoryDto category = new CategoryDto();
            category.VideosCategoriesDto = new List<VideoCategoryDto>();
            CollectionAssert.AreEqual(category.VideosCategoriesDto.ToList(), new List<VideoCategoryDto>());
        }
        
        [TestMethod]
        public void GetSetSongCategoryDto()
        {
            CategoryDto category = new CategoryDto();
            category.AudiosCategoriesDto = new List<AudioCategoryDto>();
            ICollection<AudioCategoryDto> getcategorySong= category.AudiosCategoriesDto;
            CollectionAssert.AreEqual(getcategorySong.ToList(), new List<PlaylistCategoryDto>());
        }
        
    }
}