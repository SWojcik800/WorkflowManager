using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StorageManager.App.Commons;
using StorageManager.App.Database;
using StorageManager.App.Helpers;
using StorageManager.App.Models;
using StorageManager.App.Features.Users;
using Xunit;

public class UserServiceTests
{
    private readonly AppDbContext _mockContext;
    private readonly UserService _service;
    private readonly List<User> _users;

    public UserServiceTests()
    {
        _mockContext = Substitute.For<AppDbContext>();
        _service = new UserService(_mockContext);

        _users = new List<User>
        {
            new User { Id = 1, Login = "user1", Password = EncryptionHelper.Encrypt("password1") },
            new User { Id = 2, Login = "user2", Password = EncryptionHelper.Encrypt("password2") }
        };

        var mockDbSet = Substitute.For<DbSet<User>, IQueryable<User>>();
        ((IQueryable<User>)mockDbSet).Provider.Returns(_users.AsQueryable().Provider);
        ((IQueryable<User>)mockDbSet).Expression.Returns(_users.AsQueryable().Expression);
        ((IQueryable<User>)mockDbSet).ElementType.Returns(_users.AsQueryable().ElementType);
        ((IQueryable<User>)mockDbSet).GetEnumerator().Returns(_users.AsQueryable().GetEnumerator());

        _mockContext.Users.Returns(mockDbSet);
    }

    [Fact]
    public void GetAll_ShouldReturnAllUsers()
    {
        var result = _service.GetAll();
        Assert.Equal(2, result.Count);
        Assert.Equal("user1", result[0].Login);
        Assert.Equal("user2", result[1].Login);
    }

    [Fact]
    public void GetById_ShouldReturnCorrectUser()
    {
        var result = _service.GetById(1);
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("user1", result.Login);
    }

    [Fact]
    public void Login_ShouldReturnSuccess_WhenCredentialsAreCorrect()
    {
        var result = _service.Login("user1", "password1");
        Assert.True(result.IsSuccess);
        Assert.Equal("user1", result.Value.Login);
    }

    [Fact]
    public void Login_ShouldReturnFail_WhenUserDoesNotExist()
    {
        var result = _service.Login("nonexistent", "password");
        Assert.False(result.IsSuccess);
        Assert.Equal("Błędne dane logowania", result.ErrorMessage);
    }

    [Fact]
    public void Login_ShouldReturnFail_WhenPasswordIsNull()
    {
        _users[0].Password = null;
        var result = _service.Login("user1", "password1");
        Assert.False(result.IsSuccess);
        Assert.Equal("Brak ustawionego hasła", result.ErrorMessage);
    }

    [Fact]
    public void Login_ShouldReturnFail_WhenPasswordIsIncorrect()
    {
        var result = _service.Login("user1", "wrongpassword");
        Assert.False(result.IsSuccess);
        Assert.Equal("Błędne dane logowania", result.ErrorMessage);
    }

    [Fact]
    public void Upsert_ShouldAddNewUser()
    {
        var newUser = new User { Id = 0, Login = "newuser", Password = EncryptionHelper.Encrypt("newpassword") };

        var result = _service.Upsert(newUser);

        Assert.True(result.IsSuccess);
    
    }

    [Fact]
    public void Upsert_ShouldFailIfLoginExists()
    {
        var newUser = new User { Id = 0, Login = "user1", Password = EncryptionHelper.Encrypt("newpassword") };

        var result = _service.Upsert(newUser);

        Assert.False(result.IsSuccess);
        Assert.Equal($"Login {newUser.Login} jest już używany przez innego użytkownika", result.ErrorMessage);
    }

    [Fact]
    public void Upsert_ShouldUpdateExistingUser()
    {
        var existingUser = _users.First();
        existingUser.Login = "updateduser";


        var result = _service.Upsert(existingUser);

        Assert.True(result.IsSuccess);
        Assert.Equal("updateduser", _users.First().Login);
    }

    [Fact]
    public void Logout_ShouldClearCurrentUser()
    {
        _service.Login("user1", "password1");
        Assert.NotNull(_service.CurrentUser);

        _service.Logout();
        Assert.Null(_service.CurrentUser);
    }
}
