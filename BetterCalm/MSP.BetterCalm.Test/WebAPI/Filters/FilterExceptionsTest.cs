using System;
using System.Collections.Generic;
using System.Security.Authentication;
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
                Code = 422
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
                Code = 422
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
                Code = 422
            };
            result = new ObjectResult(response) {StatusCode = response.Code};
            filter.OnException(exceptionContext);
            ObjectResult objResult = (ObjectResult) exceptionContext.Result;
            ErrorDto errorDto = (ErrorDto) result.Value;
            ErrorDto error = (ErrorDto) objResult.Value;
            Assert.AreEqual(errorDto, error);
        }
        
        [TestMethod]
        public void InvalidUrlTest()
        {
            exceptionContext.Exception = new InvalidUrl();
            response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exceptionContext.Exception.Message,
                Content = exceptionContext.Exception.Message,
                Code = 422
            };
            result = new ObjectResult(response) {StatusCode = response.Code};
            filter.OnException(exceptionContext);
            ObjectResult objResult = (ObjectResult) exceptionContext.Result;
            ErrorDto errorDto = (ErrorDto) result.Value;
            ErrorDto error = (ErrorDto) objResult.Value;
            Assert.AreEqual(errorDto, error);
        }
        
        [TestMethod]
        public void AlreadyExistThisAudioTest()
        {
            exceptionContext.Exception = new AlreadyExistThisAudio();
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
        public void AlreadyExistThisVideoTest()
        {
            exceptionContext.Exception = new AlreadyExistVideo();
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
        
        [TestMethod]
        public void InvalidCategoryTest()
        {
            exceptionContext.Exception = new InvalidCategory();
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
        public void InvalidProblematicTest()
        {
            exceptionContext.Exception = new InvalidProblematic();
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
        public void NotFoundAudioTest()
        {
            exceptionContext.Exception = new NotFoundAudio();
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
        public void NotFoundVideoTest()
        {
            exceptionContext.Exception = new NotFoundVideo();
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
        public void NotFoundPlaylistTest()
        {
            exceptionContext.Exception = new NotFoundPlaylist();
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
        public void NotFoundCategoryTest()
        {
            exceptionContext.Exception = new NotFoundCategory();
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
        public void NotControlledExceptionTest()
        {
            exceptionContext.Exception = new Exception("Panic! Not Controlled");
            response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exceptionContext.Exception.Message,
                Content = exceptionContext.Exception.Message,
                Code = 500
            };
            result = new ObjectResult(response) {StatusCode = response.Code};
            filter.OnException(exceptionContext);
            ObjectResult objResult = (ObjectResult) exceptionContext.Result;
            ErrorDto errorDto = (ErrorDto) result.Value;
            ErrorDto error = (ErrorDto) objResult.Value;
            Assert.AreEqual(errorDto, error);
        }
      
        [TestMethod]
        public void NotNotFoundAdminLoginErrorTest()
        {
            exceptionContext.Exception = new NotFoundAdminLoginError();
            response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exceptionContext.Exception.Message,
                Content = exceptionContext.Exception.Message,
                Code = 401
            };
            result = new ObjectResult(response) {StatusCode = response.Code};
            filter.OnException(exceptionContext);
            ObjectResult objResult = (ObjectResult) exceptionContext.Result;
            ErrorDto errorDto = (ErrorDto) result.Value;
            ErrorDto error = (ErrorDto) objResult.Value;
            Assert.AreEqual(errorDto, error);
        }
        
        [TestMethod]
        public void AuthenticationExceptionTest()
        {
            exceptionContext.Exception = new AuthenticationException();
            response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exceptionContext.Exception.Message,
                Content = exceptionContext.Exception.Message,
                Code = 401
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