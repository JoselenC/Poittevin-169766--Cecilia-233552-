using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PsychologistTest
    {

        [TestMethod]
        public void GetSetAddress()
        {
            Psychologist psychologist = new Psychologist
            {
                Address = "House 1234"
            };
            Assert.AreEqual("House 1234", psychologist.Address);
        }
        
        [TestMethod]
        public void GetSetName()
        {
            Psychologist psychologist = new Psychologist
            {
                Name = "Pedro"
            };
            Assert.AreEqual("Pedro", psychologist.Name);
        }
        
        [TestMethod]
        public void GetSetLastName()
        {
            Psychologist psychologist = new Psychologist
            {
                LastName = "Rodriguez"
            };
            Assert.AreEqual("Rodriguez", psychologist.LastName);
        }
        
        [TestMethod]
        public void GetSetWorksOnline()
        {
            Psychologist psychologist = new Psychologist
            {
                WorksOnline = true
            };
            Assert.IsTrue(psychologist.WorksOnline);
        }
        
        [TestMethod]
        public void GetSetProblematics()
        {
            List<Problematic> problematics = new List<Problematic>()
            {
                new Problematic(){Name= "Test1"},
                new Problematic(){Name= "Test2"}
            };
            Psychologist psychologist = new Psychologist()
            {
                Problematics = problematics
            };
            CollectionAssert.AreEqual(psychologist.Problematics, problematics);
        }
        
        [TestMethod]
        public void GetSetMeetings()
        {
            List<Meeting> meetings = new List<Meeting>()
            {
                new Meeting(){Patient = new Patient(){Name = "Patient1"}},
                new Meeting(){Patient = new Patient(){Name = "Patient2"}}
            };
            Psychologist psychologist = new Psychologist()
            {
                Meetings = meetings
            };
            CollectionAssert.AreEqual(psychologist.Meetings, meetings);
        }

        [TestMethod]
        public void NextMeetingDayOnWeekWithTimeOnWednesday()
        {
            
            List<Meeting> meetings = new List<Meeting>()
            {
                new Meeting(){DateTime = new DateTime(1993,7,15)},
                new Meeting(){DateTime = new DateTime(1993,7,15)}
            };
            Psychologist psychologist = new Psychologist()
            {
                Meetings = meetings
            };
            DateTime wednesdayDateTime = new DateTime(1993, 7, 14);
            DateTime? nextMeetingDayOnWeek = psychologist.NextMeetingDayOnWeek(new DateTime(1993, 7, 14));
            Assert.AreEqual(nextMeetingDayOnWeek, wednesdayDateTime);
        }
        
        [TestMethod]
        public void NextMeetingDayOnWeekWithTimeOnThursday()
        {
            
            List<Meeting> meetings = new List<Meeting>()
            {
                new Meeting(){DateTime = new DateTime(1993,7,15)},
                new Meeting(){DateTime = new DateTime(1993,7,15)}
            };
            Psychologist psychologist = new Psychologist()
            {
                Meetings = meetings
            };
            DateTime wendsDayDateTime = new DateTime(1993, 7, 15);
            DateTime? nextMeetingDayOnWeek = psychologist.NextMeetingDayOnWeek(new DateTime(1993, 7, 15));
            Assert.AreEqual(nextMeetingDayOnWeek, wendsDayDateTime);
        }
        
        [TestMethod]
        public void NextMeetingDayOnWeekWithTimeOnFriday()
        {
            
            List<Meeting> meetings = new List<Meeting>()
            {
                new Meeting(){DateTime = new DateTime(1993,7,15)},
                new Meeting(){DateTime = new DateTime(1993,7,15)},
                new Meeting(){DateTime = new DateTime(1993,7,15)},
                new Meeting(){DateTime = new DateTime(1993,7,15)},
                new Meeting(){DateTime = new DateTime(1993,7,15)},
            };
            Psychologist psychologist = new Psychologist()
            {
                Meetings = meetings
            };
            DateTime wendsDayDateTime = new DateTime(1993, 7, 16);
            DateTime? nextMeetingDayOnWeek = psychologist.NextMeetingDayOnWeek(new DateTime(1993, 7, 15));
            Assert.AreEqual(nextMeetingDayOnWeek, wendsDayDateTime);
        }
        
        [TestMethod]
        public void NextMeetingDayOnWeekWithoutFreeTime()
        {
            
            List<Meeting> meetings = new List<Meeting>()
            {
                new Meeting(){DateTime = new DateTime(1993,7,16)},
                new Meeting(){DateTime = new DateTime(1993,7,16)},
                new Meeting(){DateTime = new DateTime(1993,7,16)},
                new Meeting(){DateTime = new DateTime(1993,7,16)},
                new Meeting(){DateTime = new DateTime(1993,7,16)},
            };
            Psychologist psychologist = new Psychologist()
            {
                Meetings = meetings
            };
            DateTime? nextMeetingDayOnWeek = psychologist.NextMeetingDayOnWeek(new DateTime(1993, 7, 16));
            Assert.IsNull(nextMeetingDayOnWeek);
        }
    }
}