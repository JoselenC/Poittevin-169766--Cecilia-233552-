using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PsychologistMapperTest
    {
        private DbContextOptions<ContextDb> options;
        private ContextDb context;
        private DataBaseRepository<Psychologist, PsychologistDto> RepoPsychologists;
        private Psychologist psychologistTest;
        private Problematic prob1;
        private Problematic prob2;
        private Problematic prob3;
        private Problematic prob4;
        private List<Problematic> problematics;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDb>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDb(options);
            RepoPsychologists = new DataBaseRepository<Psychologist, PsychologistDto>(new PsychologistMapper(), context.Psychologists, context);
            DataBaseRepository<Problematic, ProblematicDto> probRepo =
                new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper(), context.Problematics,
                    context);
            prob1 = new Problematic()
            {
                Name = "test1"
            };
            prob1 = probRepo.Add(prob1);
            prob2 = new Problematic()
            {
                Name = "test2"
            };
            prob2 = probRepo.Add(prob2);
            prob3 = new Problematic()
            {
                Name = "test3"
            };
            prob3 = probRepo.Add(prob3);
            prob4 = new Problematic()
            {
                Name = "test4"
            };
            prob4 = probRepo.Add(prob4);
            problematics = new List<Problematic>() {prob1, prob2, prob3};
            psychologistTest = new Psychologist()
            {
                Name = "Roberto",
                LastName = "Alex",
                Address = "PsyAddress",
                WorksOnline = true,
                Problematics = problematics,
                Rate = Rates.Cheap
            };
            psychologistTest = RepoPsychologists.Add(psychologistTest);
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
                Name = "Jose",
                Problematics = problematics
            };
            psychologistTest = RepoPsychologists.Add(psychologistTest);
            Psychologist actualPsychologist = RepoPsychologists.Find(x => x.Name == "Jose");
            Assert.AreEqual(psychologistTest, actualPsychologist);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidProblematic))]
        public void DomainToDtoWrongProblematiTest()
        {
            Psychologist psychologistTest = new Psychologist()
            {
                Name = "Jose",
                Problematics = problematics
            };

            Problematic problematic = new Problematic()
            {
                Name = "Problematic problematic"
            };
            psychologistTest.Problematics.Add(problematic);
            RepoPsychologists.Add(psychologistTest);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Psychologist actualPsychologist = RepoPsychologists.Find(x => x.Name == "Roberto");
            Assert.AreEqual(psychologistTest, actualPsychologist);
        }
     
        [TestMethod]
        public void UpdateTest()
        {
            Psychologist actualPsychologist = RepoPsychologists.Find(x => x.Name == "Roberto");
            actualPsychologist.Name = "RobertoUpdated";
            Psychologist updatedPsychologist = RepoPsychologists.Update(psychologistTest, actualPsychologist);
            Assert.AreEqual(actualPsychologist, updatedPsychologist);
        }
        
        [TestMethod]
        public void UpdateProblematicTest()
        {
            Psychologist actualPsychologist = RepoPsychologists.Find(x => x.Name == "Roberto");
            actualPsychologist.Problematics[^1] = prob4;
            RepoPsychologists.Update(psychologistTest, actualPsychologist);
            Psychologist updatedPsychologist = RepoPsychologists.Find(x => x.Name == "Roberto");
            Assert.AreEqual(actualPsychologist, updatedPsychologist);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void GetByIdTest()
        {
            RepoPsychologists.FindById(1);
        }
    }
}