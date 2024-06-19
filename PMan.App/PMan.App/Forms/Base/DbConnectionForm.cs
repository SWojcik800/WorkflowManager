using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StorageManager.App.Database;

namespace StorageManager.App
{
    public partial class DbConnectionForm : Form
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

        ConnectionCreds data = new ConnectionCreds();
        public DbConnectionForm(ConnectionCreds? creds = null)
        {
            if (creds is not null)
                data = creds;
            InitializeComponent();
            this.connectionCredsBindingSource.DataSource = data;

            this.Opacity = 0;

            this._closeDialogFormTimer.Interval = 5;
            this._startFormTimer.Interval = 5;
            this._startFormTimer.Tick += new EventHandler(increaseTimerOpacity);
            this._startFormTimer.Start();
        }

        public static bool InitDbConnection()
        {
            var creds = DbConnectionFactory.GetFromRegistry();
            var form = new DbConnectionForm(creds);
            form.Text = "Połączenie z bazą danych";

            return form.ShowDialog() == DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var result = DbConnectionFactory.CanConnect(data);
            Cursor.Current = Cursors.Default;
            if (result.IsSuccess)
            {
                DbConnectionFactory.SaveToRegistry(data);
                DbConnectionFactory.InitDb(data);
                _closeDialogFormTimer.Tick += (object sender, EventArgs e) =>
                {
                    if (this.Opacity > 0)
                    {
                        this.Opacity -= 0.05;
                    }
                    else
                    {
                        this._closeDialogFormTimer.Stop();
                        DialogResult = DialogResult.OK;
                    }
                };

                _closeDialogFormTimer.Start();
            }
            else
                MessageBox.Show($"Niepoprawne poświadczenia: {result.ErrorMessage}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this._closeDialogFormTimer.Tick += (object sender, EventArgs e) =>
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.05;
                }
                else
                {
                    this._closeDialogFormTimer.Stop();
                    DialogResult = DialogResult.Cancel;
                }
            };

            this._closeDialogFormTimer.Start();
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


    }
}
