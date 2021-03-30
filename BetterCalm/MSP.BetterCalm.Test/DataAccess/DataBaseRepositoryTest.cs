using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
   [TestClass]
    public class DataBaseRepositoryTest
    {
       
        public DataBaseRepository<Category, CategoryDto> Categories;
        public List<Category> AllCategories;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            Categories = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper());
            AllCategories = new List<Category>();
            CleanAllData();
        }

        [TestCleanup]
        public void CleanAllData()
        {
            foreach (Category category in Categories.Get())
            {
                Categories.Delete(category);
            }
        }
        
        [TestMethod]
        public void AddSuccessCaseTest()
        {
            Category categoryTest = new Category()
            {
                Name = "Dormir",
            };
            Categories.Add(categoryTest);
            Categories.Delete(categoryTest);
        }

        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
        public void DeleteTest()
        {
            Category category = new Category();
            category.Name = "Dormir";
            Categories.Add(category);
            Category testCategory = new Category()
            {
                Name = "Dormir"
            };
            Categories.Delete(testCategory);
            Category realCategory = Categories.Find(x => x.Name == testCategory.Name);
        }

        [TestMethod]
        public void FindTest()
        {
            Category category = new Category();
            category.Name = "Dormir";
            Categories.Add(category);
            Category actualCategory = Categories.Find(x => x.Name == "Dormir");
            Assert.AreEqual(category, actualCategory);
        }

        [TestMethod]
        public void GetTest()
        {
            List<Category> realAllCategories = Categories.Get();
            realAllCategories.Sort((x, y) => x.Name.CompareTo(y.Name));
            AllCategories.Sort((x, y) => x.Name.CompareTo(y.Name));
            CollectionAssert.AreEqual(AllCategories, realAllCategories);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void SetTest()
        {
            Categories.Set(AllCategories);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void UpdateTest()
        {
            Category category = new Category();
            category.Name = "Dormir";
            Category categoryDormirUpdated = new Category()
            {
                Name = "Yoga",
            };
            Categories.Update(category, categoryDormirUpdated);

            Category realCategoryUpdated = Categories.Find(x => x.Name == "Yoga");

            Assert.AreEqual(categoryDormirUpdated, realCategoryUpdated);
            Categories.Update(categoryDormirUpdated, category);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void UpdateProblematicTest()
        {

            DataBaseRepository<Problematic, ProblematicDto> Problematics = new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper());
            Problematic problematic = new Problematic();
            problematic.Name = "Estres";
            Problematic problematicUpdated = new Problematic()
            {
                Name = "Angustia",
            };
            Problematics.Update(problematic, problematicUpdated);

            Problematic realProblematicUpdated = Problematics.Find(x => x.Name == "Estres");

            Assert.AreEqual(problematicUpdated, realProblematicUpdated);
            Problematics.Update(realProblematicUpdated, problematic);
        }
    }
}