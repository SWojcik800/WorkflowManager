using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StorageManager.App.Commons;
using StorageManager.App.Features.Users;
using StorageManager.App.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorkflowManager.Api.Dtos;
using WorkflowManager.ApplicationCore.Models;

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

        [HttpPost("set-user-disk-limit")]
        public async Task SetUserDiskLimit(SetUserDiskLimitDto diskLimitDto)
        {
            var existingDiskLimit = appManagerApi.DbContext.UserDiskLimits.FirstOrDefault(x => x.UserId == diskLimitDto.UserId);

            if (existingDiskLimit is null)
                appManagerApi.DbContext.UserDiskLimits.Add(new UserDiskLimit()
                {
                    UserId = diskLimitDto.UserId,
                    Limit = diskLimitDto.Limit
                });
            else
            {
                existingDiskLimit.Limit = diskLimitDto.Limit;
                appManagerApi.DbContext.UserDiskLimits.Update(existingDiskLimit);
            }


            await appManagerApi.DbContext.SaveChangesAsync();

        }

        [HttpPost("upsert-user")]
        public async Task Upsert(User user)
        {
            appManagerApi.DbContext.Upsert<User>(user);
            await appManagerApi.DbContext.SaveChangesAsync();
        }

        [HttpDelete("delete-user")]
        public async Task Delete(int id)
        {
            appManagerApi.DbContext.Users.Remove(new StorageManager.App.Models.User()
            {
                Id = id
            });
            await appManagerApi.DbContext.SaveChangesAsync();
        }
    }
}
