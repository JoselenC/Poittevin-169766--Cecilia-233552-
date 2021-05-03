using System;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

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

            StringValues token;
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out token);
            if (token.Count == 0)
                throw new AuthenticationException();
            try
            {
                administratorService.GetAdministratorByToken(token);
            }
            catch (NotFoundAdministrator)
            {
                throw new AuthenticationException();
            }
        }
    }
}