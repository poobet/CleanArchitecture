using Application.Common.Exceptions;
using Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net;

namespace Infrastructure.Middlewares;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    public ExceptionMiddleware(RequestDelegate next, ILogger logger)
    {
        _logger = logger;
        _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next.Invoke(httpContext);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"Error occured {GetType().Name}.InvokeAsync");
        }
    }
}
