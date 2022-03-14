using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UsersApi.Core.Exceptions;

namespace UsersApi.Filters;

public  class ExceptionFilter :  IAsyncExceptionFilter
{
    private readonly ILogger _logger;

    public ExceptionFilter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger("ServiceExceptionFilter");
    }

    public Task OnExceptionAsync(ExceptionContext context)
    {
        ExceptionError? error = null;
        if (context.Exception  is RequestException  )
        {
            error = new ExceptionError
            {
                StatusCode = 400,
                Message = context.Exception.Message
            };
        }
        else
        {
            error = new ExceptionError
            {
                StatusCode = 500,
                Message = "Something wrong! Internal Server Error."
            };
            _logger.LogError(context.Exception, "Internal Server Error.");
        }

        context.Result = new JsonResult(error);
        return Task.CompletedTask;
    }
}