using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManager.App.Commons.Controls
{
    public class AppGridView : DataGridView
    {
        public AppGridView()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellColumnStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();

            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 220, 220);
            this.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.AutoGenerateColumns = false;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.BackgroundColor = Color.WhiteSmoke;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellColumnStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellColumnStyle.BackColor = SystemColors.ButtonFace;
            dataGridViewCellColumnStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellColumnStyle.ForeColor = Color.Black;
            dataGridViewCellColumnStyle.Padding = new Padding(2);
            dataGridViewCellColumnStyle.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellColumnStyle.SelectionForeColor = Color.Black;
            dataGridViewCellColumnStyle.WrapMode = DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellColumnStyle;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            this.DefaultCellStyle = dataGridViewCellStyle3;
            this.EnableHeadersVisualStyles = false;
            this.GridColor = Color.FromArgb(166, 166, 166);
            this.Location = new Point(122, 132);
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semilight", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            this.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.Padding = new Padding(4);
            this.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(46, 46, 46);
            this.RowTemplate.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            this.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            this.TabIndex = 0;

            this.BorderStyle = BorderStyle.Fixed3D;
            this.MultiSelect = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.ReadOnly = true;

            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;


        }



    }
}
