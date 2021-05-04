using System;
using System.Collections.Generic;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.WebAPI.Filters
{
    public class FilterExceptions: Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            List<Type> errors401 = new List<Type>()
            {
                typeof(NotFoundAdminLoginError),
                typeof(AuthenticationException)
            };
            List<Type> errors404 = new List<Type>()
            {
                typeof(NotFoundId),
                typeof(NotFoundAudio),
                typeof(NotFoundPlaylist),
                typeof(NotFoundCategory),
                typeof(NotFoundAdministrator),
                typeof(NotFoundPsychologist),
                typeof(NotFoundProblematic),
                typeof(KeyNotFoundException)
            };
            List<Type> errors409 = new List<Type>()
            {
                typeof(AlreadyExistThisAudio),
                typeof(InvalidCategory),
                typeof(InvalidProblematic),

            };
            List<Type> errors422 = new List<Type>()
            {
                typeof(InvalidNameLength),
                typeof(InvalidDescriptionLength),
                typeof(InvalidDurationFormat),
            };

            ErrorDto response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = context.Exception.Message
            };
            
            Type errorType = context.Exception.GetType();
            if (errors401.Contains(errorType))
            {
                response.Content = context.Exception.Message;
                response.Code = 401;
            }
            else if (errors404.Contains(errorType))
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }
            else if (errors409.Contains(errorType))
            {
                response.Content = context.Exception.Message;
                response.Code = 409;
            }
            else if (errors422.Contains(errorType))
            {
                response.Content = context.Exception.Message;
                response.Code = 422;
            }
            else
            {
                response.Content = context.Exception.Message;
                response.Code = 500;
            }

            context.Result = new ObjectResult(response)
            {
                StatusCode = response.Code
            };
        }

    }
}