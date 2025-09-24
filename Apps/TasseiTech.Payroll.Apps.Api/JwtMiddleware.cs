using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TasseiTech.Sample.Apps.Api;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="JwtMiddleware" /> class.
/// </remarks>
/// <param name="next">The next.</param>
/// <param name="configuration">The configuration.</param>
/// <param name="logger"></param>
public class JwtMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<JwtMiddleware> logger)
{

    /// <summary>
    /// Invokes the asynchronous.
    /// </summary>
    /// <param name="context">The context.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(' ').LastOrDefault();
        logger.LogInformation("Received request with token: {token}", token);
        if (token != null)
        {
            try
            {
                var principal = ValidateToken(token, configuration);
                context.User = principal;
                logger.LogInformation("Token validation successful for user: {user}", principal.Identity.Name);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error validating token");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }
        }
        else
        {
            logger.LogWarning("No authorization token provided");
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }
        await next(context);
    }

    /// <summary>
    /// Validates the token.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns></returns>
    private ClaimsPrincipal ValidateToken(string token, IConfiguration configuration)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"])),
            ValidateIssuer = true,
            ValidIssuer = configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = configuration["JWT:Audience"],
            ValidateLifetime = true
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token,
                                                   tokenValidationParameters,
                                                   out SecurityToken validatedToken);
        return principal;
    }
}
