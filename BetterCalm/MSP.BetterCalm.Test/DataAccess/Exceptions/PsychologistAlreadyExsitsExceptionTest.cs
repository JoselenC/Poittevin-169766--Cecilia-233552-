using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;

namespace MSP.BetterCalm.Test.DataAccess.Exceptions
{
    [TestClass]
    public class PsychologistAlreadyExsitsExceptionTest
    {
        [TestMethod]
        public void CreateExceptionTest()
        {
            Exception PsychologistAlreadyExsitsException = new PsychologistAlreadyExistException();
            Assert.AreEqual(PsychologistAlreadyExsitsException.Message, "Psychologist already exists");
        }
    }
}