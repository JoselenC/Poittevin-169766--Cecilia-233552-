using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class ProblematicTest
    {
        [TestMethod]
        public void GetProblematicName()
        {
            string problematicName = "depresión";
            Problematic problematic = new Problematic();
            problematic.Name = "depresión";
            string getproblematicName = problematic.Name;
            Assert.AreEqual(problematicName, getproblematicName);
        }
        
        [TestMethod]
        public void GetSetProblematicId()
        {
            Problematic problematic = new Problematic();
            problematic.Id = 1;
            int getproblematicId = problematic.Id;
            Assert.AreEqual(1, getproblematicId);
        }
        
        [TestMethod]
        public void EqualsProblematic()
        {
            Problematic problematic = new Problematic();
            problematic.Id=1;
            Problematic problematicToCompare = new Problematic();
            problematicToCompare.Id=1;
            Assert.AreEqual(problematic, problematicToCompare);
        }
        
        [TestMethod]
        public void NotEqualsProblematicNull()
        {
            Problematic problematic = new Problematic();
            problematic.Name="depresión";
            Assert.AreNotEqual(problematic, null);
        }
        
        [TestMethod]
        public void ProblematicNull()
        {
            Problematic problematic=null;
            Assert.IsNull(problematic);
        }
        
        [TestMethod]
        public void NotProblematicNull()
        {
            Problematic problematic=new Problematic();
            Assert.IsNotNull(problematic);
        }
        
        [TestMethod]
        public void NotEqualsProblematicId()
        {
            Problematic problematic = new Problematic();
            problematic.Id=1;
            Problematic problematicToCompare = new Problematic();
            problematicToCompare.Id=2;
            Assert.AreNotEqual(problematic, problematicToCompare);
        }
        
        [TestMethod]
        public void NotEqualsProblematicType()
        {
            Problematic problematic = new Problematic();
            problematic.Name="depresión";
            Assert.AreNotEqual(problematic, "");
        }
        
        [TestMethod]
        public void IsSameProblematicName()
        {
            Problematic problematic = new Problematic();
            problematic.Name = "Estres";
            string problematicName = "Estres";
            Assert.IsTrue(problematic.IsSameProblematicName(problematicName));
        }
        
        [TestMethod]
        public void IsDifferentCategoryName()
        {
            Problematic problematic = new Problematic();
            problematic.Name = "Estres";
            string problematicName = "Tristesa";
            Assert.IsFalse(problematic.IsSameProblematicName(problematicName));
        }
        
        [TestMethod]
        public void EqualsNull()
        {
            Problematic problematic = new Problematic();
            problematic.Name = "Estres";
            Assert.IsFalse( problematic.Equals(null));
        }
        
        [TestMethod]
        public void EqualsDiffType()
        {
            Problematic problematic = new Problematic();
            problematic.Name = "Estres";
            Assert.IsFalse( problematic.Equals(new Audio()));
        }
    }
}