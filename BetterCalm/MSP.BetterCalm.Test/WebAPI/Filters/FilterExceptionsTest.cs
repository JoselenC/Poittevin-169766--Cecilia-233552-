using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.WebAPI.Dtos;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.Test.WebAPI.Filters
{
    [TestClass]
    public class FilterExceptionsTest
    {
        private ActionContext actionContext;
        private ExceptionContext exceptionContext;
        private FilterExceptions filter;
        private ErrorDto response;
        private ObjectResult result;
        
        [TestInitialize]
        public void TestFixtureSetup()
        {
            actionContext = new ActionContext()
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>());
            filter = new FilterExceptions();
          
        }

        [TestMethod]
        public void InvalidNameLengthTest()
        {
            exceptionContext.Exception = new InvalidNameLength();
            response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exceptionContext.Exception.Message,
                Content = exceptionContext.Exception.Message,
                Code = 409
            };
            result = new ObjectResult(response) {StatusCode = response.Code};
            filter.OnException(exceptionContext);
            ObjectResult objResult = (ObjectResult) exceptionContext.Result;
            ErrorDto errorDto = (ErrorDto) result.Value;
            ErrorDto error = (ErrorDto) objResult.Value;
            Assert.AreEqual(errorDto, error);
        }
        
        [TestMethod]
        public void InvalidDescriptionLengthTest()
        {
            exceptionContext.Exception = new InvalidDescriptionLength();
            response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exceptionContext.Exception.Message,
                Content = exceptionContext.Exception.Message,
                Code = 409
            };
            result = new ObjectResult(response) {StatusCode = response.Code};
            filter.OnException(exceptionContext);
            ObjectResult objResult = (ObjectResult) exceptionContext.Result;
            ErrorDto errorDto = (ErrorDto) result.Value;
            ErrorDto error = (ErrorDto) objResult.Value;
            Assert.AreEqual(errorDto, error);
        }
        
        [TestMethod]
        public void InvalidDurationFormatTest()
        {
            exceptionContext.Exception = new InvalidDurationFormat();
            response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exceptionContext.Exception.Message,
                Content = exceptionContext.Exception.Message,
                Code = 409
            };
            result = new ObjectResult(response) {StatusCode = response.Code};
            filter.OnException(exceptionContext);
            ObjectResult objResult = (ObjectResult) exceptionContext.Result;
            ErrorDto errorDto = (ErrorDto) result.Value;
            ErrorDto error = (ErrorDto) objResult.Value;
            Assert.AreEqual(errorDto, error);
        }
        
        [TestMethod]
        public void AlreadyExistThisSongTest()
        {
            exceptionContext.Exception = new AlreadyExistThisSong();
            response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exceptionContext.Exception.Message,
                Content = exceptionContext.Exception.Message,
                Code = 404
            };
            result = new ObjectResult(response) {StatusCode = response.Code};
            filter.OnException(exceptionContext);
            ObjectResult objResult = (ObjectResult) exceptionContext.Result;
            ErrorDto errorDto = (ErrorDto) result.Value;
            ErrorDto error = (ErrorDto) objResult.Value;
            Assert.AreEqual(errorDto, error);
        }
        
        [TestMethod]
        public void ObjectWasNotDeletedTest()
        {
            exceptionContext.Exception = new ObjectWasNotDeleted();
            response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exceptionContext.Exception.Message,
                Content = exceptionContext.Exception.Message,
                Code = 404
            };
            result = new ObjectResult(response) {StatusCode = response.Code};
            filter.OnException(exceptionContext);
            ObjectResult objResult = (ObjectResult) exceptionContext.Result;
            ErrorDto errorDto = (ErrorDto) result.Value;
            ErrorDto error = (ErrorDto) objResult.Value;
            Assert.AreEqual(errorDto, error);
        }
        
        [TestMethod]
        public void KeyNotFoundExceptionTest()
        {
            exceptionContext.Exception = new KeyNotFoundException();
            response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exceptionContext.Exception.Message,
                Content = exceptionContext.Exception.Message,
                Code = 404
            };
            result = new ObjectResult(response) {StatusCode = response.Code};
            filter.OnException(exceptionContext);
            ObjectResult objResult = (ObjectResult) exceptionContext.Result;
            ErrorDto errorDto = (ErrorDto) result.Value;
            ErrorDto error = (ErrorDto) objResult.Value;
            Assert.AreEqual(errorDto, error);
        }
        
        [TestMethod]
        public void ObjectWasNotUpdatedTest()
        {
            exceptionContext.Exception = new ObjectWasNotUpdated();
            response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exceptionContext.Exception.Message,
                Content = exceptionContext.Exception.Message,
                Code = 404
            };
            result = new ObjectResult(response) {StatusCode = response.Code};
            filter.OnException(exceptionContext);
            ObjectResult objResult = (ObjectResult) exceptionContext.Result;
            ErrorDto errorDto = (ErrorDto) result.Value;
            ErrorDto error = (ErrorDto) objResult.Value;
            Assert.AreEqual(errorDto, error);
        }
        
        [TestMethod]
        public void NotFoundIdTest()
        {
            exceptionContext.Exception = new NotFoundId();
            response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exceptionContext.Exception.Message,
                Content = exceptionContext.Exception.Message,
                Code = 404
            };
            result = new ObjectResult(response) {StatusCode = response.Code};
            filter.OnException(exceptionContext);
            ObjectResult objResult = (ObjectResult) exceptionContext.Result;
            ErrorDto errorDto = (ErrorDto) result.Value;
            ErrorDto error = (ErrorDto) objResult.Value;
            Assert.AreEqual(errorDto, error);
        }
    }
}