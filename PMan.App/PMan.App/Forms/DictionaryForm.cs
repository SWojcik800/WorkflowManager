using Microsoft.VisualBasic.ApplicationServices;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkflowManager.App.Forms.Base;
using WorkflowManager.App.Helpers;
using User = StorageManager.App.Models.User;

namespace StorageManager.App.Forms
{
    public partial class DictionaryForm : AppFormBase
    {
        private Dictionary _data;
        private List<DictionaryItem> _items;
        protected DictionaryForm(int id)
        {
            InitializeComponent();

            this.appGridView1.AllowUserToAddRows = true;
            this.appGridView1.AllowUserToDeleteRows = true;
            this.appGridView1.ReadOnly = false;

            var service = AppManager.Instance.Resolve<IDataDictionaryService>();
            var data = new Dictionary()
            {
                Name = "Nowy słownik"
            };
            if (id != 0)
                data = service.GetById(id);

            _data = data;
            _items = data.DictionaryItems.ToList();
            this.dictionaryItemBindingSource.DataSource = _items;
            this.dictionaryBindingSource.DataSource = _data;
        }

        public static bool AddNew()
        {
            var currentUser = AppManager.Instance.CurrentUser;

            if (!currentUser.IsAdmin)
            {
                AppManager.Instance.ShowPermissionDeniedMessage();
                return false;
            }

            var form = new DictionaryForm(0);
            form.Text = "Nowy słownik";
            return form.ShowDialog() == DialogResult.OK;
        }

        public static bool Edit(int id)
        {
            var currentUser = AppManager.Instance.CurrentUser;

            if (!currentUser.IsAdmin)
            {
                AppManager.Instance.ShowPermissionDeniedMessage();
                return false;
            }

            var form = new DictionaryForm(id);
            form.Text = "Edycja słownika";
            return form.ShowDialog() == DialogResult.OK;
        }

        public static bool EditInline(AppGridView appGridView, int id)
        {
            var currentUser = AppManager.Instance.CurrentUser;

            if (!currentUser.IsAdmin)
            {
                AppManager.Instance.ShowPermissionDeniedMessage();
                return false;
            }

            var form = new DictionaryForm(id);
            return NestedFormHelper.OpenInGrid(appGridView, form);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.appGridView1.SelectedRows.Count > 0)
            {
                //User data = appGridView1.SelectedRows[0].DataBoundItem as User;
                //var result = UserForm.Edit(data.Id);
                //if (result)
                //    RefreshTable();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (IsValid())
            {
                var service = AppManager.Instance.Resolve<IDataDictionaryService>();

                _data.DictionaryItems = _items;
                var result = service.Upsert(_data);
                if (result.IsSuccess)
                {
                    AppManager.Instance.ShowDataSavedMessage();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    AppManager.Instance.ShowErrorMessage(result.ErrorMessage);
                }
            }
            //var result = UserForm.AddNew();
            //if (result)
            //    RefreshTable();
        }

        private bool IsValid()
        {
            if (_items.Any(x => string.IsNullOrEmpty(x.Name) || string.IsNullOrEmpty(x.Value)))
            {
                AppManager.Instance.ShowErrorMessage("Wartość słownikowa musi mieć zdefiniowany klucz oraz wartość");
                return false;
            }

            if (_items.Count(x => x.IsDefault) > 1)
            {
                AppManager.Instance.ShowErrorMessage("Tylko jedna wartość słownikowa może być ustawiona jako domyślna");
                return false;
            }

            if (string.IsNullOrEmpty(_data.Name))
            {
                this.errorProvider1.SetError(textBox1, "Nazwa słownika nie może być pusta");
                textBox1.Focus();
                return false;
            }



            return true;

        }


        private void appGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.appGridView1.SelectedRows.Count > 0)
            {
                //User data = appGridView1.SelectedRows[0].DataBoundItem as User;
                //var result = UserForm.Edit(data.Id);
                //if (result)
                //    RefreshTable();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
