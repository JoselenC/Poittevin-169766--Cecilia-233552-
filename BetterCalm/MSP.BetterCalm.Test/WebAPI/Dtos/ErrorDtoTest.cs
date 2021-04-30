using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI.Dtos
{
    [TestClass]
    public class ErrorDtoTest
    {
         [TestMethod]
        public void GetSetIsSuccess()
        {
            ErrorDto error = new ErrorDto();
            error.IsSuccess = false;
            bool IsSuccess = error.IsSuccess;
            Assert.AreEqual(IsSuccess, error.IsSuccess);
        }
      
        
        [TestMethod]
        public void GetSetCode()
        {
            ErrorDto error = new ErrorDto();
            error.Code = 404;
            int code = error.Code;
            Assert.AreEqual(code, error.Code);
        }
        
        [TestMethod]
        public void GetSetSongErrorMessage()
        {
            ErrorDto error = new ErrorDto();
            error.ErrorMessage = "";
            string ErrorMessage = error.ErrorMessage;
            Assert.AreEqual(ErrorMessage, error.ErrorMessage);
        }
        
    }
}