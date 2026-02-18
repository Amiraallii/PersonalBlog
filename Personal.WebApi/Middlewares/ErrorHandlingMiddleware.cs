using Microsoft.AspNetCore.Mvc;

namespace Personal.WebApi.Middlewares
{
    public class ErrorHandlingMiddleware(
    RequestDelegate next,
    ILogger<ErrorHandlingMiddleware> logger)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception at {Path}", context.Request.Path);

                context.Response.ContentType = "application/json";

                context.Response.StatusCode = ex switch
                {
                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    InvalidOperationException => StatusCodes.Status400BadRequest,
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };

                var problem = new ProblemDetails
                {
                    Status = context.Response.StatusCode,
                    Title = "Request failed",
                    Detail = context.Response.StatusCode == 500
                        ? "An unexpected error occurred."
                        : ex.Message,
                    Instance = context.Request.Path
                };

                await context.Response.WriteAsJsonAsync(problem);
            }
        }
    }

}
