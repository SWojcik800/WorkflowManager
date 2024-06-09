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
    public partial class ShowImageForm : Form
    {
        protected ShowImageForm()
        {
            InitializeComponent();
        }

        public static void Show(Image image)
        {
            var form = new ShowImageForm();
            form.pictureBox1.Image = image;
            form.Show();
            form.Focus();
        }
    }
}
