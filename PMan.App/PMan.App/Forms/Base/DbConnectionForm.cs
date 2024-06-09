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
        ConnectionCreds data = new ConnectionCreds();
        public DbConnectionForm(ConnectionCreds? creds = null)
        {
            if(creds is not null)
                data = creds;
            InitializeComponent();
            this.connectionCredsBindingSource.DataSource = data;
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
            var result = DbConnectionFactory.CanConnect(data);

            if (result.IsSuccess)
            {
                DbConnectionFactory.SaveToRegistry(data);
                DbConnectionFactory.InitDb(data);
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show($"Niepoprawne poświadczenia: {result.ErrorMessage}");
        }
    }
}
