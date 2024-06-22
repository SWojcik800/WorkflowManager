using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using StorageManager.App.Commons.IoC;
using StorageManager.App.Database;
using StorageManager.App.Features.Users;
using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.App.Models;

namespace StorageManager.App.Helpers
{
    public sealed class AppManagerCore : IAppManager
    {
        private IServiceProvider _serviceProvider;
        public AppDbContext DbContext { get
            {
                return _serviceProvider.GetRequiredService<AppDbContext>();
            }
        }
        public static AppManagerCore Instance;
        public string CurrentPageTitle { get; set; }

        private List<Dictionary> _dictionaries;

        public List<Dictionary> Dictionaries { 
            get
            {
                return _dictionaries;
            }
        }

        private List<User> _users;

        public List<User> Users
        {
            get
            {
                return _users;
            }
        }

        public User CurrentUser { get { return _serviceProvider.GetRequiredService<IUserService>().CurrentUser; } }

        public void Init()
        {
            Instance = new AppManagerCore();
            RegisterServices();
            Instance._dictionaries = Instance.DbContext.Dictionaries.Include(x => x.DictionaryItems)
                .ToList();

            Instance._users = Instance.DbContext.Users.ToList();
        }

        public void Logout()
        {
            Instance.Resolve<IUserService>().Logout();
            
        }

        public IServiceProvider RegisterServices()
        {
            ServiceCollection collection = new ServiceCollection();

            collection.Scan(scan => scan
                .FromAssemblyOf<AppManagerCore>()
                    .AddClasses(classes => classes.AssignableTo<ITransientService>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                    .AddClasses(classes => classes.AssignableTo<IScopedService>())
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()
                    .AddClasses(classes => classes.AssignableTo<ISingleton>())
                        .AsImplementedInterfaces()
                        .WithSingletonLifetime());

            var creds = DbConnectionFactory.GetFromRegistry();
            var connectionString = DbConnectionFactory.GetConnectionString(creds);
            collection.AddDbContext<AppDbContext>((builder) =>
            {
                builder.UseSqlServer(connectionString);
            });

            var provider = collection.BuildServiceProvider();
            Instance._serviceProvider = provider;
            _serviceProvider = provider;
            return Instance._serviceProvider;
        }

        public TService Resolve<TService>()
        {
            return Instance._serviceProvider.GetRequiredService<TService>();
        }

        public void ShowDataSavedMessage()
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(string errorMessage)
        {
            throw new NotImplementedException();
        }

        public void ShowInfoMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowPermissionDeniedMessage()
        {
            throw new NotImplementedException();
        }

        public bool ShowYesNoDialog(string title, string content)
        {
            throw new NotImplementedException();
        }
    }
}
