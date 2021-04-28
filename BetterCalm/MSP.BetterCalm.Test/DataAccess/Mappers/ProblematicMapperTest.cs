using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass()]
    public class ProblematicMapperTest
    {
        private DbContextOptions<ContextDB> options;

        public  DataBaseRepository<Problematic, ProblematicDto> Problematics;
        public  Problematic problematicTest;
        private ContextDB context;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDB(this.options);
            Problematics = new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper(), context.Problematics, context);
            problematicTest = new Problematic()
            {
                Id=1,
                Name = "Dormir",
            };
            Problematics.Add(problematicTest);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            context.Database.EnsureDeleted();
        }
        
        [TestMethod]
        public void DomainToDtoTest()
        {
            Problematic problematicTest = new Problematic()
            {
                Name = "Estres"
            };
            Problematics.Add(problematicTest);
            Problematic realProblematic = Problematics.Find(x => x.Name == "Estres");
            Assert.AreEqual(problematicTest, realProblematic);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Problematic realProblematic = Problematics.Find(x => x.Name == "Dormir");
            Assert.AreEqual(realProblematic, realProblematic);
        }
     
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void UpdateTest()
        {
            ProblematicMapper problematicMapper = new ProblematicMapper();
            problematicMapper.UpdateDtoObject(new ProblematicDto(), new Problematic(), new ContextDB());
        }
        
        [TestMethod]
        public void GetById()
        {
            Problematic realProblematic = Problematics.FindById(1);
            Assert.AreEqual(realProblematic, realProblematic);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void GetByIdNull()
        {
            Problematics.FindById(2);
        }
    }
}