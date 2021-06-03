using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Importer;

namespace MSP.BetterCalm.Test.Importer
{
    [TestClass]
    public class ParameterTest
    {

        [TestMethod]
        public void GetSetName()
        {
            string ParameterName = "Path";
            Parameter Parameter = new Parameter();
            Parameter.Name = "Path";
            string getParameterName = Parameter.Name;
            Assert.AreEqual(ParameterName, getParameterName);
        }
        
        [TestMethod]
        public void GetSetType()
        {
            string parameterType = "string";
            Parameter parameter = new Parameter();
            parameter.Type = "string";
            string getParameterType = parameter.Type;
            Assert.AreEqual(parameterType, getParameterType);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidType), "")]
        public void GetSetInvalidType()
        {
            Parameter parameter = new Parameter();
            parameter.Type = "aa";
        }
        
    }
}