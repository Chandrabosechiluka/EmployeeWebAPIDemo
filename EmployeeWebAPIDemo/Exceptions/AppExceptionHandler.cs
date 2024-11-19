using EmployeeWebAPIDemo.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPIDemo.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
            Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is ValidationException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Title = "Invalid Input";
                response.ExceptionMessage = exception.Message;
            }
            else if (exception is EmployeeNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Title = "Wrong Input";
                response.ExceptionMessage = exception.Message;
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Title = "Something went Wrong";
                response.ExceptionMessage = exception.Message;
            }
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
    
}
