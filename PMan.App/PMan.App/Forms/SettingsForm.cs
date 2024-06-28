using StorageManager.App.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkflowManager.App.Forms.Base;
using WorkflowManager.ApplicationCore.Models;

namespace WorkflowManager.App.Forms
{
    public partial class SettingsForm : AppFormBase
    {
        private List<Setting> Data = new List<Setting>();
        protected SettingsForm()
        {
            InitializeComponent();
            InitForm();
            Data = AppManager.Instance.DbContext.Settings.ToList();
            this.settingBindingSource.DataSource = Data;
            this.appGridView1.DataSource = this.settingBindingSource;
            this.appGridView1.ReadOnly = false;
        }

        public static void Open()
        {
            if (!AppManager.Instance.CurrentUser.IsAdmin)
            {
                AppManager.ShowPermissionDeniedMessage();
                return;
            }
            var form = new SettingsForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppManager.Instance.DbContext.Settings.UpdateRange(Data);
            AppManager.Instance.DbContext.SaveChanges();
            AppManager.ShowDataSavedMessage();
        }
    }
}
