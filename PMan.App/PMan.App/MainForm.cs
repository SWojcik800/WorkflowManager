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

        private void OpenForm(Form childForm)
        {
            if (!AppManager.Instance.CurrentUser.IsAdmin)
            {
                AppManager.Instance.ShowPermissionDeniedMessage();
                return;
            }

            childForm.TopLevel = false;

            childForm.FormBorderStyle = FormBorderStyle.None;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(childForm);

            childForm.Dock = DockStyle.Fill;

            childForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var childForm = new UserWorkflowsToProcessForm();
            OpenForm(childForm);

        }

        private void zmieńHasłoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm.ChangePasswordForCurrentUser();
        }

        private void użytkownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserListForm.OpenListForm();
        }

        private void szczegółyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm.MyAccount();
        }

        private void słownikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DictionariesListForm.OpenListForm();
        }

        private void szablonyPrzepływówToolStripMenuItem_Click(object sender, EventArgs e)
        {

            WorkflowForm childForm = new WorkflowForm();
            OpenForm(childForm);
        }

        private void wylogujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppManager.Instance.Logout();
        }

        private void wyjdźZProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dodajNowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUserWorkflowForm.AddNewForCurrentUser();
        }

        private void utworzonePrzezeMnieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new UserCreatedWorkflowsForm();
            OpenForm(childForm);
        }

        private void doObsłużeniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new UserWorkflowsToProcessForm();
            OpenForm(childForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var childForm = new UserCreatedWorkflowsForm();
            OpenForm(childForm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var childForm = new UserWorkflowsToProcessForm();
            OpenForm(childForm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkflowForm childForm = new WorkflowForm();
            OpenForm(childForm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AppManager.Instance.Logout();

        }

        #region SubMenus
        private void InitSubMenus()
        {
            this.myWorkflowsSubMenuPanel.Visible = true;
            this.myAccountSubMenuPanel.Visible = false;
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
            AppManager.Instance.Logout();
        }
        #endregion

        private void button8_Click(object sender, EventArgs e)
        {
            CreateUserWorkflowForm.AddNewForCurrentUser();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            WorkflowForm childForm = new WorkflowForm();
            OpenForm(childForm);
        }

        private void configurationButton_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            DbConnectionForm.InitDbConnection();
        }
    }
}
