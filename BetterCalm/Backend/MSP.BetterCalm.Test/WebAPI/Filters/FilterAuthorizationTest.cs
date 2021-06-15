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
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.BusinessLogicInterface;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.Test.WebAPI.Filters
{
    [TestClass]
    public class FilterAuthorizationTest
    {
        private Mock<IAdministratorService> mockAdministratorService;
        private FilterAuthentication filter;
        
        [TestInitialize]
        public void TestFixtureSetup()
        {
            mockAdministratorService = new Mock<IAdministratorService>(MockBehavior.Strict);
            filter = new FilterAuthentication(mockAdministratorService.Object);
        }

        [TestMethod]
        public void TestFilterAuthorizationSuccess()
        {
            DefaultHttpContext httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["Authorization"] = "token";
            AuthorizationFilterContext actionContext = new AuthorizationFilterContext(
                new ActionContext()
                {
                    HttpContext = httpContext,
                    ActionDescriptor = new ActionDescriptor(),
                    RouteData = new RouteData()
                },
                new List<IFilterMetadata>()
            );
            
            mockAdministratorService.Setup(
                x => x.GetAdministratorByToken("token")).Returns(new Administrator()
            );
            
            filter.OnAuthorization(actionContext);
        }
        
        [TestMethod]
        public void TestFilterAuthorizationErrorNoToken()
        {
            Exception exception = new AuthenticationException("You are not allowed to do this action");
            ErrorDto response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exception.Message,
                Content = exception.Message,
                Code = 401
            };
            AuthorizationFilterContext actionContext = new AuthorizationFilterContext(
                new ActionContext()
                {
                    HttpContext = new DefaultHttpContext(),
                    ActionDescriptor = new ActionDescriptor(),
                    RouteData = new RouteData()
                },
                new List<IFilterMetadata>()
            );
            filter.OnAuthorization(actionContext);
            ObjectResult obj = actionContext.Result as ObjectResult;
            Assert.AreEqual(obj.Value, response );
        }
        
        [TestMethod]
        public void TestFilterAuthorizationWrongToken()
        {
            DefaultHttpContext httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["Authorization"] = "token";
            Exception exception = new AuthenticationException("You are not allowed to do this action");
            ErrorDto response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exception.Message,
                Content = exception.Message,
                Code = 401
            };
            AuthorizationFilterContext actionContext = new AuthorizationFilterContext(
                new ActionContext()
                {
                    HttpContext = httpContext,
                    ActionDescriptor = new ActionDescriptor(),
                    RouteData = new RouteData()
                },
                new List<IFilterMetadata>()
            );
            
            mockAdministratorService.Setup(
                x => x.GetAdministratorByToken("token")).Throws(new NotFoundAdministrator()
            );
            
            filter.OnAuthorization(actionContext);
            ObjectResult obj = actionContext.Result as ObjectResult;
            Assert.AreEqual(obj.Value, response );
        }
    }
}