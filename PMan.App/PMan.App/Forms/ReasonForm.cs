using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkflowManager.App.Forms.Base;

namespace WorkflowManager.App.Forms
{
    public partial class ReasonForm : AppFormBase
    {
        public string Reason { get; set; }
        public ReasonForm()
        {
            InitializeComponent();
            InitForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reason = this.richTextBox1.Text;
            CloseWithDialogResult(DialogResult.OK);
        }
    }
}
