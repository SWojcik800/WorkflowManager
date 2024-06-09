﻿using StorageManager.App.Forms;
using StorageManager.App.Forms.Base;
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

namespace StorageManager.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
    }
}