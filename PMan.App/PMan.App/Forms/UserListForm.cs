using Microsoft.VisualBasic.ApplicationServices;
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
using User = StorageManager.App.Models.User;

namespace StorageManager.App.Forms
{
    public partial class UserListForm : Form
    {
        private List<User> _data;
        protected UserListForm()
        {
            InitializeComponent();

            var userService = AppManager.Instance.Resolve<IUserService>();
            var users = userService.GetAll();

            _data = users;
            this.userBindingSource.DataSource = _data;
        }

        public static void OpenListForm()
        {
            var currentUser = AppManager.Instance.CurrentUser;

            if (!currentUser.IsAdmin)
            {
                AppManager.Instance.ShowPermissionDeniedMessage();
                return;
            }

            var form = new UserListForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.appGridView1.SelectedRows.Count > 0)
            {
                User data = appGridView1.SelectedRows[0].DataBoundItem as User;
                var result = UserForm.EditInline(data.Id, appGridView1);
                if (result)
                    RefreshTable();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new User();
            _data.Add(user);
            this.appGridView1.DataSource = null;
            this.appGridView1.DataSource = _data;
            var idx = _data.IndexOf(user);
            var result = UserForm.AddNewInline(user, appGridView1, idx);
            if (result)
                RefreshTable();
            else
                _data.Remove(user);
            this.appGridView1.DataSource = null;
            this.appGridView1.DataSource = _data;
        }

        private void RefreshTable()
        {
            var userService = AppManager.Instance.Resolve<IUserService>();

            this._data = userService.GetAll();
            this.appGridView1.DataSource = null;
            this.appGridView1.DataSource = _data;
        }

        private void appGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.appGridView1.SelectedRows.Count > 0)
            {
                User data = appGridView1.SelectedRows[0].DataBoundItem as User;
                var result = UserForm.EditInline(data.Id, appGridView1);
                if (result)
                    RefreshTable();
            }
        }

        private void appGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.appGridView1.SelectedRows.Count > 0)
            {
                User data = appGridView1.SelectedRows[0].DataBoundItem as User;
                var result = UserForm.EditInline(data.Id, appGridView1);
                if (result)
                    RefreshTable();
            }
        }
    }
}
