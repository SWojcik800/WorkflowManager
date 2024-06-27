using Azure.Core;
using StorageManager.App.Commons.IoC;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WorkflowManager.Api.Helpers
{
    public sealed class JwtTokenService(IHttpContextAccessor contextAccessor) : IJWTTokenService
    {
        public int GetCurrentUserId()
        {
            var context = contextAccessor.HttpContext;
            var token = string.Empty;
            var authHeader = context.Request.Headers["Authorization"].ToString();
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                token = authHeader.Substring("Bearer ".Length).Trim();
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var userId = jsonToken?.Claims.First(claim => claim.Type == "unique_name")?.Value;

            return int.Parse(userId);
        }
    }

    public interface IJWTTokenService : IScopedService
    {
        int GetCurrentUserId();
    }
}
