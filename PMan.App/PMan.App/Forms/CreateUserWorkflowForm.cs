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
using WorkflowManager.App.Features.UserWorkflows;
using WorkflowManager.App.Features.Workflows;
using WorkflowManager.App.Forms.Base;

namespace WorkflowManager.App.Forms
{
    public partial class CreateUserWorkflowForm : AppFormBase
    {
        private IWorkflowService _service = AppManager.Instance.Resolve<IWorkflowService>();
        private IUserWorkflowService _userWorkflowService = AppManager.Instance.Resolve<IUserWorkflowService>();
        protected CreateUserWorkflowForm()
        {
            InitializeComponent();
            InitForm();
            this.comboBox1.DataSource = _service.GetWorkflowsForUser(AppManager.Instance.CurrentUser);
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Id";
        }

        public static bool AddNewForCurrentUser()
        {
            var form = new CreateUserWorkflowForm();
            return form.ShowDialog() == DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Workflow selectedWorkflow = (Workflow)this.comboBox1.SelectedItem;
            _userWorkflowService.CreateUserWorkflow(selectedWorkflow.Id, AppManager.Instance.CurrentUser.Id);
            AppManager.Instance.ShowDataSavedMessage();
            this.DialogResult = DialogResult.OK;
        }
    }
}
