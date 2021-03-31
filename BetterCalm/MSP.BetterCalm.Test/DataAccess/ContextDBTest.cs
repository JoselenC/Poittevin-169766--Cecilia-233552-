using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class ContextDBTest
    {
        public  DataBaseRepository<Category, CategoryDto> Categories;
        public  DataBaseRepository<Problematic, ProblematicDto> Problematics;
        private ContextDB context = new ContextDB();
        
        [TestMethod]
        public void GetSetCategories()
        {
            Categories = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper());
            Category categoryTest = new Category()
            {
                Name = "Dormir",
            };
            Categories.Add(categoryTest);
            Microsoft.EntityFrameworkCore.DbSet<CategoryDto> getCategories= context.Categories;
        }
        
        [TestMethod]
        public void GetSetProblematics()
        {
            Problematics = new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper());
            Problematic problematicTest = new Problematic()
            {
                Name = "Estres",
            };
            Problematics.Add(problematicTest);
            Microsoft.EntityFrameworkCore.DbSet<ProblematicDto> getProblematics= context.Problematics;
        }
    }
}