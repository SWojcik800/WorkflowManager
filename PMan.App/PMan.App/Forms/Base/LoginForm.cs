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
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using StorageManager.App.Database;
using StorageManager.App.Features.Users;
using StorageManager.App.Helpers;

namespace StorageManager.App
{
    public partial class LoginForm : Form
    {


        private System.Windows.Forms.Timer _startFormTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer _closeFormTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer _closeDialogFormTimer = new System.Windows.Forms.Timer();


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        protected LoginForm()
        {

            InitializeComponent();
            this.button1.Focus();

            this.Opacity = 0;

            this._closeFormTimer.Tick += new EventHandler(decreaseTimerOpacity);

            this._closeFormTimer.Interval = 5;
            this._startFormTimer.Interval = 5;
            this._startFormTimer.Tick += new EventHandler(increaseTimerOpacity);
            this._startFormTimer.Start();
        }

        public static bool Open(bool tryToLoginFromRegistryCreds = false)
        {
            var login = RegistryAccessor.GetValue("UserLogin");
            if (tryToLoginFromRegistryCreds)
            {
                var password = RegistryAccessor.GetValue("UserPwd", true);
                var result = AppManager.Instance.Resolve<IUserService>().Login(login, password);

                if (result.IsSuccess)
                    return true;
            }
            var form = new LoginForm();
            form.textBox2.Text = login;

            return form.ShowDialog() == DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void PerformLogin()
        {
            var login = textBox2.Text;
            var password = textBox4.Text;

            var result = AppManager.Instance.Resolve<IUserService>().Login(login, password);

            if (result.IsSuccess)
            {
                if (checkBox2.Checked)
                {
                    RegistryAccessor.SaveValue("UserLogin", login);
                    RegistryAccessor.SaveValue("UserPwd", password, true);
                }

                _closeDialogFormTimer.Interval = 25;
                _closeDialogFormTimer.Tick += (object sender, EventArgs e) =>
                {
                    if (this.Opacity > 0)
                    {
                        this.Opacity -= 0.05;
                    }
                    else
                    {
                        this._startFormTimer.Stop();
                        DialogResult = DialogResult.OK;
                    }
                };
                _closeDialogFormTimer.Start(); 
            }
            else
            {
                AppManager.Instance.ShowErrorMessage(result.ErrorMessage);
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Version versionInfo = Assembly.GetExecutingAssembly().GetName().Version;
            DateTime startDate = new DateTime(2000, 1, 1);
            int diffDays = versionInfo.Build;
            DateTime computedDate = startDate.AddDays(diffDays);
            string lastBuilt = computedDate.ToShortDateString();
            this.label3.Text = string.Format("{0} - Wersja {1}",
                        this.label3.Text, versionInfo.ToString(), lastBuilt);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            _closeFormTimer.Start();
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
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void panel3_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
