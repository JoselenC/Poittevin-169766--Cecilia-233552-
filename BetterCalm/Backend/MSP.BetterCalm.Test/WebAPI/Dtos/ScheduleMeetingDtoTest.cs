using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI.Dtos
{
    [TestClass]
    public class ScheduleMeetingDtoTest
    {
        [TestMethod]
        public void GetSetPatient()
        {
            ScheduleMeetingDto scheduleMeeting = new ScheduleMeetingDto
            {
                Patient = new Patient(){Name = "Rodriguez"}
            };
            Assert.AreEqual("Rodriguez", scheduleMeeting.Patient.Name);
        }
        
        [TestMethod]
        public void GetSetProblematic()
        {
            ScheduleMeetingDto scheduleMeeting = new ScheduleMeetingDto
            {
                Problematic = new Problematic(){Name = "Prob1"}
            };
            Assert.AreEqual("Prob1", scheduleMeeting.Problematic.Name);
        }
        
        [TestMethod]
        public void GetSetDuration()
        {
            ScheduleMeetingDto scheduleMeeting = new ScheduleMeetingDto
            {
                Duration = 1
            };
            Assert.AreEqual(1, scheduleMeeting.Duration);
        }
    }
}