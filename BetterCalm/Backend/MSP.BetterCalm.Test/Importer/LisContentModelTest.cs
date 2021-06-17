using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Importer.Models;

namespace MSP.BetterCalm.Test.Importer
{
    [TestClass]
    public class LisContentModelTest
    {
        [TestMethod]
        public void GetSetContentModelName()
        {
            List<ContentModel> contentModelsExpected = new List<ContentModel>();
            ListContentModel contentModel = new ListContentModel();
            contentModel.ListContentModels =new List<ContentModel>();
            List<ContentModel> contentModels = contentModel.ListContentModels;
            CollectionAssert.AreEqual(contentModelsExpected, contentModels);
        }
    }
}