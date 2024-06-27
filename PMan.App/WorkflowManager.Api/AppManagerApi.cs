using StorageManager.App.Helpers;

namespace WorkflowManager.Api
{
    public class AppManagerApi : AppManagerCore
    {
        public string ConnectionString { get; set; }

        protected override string GetConnectionString()
        {
            return ConnectionString;
        }
    }
}
