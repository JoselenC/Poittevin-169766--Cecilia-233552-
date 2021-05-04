using System;
using System.Collections.Generic;
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
            List<Type> errors404 = new List<Type>()
            {
                typeof(InvalidCategory),
                typeof(InvalidProblematic),
                typeof(ObjectWasNotDeleted),
                typeof(ObjectWasNotUpdated),
                typeof(NotFoundId),
                typeof(NotFoundAudio),
                typeof(NotFoundPlaylist),
                typeof(NotFoundCategory),
                typeof(KeyNotFoundException),
                typeof(AlreadyExistThisAudio),
                typeof(NotFoundAdministrator),
                typeof(NotFoundPsychologist),
                typeof(NotFoundProblematic)
                
            };
            List<Type> errors409 = new List<Type>()
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
            if (errors404.Contains(errorType))
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }
            if (errors409.Contains(errorType))
            {
                response.Content = context.Exception.Message;
                response.Code = 409;
            }

            context.Result = new ObjectResult(response)
            {
                StatusCode = response.Code
            };
        }

    }
}