using Microsoft.VisualBasic.ApplicationServices;
using StorageManager.App.Features.Dictionaries;
using StorageManager.App.Features.Users;
using StorageManager.App.Forms.Base;
using StorageManager.App.Helpers;
using StorageManager.App.Models;
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
using User = StorageManager.App.Models.User;

namespace StorageManager.App.Forms
{
    public partial class DictionariesListForm : AppFormBase
    {
        private List<Dictionary> _data;
        protected DictionariesListForm()
        {
            InitializeComponent();
            InitForm();

            var service = AppManager.Instance.Resolve<IDataDictionaryService>();
            var items = service.GetAll();

            _data = items;
            this.dictionaryBindingSource.DataSource = _data;
        }

        public static void OpenListForm()
        {
            var currentUser = AppManager.Instance.CurrentUser;

            if (!currentUser.IsAdmin)
            {
                AppManager.ShowPermissionDeniedMessage();
                return;
            }

            var form = new DictionariesListForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.appGridView1.SelectedRows.Count > 0)
            {
                Dictionary data = appGridView1.SelectedRows[0].DataBoundItem as Dictionary;
                var result = DictionaryForm.Edit(data.Id);
                if (result)
                    RefreshTable();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = DictionaryForm.AddNew();
            if (result)
                RefreshTable();

        }

        private void RefreshTable()
        {
            var service = AppManager.Instance.Resolve<IDataDictionaryService>();

            this._data = service.GetAll();
            this.appGridView1.DataSource = null;
            this.appGridView1.DataSource = _data;
        }

        private void appGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.appGridView1.SelectedRows.Count > 0)
            {
                Dictionary data = appGridView1.SelectedRows[0].DataBoundItem as Dictionary;
                var result = DictionaryForm.Edit(data.Id);
                if (result)
                    RefreshTable();
            }
        }
    }
}
