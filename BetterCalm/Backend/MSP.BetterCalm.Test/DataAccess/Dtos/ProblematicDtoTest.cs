﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class ProblematicDtoTest
    {
        [TestMethod]
        public void SetGetProblematicDtoId()
        {
            ProblematicDto problematicDto = new ProblematicDto();
            problematicDto.ProblematicDtoId = 1;
            Assert.AreEqual(1, problematicDto.ProblematicDtoId);
        }

        [TestMethod]
        public void SetGetProblematicName()
        {
            ProblematicDto problematicDto = new ProblematicDto();
            problematicDto.Name = "food";
            Assert.AreEqual("food", problematicDto.Name);
        }
        
        [TestMethod]
        public void SetGetPsychologistName()
        {
            ProblematicDto problematicDto = new ProblematicDto();
            problematicDto.PsychologistProblematic = new List<PsychologistProblematicDto>();
            CollectionAssert.AreEqual(new List<PsychologistProblematicDto>(), problematicDto.PsychologistProblematic.ToList());
        }
        
    }
}