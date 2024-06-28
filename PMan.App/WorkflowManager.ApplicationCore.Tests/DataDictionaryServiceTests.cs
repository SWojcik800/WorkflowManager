using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using StorageManager.App.Database;
using StorageManager.App.Features.Dictionaries;
using StorageManager.App.Models;

public class DataDictionaryServiceTests
{
    private AppDbContext _mockContext;
    private DataDictionaryService _service;
    private List<Dictionary> _dictionaries;

    public DataDictionaryServiceTests()
    {
        _mockContext = Substitute.For<AppDbContext>();
        _service = new DataDictionaryService(_mockContext);

        _dictionaries = new List<Dictionary>
        {
            new Dictionary { Id = 1, Name = "Test Dictionary 1" },
            new Dictionary { Id = 2, Name = "Test Dictionary 2" }
        };

        var mockDbSet = Substitute.For<DbSet<Dictionary>, IQueryable<Dictionary>>();
        ((IQueryable<Dictionary>)mockDbSet).Provider.Returns(_dictionaries.AsQueryable().Provider);
        ((IQueryable<Dictionary>)mockDbSet).Expression.Returns(_dictionaries.AsQueryable().Expression);
        ((IQueryable<Dictionary>)mockDbSet).ElementType.Returns(_dictionaries.AsQueryable().ElementType);
        ((IQueryable<Dictionary>)mockDbSet).GetEnumerator().Returns(_dictionaries.AsQueryable().GetEnumerator());

        _mockContext.Dictionaries.Returns(mockDbSet);
    }

    [Fact]
    public void GetAll_ShouldReturnAllDictionaries()
    {
        var result = _service.GetAll();
        Assert.Equal(2, result.Count);
        Assert.Equal("Test Dictionary 1", result[0].Name);
        Assert.Equal("Test Dictionary 2", result[1].Name);
    }

    [Fact]
    public void GetById_ShouldReturnCorrectDictionary()
    {
        var result = _service.GetById(1);
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Test Dictionary 1", result.Name);
    }

    [Fact]
    public void Upsert_ShouldAddNewDictionary()
    {
        var newDictionary = new Dictionary { Id = 0, Name = "New Dictionary" };

        var result = _service.Upsert(newDictionary);

        Assert.True(result.IsSuccess);

    }

    [Fact]
    public void Upsert_ShouldUpdateExistingDictionary()
    {
        var existingDictionary = _dictionaries.First();
        existingDictionary.Name = "Updated Dictionary";

        var result = _service.Upsert(existingDictionary);

        Assert.True(result.IsSuccess);
    }
}
