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
using WorkflowManager.App.Features.Workflows;

namespace WorkflowManager.App.Forms
{
    public partial class StageFieldsForm : Form
    {
        private List<WorkflowStageFieldModel> _data = new List<WorkflowStageFieldModel>();
        private IWorkflowService _service = AppManager.Instance.Resolve<IWorkflowService>();
        protected StageFieldsForm(int workflowId)
        {
            InitializeComponent();
            var stageFields = _service.ReadStageFields(workflowId);
            _data = stageFields;
            this.workflowStageFieldModelBindingSource.DataSource = _data;

            this.appGridView1.ReadOnly = false;
            //this.isEditableDataGridViewCheckBoxColumn.ReadOnly = false;
            //this.isRequiredDataGridViewCheckBoxColumn.ReadOnly = false;
            //this.isVisibleDataGridViewCheckBoxColumn.ReadOnly = false;

            this.appGridView1.DataSource = this._data;
        }

        public static void Open(int workflowId)
        {
            var form = new StageFieldsForm(workflowId);
            form.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _service.UpdateStageFields(_data);
            AppManager.Instance.ShowDataSavedMessage();
            
            DialogResult = DialogResult.OK;
        }
    }
}
