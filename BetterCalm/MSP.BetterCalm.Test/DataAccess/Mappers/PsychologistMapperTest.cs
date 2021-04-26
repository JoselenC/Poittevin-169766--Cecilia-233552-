using System;
using System.Collections.Generic;
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
        private ContextDB context;
        private DataBaseRepository<Psychologist, PsychologistDto> RepoPsychologists;
        private Psychologist psychologistTest;
        private Problematic prob1;
        private Problematic prob2;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDB(options);
            RepoPsychologists = new DataBaseRepository<Psychologist, PsychologistDto>(new PsychologistMapper(), context.Psychologists, context);
            DataBaseRepository<Problematic, ProblematicDto> probRepo =
                new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper(), context.Problematics,
                    context);
            prob1 = new Problematic()
            {
                Name = "test1"
            };
            probRepo.Add(prob1);
            prob2 = new Problematic()
            {
                Name = "test2"
            };
            probRepo.Add(prob2);
            psychologistTest = new Psychologist()
            {
                Name = "Roberto",
                LastName = "Alex",
                Address = "PsyAddress",
                WorksOnline = true
            };
            RepoPsychologists.Add(psychologistTest);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            context.Database.EnsureDeleted();
        }
        
        [TestMethod]
        public void DomainToDtoTest()
        {
            Psychologist psychologistTest = new Psychologist()
            {
                Name = "Jose"
            };
            List<Problematic> problematics = new List<Problematic>()
            {
               prob1, prob2
            };
            psychologistTest.Problematics = problematics;
            RepoPsychologists.Add(psychologistTest);
            Psychologist actualPsychologist = RepoPsychologists.Find(x => x.Name == "Jose");
            Assert.AreEqual(psychologistTest, actualPsychologist);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DomainToDtoWrongProblematiTest()
        {
            Psychologist psychologistTest = new Psychologist()
            {
                Name = "Jose"
            };
            List<Problematic> problematics = new List<Problematic>()
            {
                new Problematic()
                {
                    Name = "Problematic problematic"
                }
            };
            psychologistTest.Problematics = problematics;
            RepoPsychologists.Add(psychologistTest);
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