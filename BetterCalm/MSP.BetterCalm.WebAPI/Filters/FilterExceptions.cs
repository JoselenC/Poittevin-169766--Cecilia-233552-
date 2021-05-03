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
            ErrorDto response = new ErrorDto()
            {
                IsSuccess = false,
                ErrorMessage = context.Exception.Message
            };
            if (context.Exception is InvalidNameLength)
            {
                response.Content = context.Exception.Message;
                response.Code = 409;
            }

            if (context.Exception is InvalidDescriptionLength)
            {
                response.Content = context.Exception.Message;
                response.Code = 409;
            }

            if (context.Exception is InvalidDurationFormat)
            {
                response.Content = context.Exception.Message;
                response.Code = 409;
            }

            if (context.Exception is AlreadyExistThisAudio)
            {
                response.Content = context.Exception.Message;
                response.Code = 409;
            }

            if (context.Exception is InvalidCategory)
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }

            if (context.Exception is InvalidProblematic)
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }

            if (context.Exception is ObjectWasNotDeleted)
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }

            if (context.Exception is ObjectWasNotUpdated)
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }

            if (context.Exception is NotFoundId)
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }

            if (context.Exception is NotFoundAudio)
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }

            if (context.Exception is NotFoundPlaylist)
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }

            if (context.Exception is NotFoundCategory)
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }

            if (context.Exception is NotFoundPlaylist)
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }

            if (context.Exception is AlreadyExistThisAudio)
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }

            if (context.Exception is KeyNotFoundException)
            {
                response.Content = context.Exception.Message;
                response.Code = 404;
            }

            context.Result = new ObjectResult(response)
            {
                StatusCode = response.Code
            };
        }

    }
}