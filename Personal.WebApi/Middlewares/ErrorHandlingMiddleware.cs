using Personal.Application.Dtos;
using System.Net;
using System.Text.Json;

namespace Personal.WebApi.Middlewares
{
    public class ErrorHandlingMiddleware 
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) 
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var result = new ResultDto
                {
                    Code = response.StatusCode,
                    IsSuccess = false,
                    Message = $"Internal Server Error: {ex.Message}",
                };

                var jsonResponse = JsonSerializer.Serialize(result);
                await response.WriteAsync(jsonResponse);

            }
        }
    }
}
