using StorageManager.App.Features.Users;
using StorageManager.App.Helpers;
using StorageManager.App.Models;
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

namespace StorageManager.App.Forms.Base
{
    public partial class ChangePasswordForm : AppFormBase
    {
        private User _data;
        private bool _checkCurrentPassword = true;
        protected ChangePasswordForm(bool checkCurrentPassword)
        {
            InitializeComponent();
            InitForm();
            if (!checkCurrentPassword)
            {
                this.oldPasswordTextbox.Enabled = false;
                this.oldPasswordTextbox.ReadOnly = true;
                _checkCurrentPassword = checkCurrentPassword;
            }

        }

        public static bool ChangePasswordForCurrentUser()
        {
            var user = AppManager.Instance.CurrentUser;
            var form = new ChangePasswordForm(true);
            form._data = user;
            return form.ShowDialog() == DialogResult.OK;
        }

        public static bool ChangePasswordForUser(int userId)
        {

            var user = AppManager.Instance.Resolve<IUserService>().GetById(userId);
            var currentUser = AppManager.Instance.CurrentUser;
            
            if(!currentUser.IsAdmin)
            {
                AppManager.Instance.ShowPermissionDeniedMessage();
                return false;
            }



            var form = new ChangePasswordForm(false);
            form._data = user;
            return form.ShowDialog() == DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseWithDialogResult(DialogResult.Cancel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(_checkCurrentPassword)
            {
                if (_data.Password != EncryptionHelper.Decrypt(oldPasswordTextbox.Text))
                {
                    AppManager.Instance.ShowErrorMessage("Niepoprawne hasło");
                    return;
                }
            }

            if (newPasswordTexbox.Text != newPasswordTextboxRepeat.Text)
            {
                AppManager.Instance.ShowErrorMessage("Hasła się nie zgadzają");
                return;
            }

            if(string.IsNullOrEmpty(newPasswordTexbox.Text))
            {
                AppManager.Instance.ShowErrorMessage("Hasło nie może być puste");
                return;
            }

            _data.Password = EncryptionHelper.Encrypt(newPasswordTexbox.Text);

            var result = AppManager.Instance.Resolve<IUserService>()
                .Upsert(_data);

            if(result.IsSuccess)
            {
                AppManager.Instance.ShowInfoMessage("Hasło zostało zmienione");
                CloseWithDialogResult(DialogResult.OK);

            }
            else
            {
                AppManager.Instance.ShowErrorMessage(result.ErrorMessage);
            }
        }
    }
}
