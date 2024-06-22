using Microsoft.EntityFrameworkCore;
using StorageManager.App.Commons;
using StorageManager.App.Commons.IoC;
using StorageManager.App.Database;
using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManager.App.Features.Dictionaries
{
    public sealed class DataDictionaryService(AppDbContext context) : IDataDictionaryService
    {
        public List<Dictionary> GetAll()
            => context.Dictionaries.ToList();

        public Dictionary GetById(int id)
            => context.Dictionaries
            .Include(x => x.DictionaryItems)
            .First(x => x.Id == id);

        public Result<Dictionary> Upsert(Dictionary data)
        {
            if (data.Id == 0)
            {
                var dictionaryExists = context.Dictionaries.Any(x => x.Name == data.Name);

                if (dictionaryExists)
                    return Result<Dictionary>.Fail($"Naza {data.Name} jest już używana przez inny słownik");
            }
            context.Upsert<Dictionary>(data);
            context.SaveChanges();

            return Result<Dictionary>.Success(data);
        }
    }

    public interface IDataDictionaryService : ISingleton
    {
        List<Dictionary> GetAll();
        Dictionary GetById(int id);
        Result<Dictionary> Upsert(Dictionary data);
    }
}
