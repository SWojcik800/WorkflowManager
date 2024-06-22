using StorageManager.App.Database;
using StorageManager.App.Models;

namespace StorageManager.App.Helpers
{
    public interface IAppManager
    {
        AppDbContext DbContext { get; }
        string CurrentPageTitle { get; set; }
        List<Dictionary> Dictionaries { get; }
        List<User> Users { get; }
        User CurrentUser { get; }

        void Init();
        IServiceProvider RegisterServices();
        TService Resolve<TService>();

    }
}