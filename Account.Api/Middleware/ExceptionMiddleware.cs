using System.Net;

namespace Account.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            Serilog.Log.Logger.Error(ex, "");

            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        //todo new
        //if (exception is BusinessException duplicationException)
        //{
        //    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
        //    await context.Response.WriteAsync(new ErrorDetails()
        //    {
        //        statusCode = context.Response.StatusCode,
        //        message = duplicationException.Message,
        //        success = false
        //    }.ToString());
        //}
        //status code لاگ شود حتما بررسی شود برای نیازمندی که حطا به چه صورتی به فرانت داده شود در حال حاضر فعلا 500 برمیکردد
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync(new
        {
            statusCode = context.Response.StatusCode,
            message = exception.Message,
            success = false
        }.ToString());
    }
}
