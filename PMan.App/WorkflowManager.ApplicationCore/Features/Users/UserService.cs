using Microsoft.EntityFrameworkCore;
using StorageManager.App.Commons;
using StorageManager.App.Commons.IoC;
using StorageManager.App.Database;
using StorageManager.App.Helpers;
using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManager.App.Features.Users
{
    public sealed class UserService(AppDbContext context) : IUserService
    {
        public User CurrentUser { get; private set; }
        public string CurrentUserToken { get; private set; }
        public Result<User> Login(string login, string password)
        {
            var user = context.Users.Include(x => x.UserUserGroups)
                .FirstOrDefault(x => x.Login == login);

            if(user is null)
                return Result<User>.Fail("Błędne dane logowania");

            if(user.Password is null)
                return Result<User>.Fail("Brak ustawionego hasła");


            var loginResult = EncryptionHelper.Encrypt(password) == user.Password;

            if (loginResult)
            {
                CurrentUser = user;
                return Result<User>.Success(user);
            }

            return Result<User>.Fail("Błędne dane logowania");
        }

        public List<User> GetAll()
            => context.Users.ToList();

        public User GetById(int id)
        {
            return context.Users.First(x => x.Id == id);
        }
        public Result<User> Upsert(User user)
        {
            if (user.Id == 0)
            {
                var loginExists = context.Users.Any(x => x.Login == user.Login);

                if (loginExists)
                    return Result<User>.Fail($"Login {user.Login} jest już używany przez innego użytkownika");
            }

            context.Upsert<User>(user);
            context.SaveChanges();

            return Result<User>.Success(user);
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }

    public interface IUserService : ISingleton
    {
        User CurrentUser { get; }
        void Logout();
        List<User> GetAll();
        User GetById(int id);
        Result<User> Login(string login, string password);
        Result<User> Upsert(User user);
    }
}
