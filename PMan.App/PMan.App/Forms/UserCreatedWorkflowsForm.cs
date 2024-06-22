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
using WorkflowManager.App.Features.UserWorkflows;
using WorkflowManager.App.Models;

namespace WorkflowManager.App.Forms
{
    public partial class UserCreatedWorkflowsForm : Form
    {
        private IUserWorkflowService _service = AppManager.Instance.Resolve<IUserWorkflowService>();
        private List<UserWorkflowReadModel> _data = new List<UserWorkflowReadModel>();

        public UserCreatedWorkflowsForm()
        {
            InitializeComponent();
            _data = _service.ListUserCreatedWorkflows();
            this.userWorkflowReadModelBindingSource.DataSource = _data;
            this.appGridView1.DataSource = this.userWorkflowReadModelBindingSource;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.appGridView1.SelectedRows.Count > 0)
            {
                var currentRow = this.appGridView1.SelectedRows[0].DataBoundItem as UserWorkflowReadModel;
                UserWorkflowForm.OpenInReadOnlyMode(currentRow.Id);
            }
        }

        private void appGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.appGridView1.SelectedRows.Count > 0)
            {
                var currentRow = this.appGridView1.SelectedRows[0].DataBoundItem as UserWorkflowReadModel;
                UserWorkflowForm.OpenInReadOnlyMode(currentRow.Id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _data = _service.ListUserCreatedWorkflows();
            this.userWorkflowReadModelBindingSource.DataSource = _data;
            this.userWorkflowReadModelBindingSource.ResetBindings(true);
        }
    }
}
