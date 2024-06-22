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
using WorkflowManager.App.Forms.Base;
using WorkflowManager.App.Models;

namespace StorageManager.App.Helpers
{
    public sealed class AppManager : IAppManager
    {
        public AppDbContext DbContext { get
            {
                return Instance.DbContext;
            }
        }
        public static IAppManager Instance;
        public string CurrentPageTitle { get
            {
                return Instance.CurrentPageTitle;
            }
            set {
                Instance.CurrentPageTitle = value;   
            }
        }

        private List<Dictionary> _dictionaries;

        public List<Dictionary> Dictionaries { 
            get
            {
                return Instance.Dictionaries;
            }
        }

        private List<User> _users;

        public List<User> Users
        {
            get
            {
                return Instance.Users;
            }
        }

        public User CurrentUser { get { return Instance.CurrentUser; } }

        public void Init()
        {
            Instance = new AppManagerCore();
            Instance.Init();
        }

        public static void Logout()
        {
            Instance.Resolve<IUserService>().Logout();
            RegistryAccessor.SaveValue("UserPwd", "", true);
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

        public IServiceProvider RegisterServices()
        {
            return Instance.RegisterServices();
        }

        public TService Resolve<TService>()
        {
            return Instance.Resolve<TService>();
        }

        public static bool ShowYesNoDialog(string title, string content)
        {
            return MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void ShowErrorMessage(string errorMessage)
        {
            AppOkDialogForm.OpenForError(errorMessage);
        }

        public static void ShowInfoMessage(string message)
        {
            AppOkDialogForm.OpenForInfo(message: message);

        }

        public static void ShowDataSavedMessage()
        {
            AppOkDialogForm.OpenForInfo(message: "Zapisano dane");

        }



        public static void ShowPermissionDeniedMessage()
        {
            AppOkDialogForm.OpenForError("Brak wymaganych uprawnień");
        }
    }
}
