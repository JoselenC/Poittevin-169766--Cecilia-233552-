using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass()]
    public class ProblematicMapperTest
    {
        private DbContextOptions<ContextDb> options;

        public  DataBaseRepository<Problematic, ProblematicDto> Problematics;
        public  Problematic problematicTest;
        private ContextDb context;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDb>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDb(this.options);
            Problematics = new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper(), context.Problematics, context);
            problematicTest = new Problematic() {Id=1, Name = "Dormir"};
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
            Problematic problematicTest = new Problematic() {Id=2, Name = "Estres"};
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
            problematicMapper.UpdateDtoObject(new ProblematicDto(), new Problematic(), new ContextDb());
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