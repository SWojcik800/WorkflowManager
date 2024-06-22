using StorageManager.App.Commons.Controls;
using StorageManager.App.Features.Dictionaries;
using StorageManager.App.Features.Users;
using StorageManager.App.Forms.Base;
using StorageManager.App.Helpers;
using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkflowManager.App.Forms.Base;
using WorkflowManager.App.Helpers;

namespace StorageManager.App.Forms
{
    public partial class UserForm : AppFormBase
    {
        private readonly IUserService _service = AppManager.Instance.Resolve<IUserService>();
        private User _data;
        private bool _isEdit = false;
        private Func<int, bool> _changePwdFunc = (int id) => ChangePasswordForm.ChangePasswordForUser(id);
        protected UserForm(User user)
        {
            InitializeComponent();
            _data = user;
            this.userBindingSource.DataSource = _data;
        }

        public static bool MyAccount()
        {
            var currentUser = AppManager.Instance.CurrentUser;
            var form = new UserForm(currentUser);
            form.Text = "Moje konto";
            form._changePwdFunc = (int id) => ChangePasswordForm.ChangePasswordForCurrentUser();

            form.textBox1.ReadOnly = true;
            form.textBox2.ReadOnly = true;
            form.textBox3.ReadOnly = true;
            form.textBox4.ReadOnly = true;
            form.textBox5.ReadOnly = true;
            form.checkBox1.Enabled = false;
            form.button2.Enabled = false;
            form.button2.Visible = false;

            return form.ShowDialog() == DialogResult.OK;
        }

        public static bool AddNew()
        {
            var form = new UserForm(new User());
            form.Text = "Dodaj nowy";

            if (!AppManager.Instance.CurrentUser.IsAdmin)
            {
                AppManager.ShowPermissionDeniedMessage();
                return false;
            }

            return form.ShowDialog() == DialogResult.OK;
        }

        public static bool Edit(int id)
        {
            var userService = AppManager.Instance.Resolve<IUserService>();
            var form = new UserForm(userService.GetById(id));
            form._data = form._service.GetById(id);
            form.Text = "Edycja";
            form._isEdit = true;

            if (!AppManager.Instance.CurrentUser.IsAdmin)
            {
                AppManager.ShowPermissionDeniedMessage();
                return false;
            }

            form.textBox5.Enabled = false;

            return form.ShowDialog() == DialogResult.OK;
        }

        public static bool EditInline(int id, AppGridView appGridView)
        {
            var userService = AppManager.Instance.Resolve<IUserService>();
            var form = new UserForm(userService.GetById(id));
            form._data = form._service.GetById(id);
           
            form._isEdit = true;

            if (!AppManager.Instance.CurrentUser.IsAdmin)
            {
                AppManager.ShowPermissionDeniedMessage();
                return false;
            }

            form.textBox5.Enabled = false;


            return NestedFormHelper.OpenInGrid(appGridView, form);
        
        }

        public static bool AddNewInline(User user, AppGridView appGridView, int newRowIdx)
        {
            var userService = AppManager.Instance.Resolve<IUserService>();
            var form = new UserForm(user);

            if (!AppManager.Instance.CurrentUser.IsAdmin)
            {
                AppManager.ShowPermissionDeniedMessage();
                return false;
            }

            return NestedFormHelper.OpenInGrid(appGridView, form, true, newRowIdx);

        }


        private bool IsValid()
        {
            if (string.IsNullOrEmpty(_data.Login))
            {
                errorProvider1.SetError(textBox5, "To pole jest wymagane");
                return false;
            }

            if (string.IsNullOrEmpty(_data.FirstName))
            {
                errorProvider1.SetError(textBox1, "To pole jest wymagane");
                return false;
            }

            if (string.IsNullOrEmpty(_data.LastName))
            {
                errorProvider1.SetError(textBox3, "To pole jest wymagane");
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                var result = _service.Upsert(_data);
                if (result.IsSuccess)
                {
                    if (!_isEdit)
                        ChangePasswordForm.ChangePasswordForUser(_data.Id);

                    AppManager.ShowDataSavedMessage();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    AppManager.ShowErrorMessage(result.ErrorMessage);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_data.Id != 0)
                _changePwdFunc(_data.Id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseWithDialogResult(DialogResult.Cancel);
        }

        private void textBox4_MouseDown(object sender, MouseEventArgs e)
        {
            DataTableSelectionForm<DictionaryItem>.OpenWithDynamicColumnForControl<DictionaryItem>(new Dictionary<string, string>
            {
                { "Nazwa", "Name" },
                { "Wartość", "Value" },
            }, () =>
            {
                var service = AppManager.Instance.Resolve<IDataDictionaryService>();
                var dict = service
                .GetAll().FirstOrDefault(x => x.Name == "Grupy użytkowników");
                var data = service.GetById(dict.Id);
                if (data is null)
                {
                    AppManager.ShowErrorMessage("Brak zdefiniowanego słownika: Grupy użytkowników");
                    return new();
                }

                return data.DictionaryItems.ToList();

            }, (selectedRows) =>
            {
                var items = new List<string>();

                for (int i = 0; i < selectedRows.Count; i++)
                {
                    var item = selectedRows[i].DataBoundItem as DictionaryItem;
                    items.Add(item.Value);
                }

                _data.Groups = string.Join(";", items);
                this.userBindingSource.ResetCurrentItem();
        
            }, "Grupy użytkownika", textBox4, (AppGridView appGridView) =>
            {
                appGridView.ReadOnly = true;
                appGridView.MultiSelect = true;
                appGridView.AllowUserToAddRows = false;
                appGridView.AllowUserToDeleteRows = false;
            });
        }
    }

    public class UserGroupRow
    {
        public string Name { get; set; }
    }
}
