﻿using StorageManager.App.Helpers;
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
    public partial class UserWorkflowsToProcessForm : Form
    {
        private IUserWorkflowService _service = AppManager.Instance.Resolve<IUserWorkflowService>();
        private List<UserWorkflowReadModel> _data;
        public UserWorkflowsToProcessForm()
        {
            InitializeComponent();

            _data = _service.StagesToProcess();
            this.userWorkflowReadModelBindingSource.DataSource = _data;
            this.appGridView1.DataSource = this.userWorkflowReadModelBindingSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.appGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = this.appGridView1.SelectedRows[0].DataBoundItem as UserWorkflowReadModel;

                var confirm = AppManager.ShowYesNoDialog("Przypisanie do zadania", "Czy napewno chcesz przypisać to zadanie do siebie?");

                if (confirm)
                {
                    var result = _service.AssignToCurrentUser(selectedRow.Id, selectedRow.CurrentStageId);

                    if (result.IsSuccess)
                    {
                        AppManager.ShowDataSavedMessage();
                        RefreshTable();
                    }
                    else
                    {
                        AppManager.ShowErrorMessage(result.ErrorMessage);
                    }

                }


            }
        }

        private void RefreshTable()
        {
            _data = _service.StagesToProcess();
            this.userWorkflowReadModelBindingSource.DataSource = _data;
            this.appGridView1.DataSource = null;
            this.appGridView1.DataSource = this.userWorkflowReadModelBindingSource;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var currentRow = this.appGridView1.CurrentRow.DataBoundItem as UserWorkflowReadModel;

            if (currentRow is not null)
            {
                var result = UserWorkflowForm.Open(currentRow.Id);

                if (result)
                    RefreshTable();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void appGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var currentRow = this.appGridView1.CurrentRow.DataBoundItem as UserWorkflowReadModel;

            if (currentRow is not null)
            {
                var result = UserWorkflowForm.Open(currentRow.Id);

                if (result)
                    RefreshTable();
            }
        }
    }
}
