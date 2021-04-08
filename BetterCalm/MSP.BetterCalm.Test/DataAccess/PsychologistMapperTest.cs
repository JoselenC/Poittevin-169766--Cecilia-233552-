using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PsychologistMapperTest
    {
        private DbContextOptions<ContextDB> options;
        public  DataBaseRepository<Psychologist, PsychologistDto> RepoPsychologists;
        public  Psychologist psychologistTest;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            ContextDB context = new ContextDB(this.options);
            RepoPsychologists = new DataBaseRepository<Psychologist, PsychologistDto>(new PsychologistMapper(), context.Psychologists, context);
            psychologistTest = new Psychologist()
            {
                Name = "Roberto",
                LastName = "Alex",
                Address = "PsyAddress"
            };
            RepoPsychologists.Add(psychologistTest);
        }
        
        [TestMethod]
        public void DomainToDtoTest()
        {
            Psychologist psychologistTest = new Psychologist()
            {
                Name = "Jose"
            };
            RepoPsychologists.Add(psychologistTest);
            Psychologist actualPsychologist = RepoPsychologists.Find(x => x.Name == "Jose");
            Assert.AreEqual(psychologistTest, actualPsychologist);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Psychologist actualPsychologist = RepoPsychologists.Find(x => x.Name == "Roberto");
            Assert.AreEqual(this.psychologistTest, actualPsychologist);
        }
     
        [TestMethod]
        public void UpdateTest()
        {
            Psychologist actualPsychologist = RepoPsychologists.Find(x => x.Name == "Roberto");
            actualPsychologist.Name = "RobertoUpdated";
            Psychologist updatedPsychologist = RepoPsychologists.Update(psychologistTest, actualPsychologist);
            Assert.AreEqual(actualPsychologist, updatedPsychologist);
        }
    }
}