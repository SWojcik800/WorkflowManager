using StorageManager.App.Forms;
using StorageManager.App.Forms.Base;
using StorageManager.App.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkflowManager.App.Forms;

namespace StorageManager.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitVersionLabel();
            InitSubMenus();
            this.currentUserLabel.Text = AppManager.Instance.CurrentUser.Login;
        }

        private void InitVersionLabel()
        {
            Version versionInfo = Assembly.GetExecutingAssembly().GetName().Version;
            DateTime startDate = new DateTime(2000, 1, 1);
            int diffDays = versionInfo.Build;
            DateTime computedDate = startDate.AddDays(diffDays);
            string lastBuilt = computedDate.ToShortDateString();
            this.versionLabel.Text = string.Format("Workflow manager - Wersja {0}", versionInfo.ToString(), lastBuilt);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DbConnectionForm.InitDbConnection();
        }


        private void OpenForm(Form childForm, string pageName)
        {
            pageTitleLabel.Text = pageName;

            childForm.TopLevel = false;

            childForm.FormBorderStyle = FormBorderStyle.None;

            if(this.panel2.Controls.Count > 0)
            {
                var oldControl = panel2.Controls[0];
                oldControl.Hide();
                this.panel2.Controls.Add(childForm);

                childForm.Dock = DockStyle.Fill;

                childForm.Show();
                panel2.Controls.Remove(oldControl);
            } else
            {
                this.panel2.Controls.Add(childForm);

                childForm.Dock = DockStyle.Fill;

                childForm.Show();
            }
            

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var childForm = new UserWorkflowsToProcessForm();
            OpenForm(childForm, "Przepływy do obsłużenia");

        }

        private void utworzonePrzezeMnieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new UserCreatedWorkflowsForm();
            OpenForm(childForm, "Przepływy utworzone przeze mnie");
        }

        private void doObsłużeniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new UserWorkflowsToProcessForm();
            OpenForm(childForm, "Przepływy do obsłużenia");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var childForm = new UserCreatedWorkflowsForm();
            OpenForm(childForm, "Utworzone przeze mnie");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var childForm = new UserWorkflowsToProcessForm();
            OpenForm(childForm, "Do obsłużenia");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkflowForm childForm = new WorkflowForm();
            OpenForm(childForm, "Szablony przepływów");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AppManager.Logout();

        }

        #region SubMenus
        private void InitSubMenus()
        {
            this.myWorkflowsSubMenuPanel.Visible = true;
            this.myAccountSubMenuPanel.Visible = false;
            this.administrationSubMenuPanel.Visible = false;

            if (!AppManager.Instance.CurrentUser.IsAdmin)
            {
                this.administrationSubmenuButton.Enabled = false;
                this.administrationSubmenuButton.Visible = false;
            }
        }
        private void myWorkflowsButton_Click(object sender, EventArgs e)
        {
            myWorkflowsSubMenuPanel.Visible = !myWorkflowsSubMenuPanel.Visible;
        }


        private void myAccountButton_Click_1(object sender, EventArgs e)
        {
            myAccountSubMenuPanel.Visible = !myAccountSubMenuPanel.Visible;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            UserForm.MyAccount();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangePasswordForm.ChangePasswordForCurrentUser();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AppManager.Logout();
        }
        #endregion

        private void button8_Click(object sender, EventArgs e)
        {
            CreateUserWorkflowForm.AddNewForCurrentUser();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            WorkflowForm childForm = new WorkflowForm();
            OpenForm(childForm, "Szablony przepływów");
        }

        private void configurationButton_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            DbConnectionForm.InitDbConnection();
        }

        private void usersButton_Click(object sender, EventArgs e)
        {
            UserListForm.OpenListForm();
        }

        private void dictionariesButton_Click(object sender, EventArgs e)
        {
            DictionariesListForm.OpenListForm();
        }

        private void workflowsButton_Click(object sender, EventArgs e)
        {
            WorkflowForm childForm = new WorkflowForm();
            OpenForm(childForm, "Szablony przepływów");
        }

        private void administrationSubmenuButton_Click(object sender, EventArgs e)
        {
            if (!AppManager.Instance.CurrentUser.IsAdmin)
                return;
            this.administrationSubMenuPanel.Visible = !this.administrationSubMenuPanel.Visible;
        }
    }
}
