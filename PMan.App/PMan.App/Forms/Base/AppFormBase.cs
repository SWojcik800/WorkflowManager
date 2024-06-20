using ReaLTaiizor.Forms;
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
    public partial class AppFormBase : RoyalForm
    {
        private System.Windows.Forms.Timer _startFormTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer _closeFormTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer _closeDialogFormTimer = new System.Windows.Forms.Timer();

        public AppFormBase()
        {
            InitializeComponent();
            //this.DrawBorder = true;
            InitForm();
        }

        protected void InitForm()
        {
            this.formTitleLabel.Text = this.Text;

            this._closeFormTimer.Tick += new EventHandler(decreaseTimerOpacity);

            this._closeFormTimer.Interval = 5;
            this._closeDialogFormTimer.Interval = 5;
            this._startFormTimer.Interval = 5;
            this._startFormTimer.Tick += new EventHandler(increaseTimerOpacity);
            this.Opacity = 0;
            this._startFormTimer.Start();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if(this.formTitleLabel is not null)
                this.formTitleLabel.Text = this.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _closeFormTimer.Start();
        }

        public new void Close()
        {
            _closeFormTimer.Start();
        }

        public void CloseWithDialogRsult(DialogResult dialogResult)
        {
            _closeDialogFormTimer.Tick += (object sender, EventArgs e) =>
             {
                 if (this.Opacity > 0)
                 {
                     this.Opacity -= 0.05;
                 }
                 else
                 {
                     this._startFormTimer.Stop();
                     DialogResult = dialogResult;
                 }
             };

            _closeDialogFormTimer.Start();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void increaseTimerOpacity(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05;
            }
            else
            {
                this._startFormTimer.Stop();
            }
        }

        private void decreaseTimerOpacity(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.05;
            }
            else
            {
                this._startFormTimer.Stop();
                base.Close();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}
