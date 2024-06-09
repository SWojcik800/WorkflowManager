using StorageManager.App.Commons.Controls;
using StorageManager.App.Features.Dictionaries;
using StorageManager.App.Features.Users;
using StorageManager.App.Forms.Base;
using StorageManager.App.Helpers;
using StorageManager.App.Models;
using System.ComponentModel;
using System.Data;
using WorkflowManager.App.Features.Workflows;
using WorkflowManager.App.Forms;

namespace StorageManager.App
{
    public partial class WorkflowForm : Form
    {
        private List<int> _deletedFieldsIds = new List<int>();
        private List<int> _deletedStagesIds = new List<int>();

        private IWorkflowService _service;
        List<Workflow> Items = new List<Workflow>();
        Workflow EditedItem = new Workflow();



        public WorkflowForm()
        {
            InitializeComponent();

            this.editedItemBindingSource.DataSource = EditedItem;
            this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

            this.appGridView1.AllowUserToAddRows = true;
            this.appGridView1.AllowUserToDeleteRows = true;
            this.appGridView1.ReadOnly = false;

            this.workflowFieldBindingSource.DataSource = EditedItem.WorkflowFields;
            this.appGridView1.DataSource = this.workflowFieldBindingSource;


            this.appGridView2.AllowUserToAddRows = true;
            this.appGridView2.AllowUserToDeleteRows = true;
            this.appGridView2.ReadOnly = false;

            this.workflowStageBindingSource.DataSource = this.EditedItem.WorkflowStage;
            this.appGridView2.DataSource = this.workflowStageBindingSource;

            this._service = AppManager.Instance.Resolve<IWorkflowService>();
            Items = _service.GetAll();

            this.workflowBindingSource.DataSource = Items;
            this.dataGridView1.DataSource = this.workflowBindingSource;

            var options = new List<string>()
            {
                "Zgłaszający",
                "Grupa",
                "Użytkownik"
            };

            this.AssignedEntityTypeDisplayName.DataSource = options;

            this.fieldTypeDataGridViewTextBoxColumn.DataSource = WorkflowFieldTypeExtensions.GetOptions();
            //this.FieldType.DataSource = WorkflowFieldTypeExtensions.GetOptions();

            //RefreshItems();
        }

        private void DataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var item = (Workflow)this.dataGridView1.SelectedRows[0].DataBoundItem;
                var editedItem = _service.GetById(item.Id);

                EditedItem.Id = editedItem.Id;
                EditedItem.Name = editedItem.Name;
                EditedItem.GroupsThatCanStart = editedItem.GroupsThatCanStart;

                EditedItem.WorkflowStage = editedItem.WorkflowStage;
                EditedItem.WorkflowFields = editedItem.WorkflowFields;



                //EditedItem.Read(item.Id);
                this.editedItemBindingSource.ResetCurrentItem();
                this.workflowStageBindingSource.ResetCurrentItem();
                this.workflowFieldBindingSource.ResetCurrentItem();

                this.workflowFieldBindingSource.DataSource = EditedItem.WorkflowFields;
                this.appGridView1.DataSource = null;
                this.appGridView1.DataSource = this.workflowFieldBindingSource;

                this.workflowStageBindingSource.DataSource = this.EditedItem.WorkflowStage;
                this.appGridView2.DataSource = null;
                this.appGridView2.DataSource = this.workflowStageBindingSource;

            }
        }

        private void refreshitems()
        {

        }

        private void richTextBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }


        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DbConnectionForm.InitDbConnection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var isValid = IsValid();

            try
            {
                if (isValid)
                {
                    _service.Upsert(EditedItem, _deletedFieldsIds, _deletedStagesIds);

                    StageFieldsForm.Open(EditedItem.Id);

                    var editedItem = _service.GetById(EditedItem.Id);
                    RefreshEditedItem(editedItem);

                    this._service = AppManager.Instance.Resolve<IWorkflowService>();
                    Items = _service.GetAll();

                    this.workflowBindingSource.DataSource = Items;
                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.DataSource = this.workflowBindingSource;
                }

            }
            catch (Exception ex)
            {
                AppManager.Instance.ShowErrorMessage($"Wystąpił błąd podczas zapisu danych: {ex.Message}");
            }
        }

        private void RefreshEditedItem(Workflow editedItem)
        {
            EditedItem.Id = editedItem.Id;
            EditedItem.Name = editedItem.Name;
            EditedItem.GroupsThatCanStart = editedItem.GroupsThatCanStart;

            EditedItem.WorkflowStage = editedItem.WorkflowStage;
            EditedItem.WorkflowFields = editedItem.WorkflowFields;



            //EditedItem.Read(item.Id);
            this.editedItemBindingSource.ResetCurrentItem();
            this.workflowStageBindingSource.ResetCurrentItem();
            this.workflowFieldBindingSource.ResetCurrentItem();

            this.workflowFieldBindingSource.DataSource = EditedItem.WorkflowFields;
            this.appGridView1.DataSource = null;
            this.appGridView1.DataSource = this.workflowFieldBindingSource;

            this.workflowStageBindingSource.DataSource = this.EditedItem.WorkflowStage;
            this.appGridView2.DataSource = null;
            this.appGridView2.DataSource = this.workflowStageBindingSource;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            DataTableSelectionForm<DictionaryItem>.OpenWithDynamicColumn<DictionaryItem>(new Dictionary<string, string>
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
                    AppManager.Instance.ShowErrorMessage("Brak zdefiniowanego słownika: Grupy użytkowników");
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

                EditedItem.GroupsThatCanStart = string.Join(";", items);
                this.editedItemBindingSource.ResetCurrentItem();

            }, "Grupy użytkownika", textBox2.Location, (AppGridView appGridView) =>
            {
                appGridView.ReadOnly = true;
                appGridView.MultiSelect = true;
                appGridView.AllowUserToAddRows = false;
                appGridView.AllowUserToDeleteRows = false;
            });
        }

        private bool IsValid()
        {
            this.errorProvider1.Clear();

            if (string.IsNullOrEmpty(EditedItem.Name))
            {
                this.tabControl1.SelectedTab = this.tabPage1;
                this.errorProvider1.SetError(this.textBox1, "To pole jest wymagane");
                return false;
            }

            var formCodes = EditedItem.WorkflowFields.Select(x => x.Code).ToList();

            if (formCodes.Count > formCodes.Distinct().Count())
            {
                this.tabControl1.SelectedTab = this.tabPage2;

                AppManager.Instance.ShowErrorMessage("Kod pola musi być unikalny");

                return false;
            }

            if (EditedItem.WorkflowFields.Any(x => string.IsNullOrEmpty(x.DisplayName) || string.IsNullOrEmpty(x.Code)))
            {
                this.tabControl1.SelectedTab = this.tabPage2;

                AppManager.Instance.ShowErrorMessage("Kod pola oraz nazwa wyświetlana są wymagane");

                return false;
            }

            if (!EditedItem.WorkflowFields.Any())
            {
                this.tabControl1.SelectedTab = this.tabPage2;

                AppManager.Instance.ShowErrorMessage("Brak dodanych pól");

                return false;
            }



            return true;
        }

        private void appGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var item = (WorkflowField)e.Row.DataBoundItem;

            _deletedFieldsIds.Add(item.Id);
        }

        private void appGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var item = (WorkflowStage)e.Row.DataBoundItem;

            _deletedStagesIds.Add(item.Id);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshEditedItem(new Workflow());
        }

        private void appGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((AppGridView)sender).CurrentCell.ColumnIndex == 2)
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.SelectionChangeCommitted -= new EventHandler(ComboBox_SelectedIndexChanged);
                    cb.SelectionChangeCommitted += new EventHandler(ComboBox_SelectedIndexChanged);
                }
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                var selectedItem = comboBox.SelectedItem;
                if (selectedItem is null)
                    return;

                if (selectedItem == "Słownik")
                {

                    var item = this.appGridView1.CurrentRow.DataBoundItem as WorkflowField;

                    if (item is not null)
                    {
                        DataTableSelectionForm<Dictionary>.OpenWithDynamicColumn<Dictionary>(new Dictionary<string, string>
                        {
                            { "Nazwa", "Name" },
                        }, () =>
                        {
                            var service = AppManager.Instance.Resolve<IDataDictionaryService>();
                            var dicts = service
                            .GetAll().ToList();
                            var data = dicts;


                            return data;

                        }, (selectedRows) =>
                        {
                            var row = selectedRows[0].DataBoundItem as Dictionary;
                            item.DisplayData = row.Id.ToString();

                            this.appGridView1.Refresh();

                        }, "Słowniki", comboBox.Location, (AppGridView appGridView) =>
                        {
                            appGridView.ReadOnly = true;
                            appGridView.MultiSelect = false;
                            appGridView.AllowUserToAddRows = false;
                            appGridView.AllowUserToDeleteRows = false;
                        });
                    }

                }
            }
        }

        private void appGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((AppGridView)sender).CurrentCell.ColumnIndex == 1)
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.SelectionChangeCommitted -= new EventHandler(ComboBox_AssignedTypendexChanged);
                    cb.SelectionChangeCommitted += new EventHandler(ComboBox_AssignedTypendexChanged);
                }
            }
        }

        private void ComboBox_AssignedTypendexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                var selectedItem = comboBox.SelectedItem;
                if (selectedItem is null)
                    return;

                var item = this.appGridView2.CurrentRow.DataBoundItem as WorkflowStage;

                if (item is not null)
                {


                    if (selectedItem == "Grupa")
                    {

                        DataTableSelectionForm<DictionaryItem>.OpenWithDynamicColumn<DictionaryItem>(new Dictionary<string, string>
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
                            AppManager.Instance.ShowErrorMessage("Brak zdefiniowanego słownika: Grupy użytkowników");
                            return new();
                        }

                        return data.DictionaryItems.ToList();

                    }, (selectedRows) =>
                    {
                        var selectedRow = selectedRows[0].DataBoundItem as DictionaryItem;

                        item.AssignedEntityId = selectedRow.Id;
                        this.appGridView2.Refresh();

                    }, "Grupy użytkownika", comboBox.Location, (AppGridView appGridView) =>
                    {
                        appGridView.ReadOnly = true;
                        appGridView.MultiSelect = false;
                        appGridView.AllowUserToAddRows = false;
                        appGridView.AllowUserToDeleteRows = false;
                    });



                    }
                    if (selectedItem == "Użytkownik")
                    {
                        DataTableSelectionForm<User>.OpenWithDynamicColumn<User>(new Dictionary<string, string>
                    {
                        { "Login", "Login" },
                    }, () =>
                    {
                        var service = AppManager.Instance.Resolve<IUserService>();
                        var data = service
                        .GetAll().ToList();

                        return data;

                    }, (selectedRows) =>
                    {
                        var selectedRow = selectedRows[0].DataBoundItem as User;

                        item.AssignedEntityId = selectedRow.Id;
                        this.appGridView2.Refresh();

                    }, "Użytkownicy", comboBox.Location, (AppGridView appGridView) =>
                    {
                        appGridView.ReadOnly = true;
                        appGridView.MultiSelect = false;
                        appGridView.AllowUserToAddRows = false;
                        appGridView.AllowUserToDeleteRows = false;
                    });

                    }
                }


            }
        }
    }


}
