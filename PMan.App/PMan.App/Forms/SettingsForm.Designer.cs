﻿namespace WorkflowManager.App.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            appGridView1 = new StorageManager.App.Commons.Controls.AppGridView();
            displayNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            settingBindingSource = new BindingSource(components);
            button3 = new Button();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)appGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingBindingSource).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // appGridView1
            // 
            appGridView1.AllowUserToAddRows = false;
            appGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 220, 220);
            appGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            appGridView1.AutoGenerateColumns = false;
            appGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            appGridView1.BackgroundColor = Color.WhiteSmoke;
            appGridView1.BorderStyle = BorderStyle.Fixed3D;
            appGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            appGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            appGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appGridView1.Columns.AddRange(new DataGridViewColumn[] { displayNameDataGridViewTextBoxColumn, valueDataGridViewTextBoxColumn });
            appGridView1.DataSource = settingBindingSource;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            appGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            appGridView1.Dock = DockStyle.Fill;
            appGridView1.EnableHeadersVisualStyles = false;
            appGridView1.GridColor = Color.FromArgb(166, 166, 166);
            appGridView1.Location = new Point(0, 85);
            appGridView1.MultiSelect = false;
            appGridView1.Name = "appGridView1";
            appGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semilight", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            appGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.Padding = new Padding(4);
            appGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            appGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            appGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            appGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(46, 46, 46);
            appGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            appGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            appGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appGridView1.Size = new Size(800, 365);
            appGridView1.TabIndex = 0;
            // 
            // displayNameDataGridViewTextBoxColumn
            // 
            displayNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayName";
            displayNameDataGridViewTextBoxColumn.HeaderText = "Nazwa";
            displayNameDataGridViewTextBoxColumn.Name = "displayNameDataGridViewTextBoxColumn";
            displayNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            valueDataGridViewTextBoxColumn.HeaderText = "Wartość";
            valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // settingBindingSource
            // 
            settingBindingSource.DataSource = typeof(ApplicationCore.Models.Setting);
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.White;
            button3.FlatAppearance.BorderColor = SystemColors.ControlDark;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(697, 6);
            button3.Name = "button3";
            button3.Size = new Size(100, 34);
            button3.TabIndex = 4;
            button3.Text = "Zapisz";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 52);
            panel2.TabIndex = 5;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(appGridView1);
            Controls.Add(panel2);
            Name = "SettingsForm";
            Opacity = 1D;
            Text = "Ustawienia";
            Controls.SetChildIndex(panel2, 0);
            Controls.SetChildIndex(appGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)appGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingBindingSource).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private StorageManager.App.Commons.Controls.AppGridView appGridView1;
        private BindingSource settingBindingSource;
        private Button button3;
        private Panel panel2;
        private DataGridViewTextBoxColumn displayNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    }
}