using Microsoft.VisualBasic.ApplicationServices;
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
using User = StorageManager.App.Models.User;

namespace StorageManager.App.Forms
{
    public partial class DictionaryForm : Form
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
            if(id != 0)
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

            if(IsValid())
            {
                var service = AppManager.Instance.Resolve<IDataDictionaryService>();

                _data.DictionaryItems = _items;
                var result = service.Upsert(_data);
                if(result.IsSuccess)
                {
                    AppManager.Instance.ShowDataSavedMessage();
                    DialogResult = DialogResult.OK;
                } else
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
            if(_items.Any(x => string.IsNullOrEmpty(x.Name) || string.IsNullOrEmpty(x.Value)))
            {
                AppManager.Instance.ShowErrorMessage("Wartość słownikowa musi mieć zdefiniowany klucz oraz wartość");
                return false;
            }

            if(string.IsNullOrEmpty(_data.Name))
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
    }
}
