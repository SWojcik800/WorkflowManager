using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace StorageManager.App.Helpers
{
    public static class RegistryAccessor
    {
        public static void SaveValue(string key, string value, bool isEncrypted = false)
        {
            if (isEncrypted)
                value = EncryptionHelper.Encrypt(value);

            Registry.CurrentUser.SetValue(@"ProcessManager_" + key, value);
        }

        public static string GetValue(string key, bool isEncrypted = false)
        {
            var value = Registry.CurrentUser.GetValue(@"ProcessManager_" +
                                    key, "");

            if (value is null)
                return "";

            if (isEncrypted)
                value = EncryptionHelper.Decrypt(value.ToString());

            return value.ToString();
        }
    }
}
