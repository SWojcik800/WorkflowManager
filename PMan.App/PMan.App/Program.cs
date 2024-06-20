using StorageManager.App.Database;
using StorageManager.App.Forms;
using StorageManager.App.Helpers;

namespace StorageManager.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var creds = DbConnectionFactory.GetFromRegistry();

                if(DbConnectionFactory.CanConnect(creds).IsSuccess)
                {
                    DbConnectionFactory.InitDb(creds);
                    RunApplication();
                } else
                {
                    var dbResult = DbConnectionForm.InitDbConnection();
                    if(dbResult)
                    {
                        RunApplication();
                    }
                }

            }
            catch (Exception e)
            {

                MessageBox.Show($"Wystąpił błąd: {e.Message}");
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                Application.Exit();
            }

        }

        private static void RunApplication()
        {
            AppManager.Init();
            AppManager.RegisterServices();

            var result = LoginForm.Open(true);

            if(result)
            {
                Application.Run(new MainForm());
            }
        }
    }
}