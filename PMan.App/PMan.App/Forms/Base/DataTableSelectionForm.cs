using StorageManager.App.Commons.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageManager.App.Forms.Base
{
    public partial class DataTableSelectionForm<T> : Form
    {
        private DataGridViewColumn[] _columns;
        private BindingList<T> _tableDataSource = new BindingList<T>();
        private Action<DataGridViewSelectedRowCollection> _handleSelectedItems;
        private Func<List<T>> _getItemsFunc;
        private string _formTitle;


        public DataTableSelectionForm(DataGridViewColumn[] columns, Func<List<T>> getItemsFunc, Action<DataGridViewSelectedRowCollection> handleSelectedItems,
            string formTitle, Action<AppGridView>? configGridFunc = null)
        {
            _columns = columns;
            _getItemsFunc = getItemsFunc;
            _handleSelectedItems = handleSelectedItems;
            _formTitle = formTitle;

            var items = _getItemsFunc();

            foreach (var item in items)
            {
                _tableDataSource.Add(item);
            }

            InitializeComponent();

            this.Text = _formTitle;


            this.appGridView1.Columns.AddRange(columns);
            if (configGridFunc != null)
            {
                configGridFunc(this.appGridView1);
                this.appGridView1.Invalidate();
            }

            this.appGridView1.DataSource = _tableDataSource;
        }

        public static bool Open<T>(DataGridViewColumn[] columns, Func<List<T>> getItemsFunc, Action<DataGridViewSelectedRowCollection> handleSelectedItems,
            string formTitle, Point? location = null, Action<AppGridView>? configGridFunc = null)
        {
            var form = new DataTableSelectionForm<T>(columns, getItemsFunc, handleSelectedItems, formTitle, configGridFunc);

            if (location is null)
                form.Location = Cursor.Position;

            return form.ShowDialog() == DialogResult.OK;
        }

        public static bool OpenWithDynamicColumn<T>(Dictionary<string, string> columns, Func<List<T>> getItemsFunc, Action<DataGridViewSelectedRowCollection> handleSelectedItems,
            string formTitle, Point? location = null, Action<AppGridView>? configGridFunc = null)
        {
            var colDefs = new List<DataGridViewColumn>();
            var colList = columns.ToList();
            for (int i = 0; i < columns.Count; i++)
            {
                var colDef = new DataGridViewTextBoxColumn()
                {
                    Name = "Column" + i.ToString(),
                    HeaderText = colList[i].Key,
                    DataPropertyName = colList[i].Value,
                    ReadOnly = false
                };

                colDefs.Add(colDef);

            }

            var arr = colDefs.ToArray();
            var form = new DataTableSelectionForm<T>(arr, getItemsFunc, handleSelectedItems, formTitle, configGridFunc);

            if (location is null)
                form.Location = Cursor.Position;

            return form.ShowDialog() == DialogResult.OK;
        }

        protected virtual void RefreshTable()
        {
            //this.appGridView1.DataSource = null;
            //this._tableDataSource.C = _getItemsFunc();
            //this.appGridView1.DataSource = this._tableDataSource;
            this._tableDataSource.Clear();

            foreach (var item in _getItemsFunc())
            {
                _tableDataSource.Add(item);
            }
        }

        protected virtual void SetColumns(DataGridViewColumn[] columns)
        {
            appGridView1.Columns.AddRange(columns);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.appGridView1.SelectedRows.Count > 0)
            {
                _handleSelectedItems(this.appGridView1.SelectedRows);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
