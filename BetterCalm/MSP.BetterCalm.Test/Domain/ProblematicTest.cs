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
        public void EqualsProblematic()
        {
            Problematic problematic = new Problematic();
            problematic.Name="depresión";
            Problematic problematicToCompare = new Problematic();
            problematicToCompare.Name="depresión";
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
        public void NotEqualsProblematicName()
        {
            Problematic problematic = new Problematic();
            problematic.Name="depresión";
            Problematic problematicToCompare = new Problematic();
            problematicToCompare.Name="estrés";
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
    }
}