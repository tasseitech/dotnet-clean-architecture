using System.Text.Json;
using Microsoft.AspNetCore.Http.Features;
using TasseiTech.Sample.Core.Domain.DTOs;
using TasseiTech.Sample.Core.Domain.Exceptions;

namespace TasseiTech.Sample.Apps.Api;

/// <summary>
///   <br />
/// </summary>
public class ExceptionMiddleware
{

    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next.</param>
    /// <param name="loggerFactory"></param>
    public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
    }

    /// <summary>
    /// Invokes the specified HTTP context.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    /// <returns></returns>
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            try
            {
                _logger.LogError(ex,
                    $"Error during HTTP {httpContext.Request.Method} {GetPath(httpContext)}: {GetMessage(ex)}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch { }
        }
    }

    private static string GetPath(HttpContext httpContext)
    {
        return httpContext.Features.Get<IHttpRequestFeature>()?.RawTarget ?? httpContext.Request.Path.ToString();
    }

    /// <summary>
    /// Handles the exception asynchronous.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns></returns>
    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = ex is BusinessRuleException bre ? bre.HttpStatusCode : StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsync(JsonSerializer.Serialize(new OperationResponse<object>
        {
            Success = false,
            Error = ex?.Message,
            ErrorCode = ex is BusinessRuleException br ? br.ErrorCode.ToString() : string.Empty,
            Data = ex is BusinessRuleException e ? e.Data : null,
        }));
    }

    private string GetMessage(Exception ex)
    {
        return ex?.ToString();
    }
}
