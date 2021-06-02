using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PatientTest
    {

        [TestMethod]
        public void GetSetCellphone()
        {
            Patient patient = new Patient
            {
                Cellphone = "09123981"
            };
            Assert.AreEqual("09123981", patient.Cellphone);
        }
        
        [TestMethod]
        public void GetSetBirthDay()
        {
            Patient patient = new Patient
            {
                BirthDay = new DateTime(1993, 7, 15)
            };
            Assert.AreEqual(new DateTime(1993,7,15), patient.BirthDay);
        }
        
        [TestMethod]
        public void GetSetName()
        {
            Patient patient = new Patient
            {
                Name = "Pedro"
            };
            Assert.AreEqual("Pedro", patient.Name);
        }
        
        [TestMethod]
        public void GetSetLastName()
        {
            Patient patient = new Patient
            {
                LastName = "Rodriguez"
            };
            Assert.AreEqual("Rodriguez", patient.LastName);
        }
        
        [TestMethod]
        public void GetSetMeetings()
        {
            List<Meeting> meetings = new List<Meeting>()
            {
                new Meeting(){Psychologist = new Psychologist(){Name = "Psycho1"}},
                new Meeting(){Psychologist = new Psychologist(){Name = "Pscho1"}}
            };
            Patient patient = new Patient()
            {
                Meetings = meetings
            };
            CollectionAssert.AreEqual(patient.Meetings, meetings);
        }
        
        [TestMethod]
        public void HashCodeAddressTest()
        {
            List<Meeting> meetings = new List<Meeting>()
            {
                new Meeting(){Psychologist = new Psychologist(){Name = "Psycho1"}},
                new Meeting(){Psychologist = new Psychologist(){Name = "Pscho1"}}
            };
            Patient patient = new Patient
            {
                BirthDay = new DateTime(1993, 7, 15),
                Meetings = meetings,
                Cellphone = "09123981"
            };
            Assert.AreEqual(patient.GetHashCode(), patient.GetHashCode());
        }
        
        [TestMethod]
        public void EqualsNull()
        {
            Patient patient = new Patient
            {
                BirthDay = new DateTime(1993, 7, 15),
                Cellphone = "09123981"
            };
            Assert.IsFalse( patient.Equals(null));
        }
        
        [TestMethod]
        public void EqualsDiffType()
        {
            Patient patient = new Patient
            {
                BirthDay = new DateTime(1993, 7, 15),
                Cellphone = "09123981"
            };
            Assert.IsFalse(patient.Equals(new Content()));
        }
        [TestMethod]
        public void EqualsTest()
        {
            Patient patient = new Patient
            {
                BirthDay = new DateTime(1993, 7, 15),
                Cellphone = "09123981"
            };
            Assert.IsTrue(patient.Equals(patient));
        }
    }
}