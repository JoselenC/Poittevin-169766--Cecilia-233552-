using System;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.WebAPI.Filters
{
    public class FilterAuthentication: Attribute, IAuthorizationFilter
    {
        private IAdministratorService administratorService;

        public FilterAuthentication(IAdministratorService vAdministratorService)
        {
            administratorService = vAdministratorService;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Exception exception = new AuthenticationException("You are not allowed to do this action");
            ErrorDto error=new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = exception.Message,
                Content = exception.Message,
                Code = 401
            };
            
            StringValues token;
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out token);
            if (token.Count == 0)
            {
                context.Result = new ObjectResult(error)
                {
                    StatusCode = error.Code
                };
            }
            else
            {
                try
                {
                    administratorService.GetAdministratorByToken(token);
                }
                catch (NotFoundAdministrator)
                {
                    context.Result = new ObjectResult(error)
                    {
                        StatusCode = error.Code
                    };
                }
            }
        }
    }
}