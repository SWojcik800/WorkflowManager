using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StorageManager.App.Commons;
using StorageManager.App.Features.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorkflowManager.Api.Dtos;

namespace WorkflowManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsersController(AppManagerApi appManagerApi, IConfiguration configuration) : ControllerBase
    {
        [HttpPost]
        public async Task<Result<string>> Login(string userName, string password)
        {
            var userService = appManagerApi.Resolve<IUserService>();
            var result = userService.Login(userName, password);

            if (!result.IsSuccess)
                return Result<string>.Fail(result.ErrorMessage);

            var user = result.Value;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("JWTKey"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Id.ToString()),

                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Result<string>.Success(tokenString);
        }
    }
}
