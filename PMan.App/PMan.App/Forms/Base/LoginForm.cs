using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using StorageManager.App.Database;
using StorageManager.App.Features.Users;
using StorageManager.App.Helpers;

namespace StorageManager.App
{
    public partial class LoginForm : Form
    {
        protected LoginForm()
        {

            InitializeComponent();
            this.button2.Focus();
        }

        public static bool Open(bool tryToLoginFromRegistryCreds=false)
        {
            var login = RegistryAccessor.GetValue("UserLogin");
            if(tryToLoginFromRegistryCreds)
            {
                var password = RegistryAccessor.GetValue("UserPwd", true);
                var result = AppManager.Instance.Resolve<IUserService>().Login(login, password);

                if (result.IsSuccess)
                    return true;
            }
            var form = new LoginForm();
            form.textBox1.Text = login;
            return form.ShowDialog() == DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void PerformLogin()
        {
            var login = textBox1.Text;
            var password = textBox3.Text;

            var result = AppManager.Instance.Resolve<IUserService>().Login(login, password);

            if (result.IsSuccess)
            {
                if(checkBox1.Checked)
                {
                    RegistryAccessor.SaveValue("UserLogin", login);
                    RegistryAccessor.SaveValue("UserPwd", password, true);
                }
                DialogResult = DialogResult.OK;
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
    }
}
