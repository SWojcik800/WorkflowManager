using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkflowManager.App.Forms.Base
{
    public partial class AppOkDialogForm : AppFormBase
    {
        protected AppOkDialogForm()
        {
            InitializeComponent();
            InitForm();
        }

        public static void OpenForError(string errorMessage)
        {
            var form = new AppOkDialogForm();
            form.Text = "Wystąpił błąd";
            form.label1.Text = errorMessage;

            //form.BringToFront();
            //form.Show();
            //form.Focus();

            form.ShowDialog();
        }

        public static void OpenForInfo(string message, string title = "Informacja")
        {
            var form = new AppOkDialogForm();
            form.Text = title;
            form.label1.Text = message;

            //form.BringToFront();

            //form.Show();
            //form.Focus();
            form.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
