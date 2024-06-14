﻿namespace WorkflowManager.App.Forms
{
    partial class UserWorkflowsToProcessForm
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            appGridView1 = new StorageManager.App.Commons.Controls.AppGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dictStatusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            assignedToUserDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            userWorkflowReadModelBindingSource = new BindingSource(components);
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)appGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userWorkflowReadModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // appGridView1
            // 
            appGridView1.AllowUserToAddRows = false;
            appGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(220, 220, 220);
            appGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            appGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            appGridView1.AutoGenerateColumns = false;
            appGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            appGridView1.BackgroundColor = Color.WhiteSmoke;
            appGridView1.BorderStyle = BorderStyle.Fixed3D;
            appGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.Padding = new Padding(2);
            dataGridViewCellStyle7.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle7.SelectionForeColor = Color.Black;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            appGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            appGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, dictStatusDataGridViewTextBoxColumn, stageDataGridViewTextBoxColumn, assignedToUserDataGridViewTextBoxColumn });
            appGridView1.DataSource = userWorkflowReadModelBindingSource;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            appGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            appGridView1.EnableHeadersVisualStyles = false;
            appGridView1.GridColor = Color.FromArgb(166, 166, 166);
            appGridView1.Location = new Point(12, 65);
            appGridView1.MultiSelect = false;
            appGridView1.Name = "appGridView1";
            appGridView1.ReadOnly = true;
            appGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI Semilight", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            appGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.Padding = new Padding(4);
            appGridView1.RowsDefaultCellStyle = dataGridViewCellStyle10;
            appGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            appGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            appGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(46, 46, 46);
            appGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            appGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            appGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appGridView1.Size = new Size(1045, 373);
            appGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Identyfikator";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Typ przepływu";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dictStatusDataGridViewTextBoxColumn
            // 
            dictStatusDataGridViewTextBoxColumn.DataPropertyName = "DictStatus";
            dictStatusDataGridViewTextBoxColumn.HeaderText = "Status";
            dictStatusDataGridViewTextBoxColumn.Name = "dictStatusDataGridViewTextBoxColumn";
            dictStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stageDataGridViewTextBoxColumn
            // 
            stageDataGridViewTextBoxColumn.DataPropertyName = "Stage";
            stageDataGridViewTextBoxColumn.HeaderText = "Etap";
            stageDataGridViewTextBoxColumn.Name = "stageDataGridViewTextBoxColumn";
            stageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // assignedToUserDataGridViewTextBoxColumn
            // 
            assignedToUserDataGridViewTextBoxColumn.DataPropertyName = "AssignedToUser";
            assignedToUserDataGridViewTextBoxColumn.HeaderText = "Przypisane do użytkownika";
            assignedToUserDataGridViewTextBoxColumn.Name = "assignedToUserDataGridViewTextBoxColumn";
            assignedToUserDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userWorkflowReadModelBindingSource
            // 
            userWorkflowReadModelBindingSource.DataSource = typeof(Models.UserWorkflowReadModel);
            // 
            // button1
            // 
            button1.Location = new Point(12, 36);
            button1.Name = "button1";
            button1.Size = new Size(109, 23);
            button1.TabIndex = 1;
            button1.Text = "Przypisz do mnie";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(127, 36);
            button2.Name = "button2";
            button2.Size = new Size(99, 23);
            button2.TabIndex = 2;
            button2.Text = "Edytuj";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // UserWorkflowsToProcessForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(appGridView1);
            Name = "UserWorkflowsToProcessForm";
            Text = "UserWorkflowsToProcessForm";
            ((System.ComponentModel.ISupportInitialize)appGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)userWorkflowReadModelBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private StorageManager.App.Commons.Controls.AppGridView appGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dictStatusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn assignedToUserDataGridViewTextBoxColumn;
        private BindingSource userWorkflowReadModelBindingSource;
        private Button button1;
        private Button button2;
    }
}