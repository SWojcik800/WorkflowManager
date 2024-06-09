using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.Logging;
using StorageManager.App.Commons.IoC;
using StorageManager.App.Database;
using StorageManager.App.Features.Users;
using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkflowManager.App.Models;

namespace StorageManager.App.Helpers
{
    public sealed class AppManager
    {
        private IServiceProvider _serviceProvider;
        public AppDbContext DbContext { get; private set; }
        public static AppManager Instance;
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

        public static void Init()
        {
            Instance = new AppManager();
            Instance.DbContext = DbConnectionFactory.CreateDbContext();

            Instance._dictionaries = Instance.DbContext.Dictionaries.Include(x => x.DictionaryItems)
                .ToList();

            Instance._users = Instance.DbContext.Users.ToList();
        }

        public void Logout()
        {
            Instance.Resolve<IUserService>().Logout();
            RegistryAccessor.SaveValue("UserPwd", "", true);
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

        public static void RegisterServices()
        {
            ServiceCollection collection = new ServiceCollection();

            collection.Scan(scan => scan
                .FromAssemblyOf<AppManager>()
                    .AddClasses(classes => classes.AssignableTo<ITransientService>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                    .AddClasses(classes => classes.AssignableTo<IScopedService>())
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()
                    .AddClasses(classes => classes.AssignableTo<ISingleton>())
                        .AsImplementedInterfaces()
                        .WithSingletonLifetime());

            collection.AddSingleton<AppDbContext>(Instance.DbContext);
            Instance._serviceProvider = collection.BuildServiceProvider();
        }

        public TService Resolve<TService>()
        {
            return _serviceProvider.GetRequiredService<TService>();
        }

        public bool ShowYesNoDialog(string title, string content)
        {
            return MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Wystąpił błąd");
        }

        public void ShowInfoMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowDataSavedMessage()
        {
            Task.Run(() =>
            {
                MessageBox.Show("Zapisano dane");

            });
        }



        public void ShowPermissionDeniedMessage()
        {
            MessageBox.Show("Brak wymaganych uprawnień", "Brak uprawnień");
        }
    }
}
