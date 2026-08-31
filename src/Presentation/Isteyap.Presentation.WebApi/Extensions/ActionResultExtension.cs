using Isteyap.Core.Application.Exceptions;
using Isteyap.Core.Application.Results.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Isteyap.Presentation.WebApi.Extensions
{
    public static class ActionResultExtension
    {
        public static IActionResult ToActionResult(this IResultControl result, ControllerBase controller)
        {
            if (result.IsSuccess)
            {
                return controller.Ok();
            }
            else
            {
                if (result.Exception is AppExceptionBase)
                {
                    return controller.BadRequest(new
                    {
                        errorMessage = result.ErrorMessage,
                        errorCode = result.ErrorCode
                    });
                }

            }

            return controller.BadRequest(new
            {
                errorMessage = result.ErrorMessage,
                errorCode = result.ErrorCode
            });
        }

        public static IActionResult ToActionResult<T>(this IResultDataControl<T> result, ControllerBase controller)
        {
            if (result.IsSuccess)
            {
                return controller.Ok(result.Data);
            }
            else
            {
                if (result.Exception is AppExceptionBase)
                {
                    return controller.BadRequest(new
                    {
                        errorMessage = result.ErrorMessage,
                        errorCode = result.ErrorCode
                    });
                }

            }

            return controller.BadRequest(new
            {
                errorMessage = result.ErrorMessage,
                errorCode = result.ErrorCode
            });
        }
    }
}
