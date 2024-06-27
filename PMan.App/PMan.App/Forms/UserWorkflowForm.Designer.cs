namespace WorkflowManager.App.Forms
{
    partial class UserWorkflowForm
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            appGridView1 = new StorageManager.App.Commons.Controls.AppGridView();
            titleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            detailsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            actionUserLoginDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            actionDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            userHistoryEntryReadModelBindingSource = new BindingSource(components);
            tabPage3 = new TabPage();
            appGridView2 = new StorageManager.App.Commons.Controls.AppGridView();
            fileNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            creatorLoginDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            creationTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            attachmentDtoBindingSource = new BindingSource(components);
            panel2 = new Panel();
            button4 = new Button();
            button3 = new Button();
            errorProvider1 = new ErrorProvider(components);
            button1 = new Button();
            button2 = new Button();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userHistoryEntryReadModelBindingSource).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)attachmentDtoBindingSource).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 80);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 461);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 433);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Pola";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(appGridView1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 433);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Historia";
            tabPage2.UseVisualStyleBackColor = true;
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
            appGridView1.Columns.AddRange(new DataGridViewColumn[] { titleDataGridViewTextBoxColumn, detailsDataGridViewTextBoxColumn, actionUserLoginDataGridViewTextBoxColumn, actionDateDataGridViewTextBoxColumn });
            appGridView1.DataSource = userHistoryEntryReadModelBindingSource;
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
            appGridView1.Location = new Point(3, 3);
            appGridView1.MultiSelect = false;
            appGridView1.Name = "appGridView1";
            appGridView1.ReadOnly = true;
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
            appGridView1.Size = new Size(762, 427);
            appGridView1.TabIndex = 0;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            titleDataGridViewTextBoxColumn.HeaderText = "Operacja";
            titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // detailsDataGridViewTextBoxColumn
            // 
            detailsDataGridViewTextBoxColumn.DataPropertyName = "Details";
            detailsDataGridViewTextBoxColumn.HeaderText = "Szczegóły";
            detailsDataGridViewTextBoxColumn.Name = "detailsDataGridViewTextBoxColumn";
            detailsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // actionUserLoginDataGridViewTextBoxColumn
            // 
            actionUserLoginDataGridViewTextBoxColumn.DataPropertyName = "ActionUserLogin";
            actionUserLoginDataGridViewTextBoxColumn.HeaderText = "Operację wykonał";
            actionUserLoginDataGridViewTextBoxColumn.Name = "actionUserLoginDataGridViewTextBoxColumn";
            actionUserLoginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // actionDateDataGridViewTextBoxColumn
            // 
            actionDateDataGridViewTextBoxColumn.DataPropertyName = "ActionDate";
            actionDateDataGridViewTextBoxColumn.HeaderText = "Data wykonania operacji";
            actionDateDataGridViewTextBoxColumn.Name = "actionDateDataGridViewTextBoxColumn";
            actionDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userHistoryEntryReadModelBindingSource
            // 
            userHistoryEntryReadModelBindingSource.DataSource = typeof(Models.UserHistoryEntryReadModel);
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(appGridView2);
            tabPage3.Controls.Add(panel2);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(768, 433);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Pliki";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // appGridView2
            // 
            appGridView2.AllowUserToAddRows = false;
            appGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(220, 220, 220);
            appGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            appGridView2.AutoGenerateColumns = false;
            appGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            appGridView2.BackgroundColor = Color.WhiteSmoke;
            appGridView2.BorderStyle = BorderStyle.Fixed3D;
            appGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.Padding = new Padding(2);
            dataGridViewCellStyle7.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle7.SelectionForeColor = Color.Black;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            appGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            appGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appGridView2.Columns.AddRange(new DataGridViewColumn[] { fileNameDataGridViewTextBoxColumn, creatorLoginDataGridViewTextBoxColumn, creationTimeDataGridViewTextBoxColumn });
            appGridView2.DataSource = attachmentDtoBindingSource;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            appGridView2.DefaultCellStyle = dataGridViewCellStyle8;
            appGridView2.Dock = DockStyle.Fill;
            appGridView2.EnableHeadersVisualStyles = false;
            appGridView2.GridColor = Color.FromArgb(166, 166, 166);
            appGridView2.Location = new Point(3, 41);
            appGridView2.Name = "appGridView2";
            appGridView2.ReadOnly = true;
            appGridView2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI Semilight", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            appGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.Padding = new Padding(4);
            appGridView2.RowsDefaultCellStyle = dataGridViewCellStyle10;
            appGridView2.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            appGridView2.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            appGridView2.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(46, 46, 46);
            appGridView2.RowTemplate.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            appGridView2.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            appGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appGridView2.Size = new Size(762, 389);
            appGridView2.TabIndex = 0;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            fileNameDataGridViewTextBoxColumn.HeaderText = "Nazwa pliku";
            fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // creatorLoginDataGridViewTextBoxColumn
            // 
            creatorLoginDataGridViewTextBoxColumn.DataPropertyName = "CreatorLogin";
            creatorLoginDataGridViewTextBoxColumn.HeaderText = "Dodany przez";
            creatorLoginDataGridViewTextBoxColumn.Name = "creatorLoginDataGridViewTextBoxColumn";
            creatorLoginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // creationTimeDataGridViewTextBoxColumn
            // 
            creationTimeDataGridViewTextBoxColumn.DataPropertyName = "CreationTime";
            creationTimeDataGridViewTextBoxColumn.HeaderText = "Data dodania";
            creationTimeDataGridViewTextBoxColumn.Name = "creationTimeDataGridViewTextBoxColumn";
            creationTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // attachmentDtoBindingSource
            // 
            attachmentDtoBindingSource.DataSource = typeof(AttachmentDto);
            // 
            // panel2
            // 
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(762, 38);
            panel2.TabIndex = 1;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.FlatAppearance.BorderColor = SystemColors.ControlDark;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.Black;
            button4.Location = new Point(167, 3);
            button4.Name = "button4";
            button4.Size = new Size(158, 32);
            button4.TabIndex = 1;
            button4.Text = "Dodaj nowy";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.FlatAppearance.BorderColor = SystemColors.ControlDark;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Black;
            button3.Location = new Point(3, 3);
            button3.Name = "button3";
            button3.Size = new Size(158, 32);
            button3.TabIndex = 0;
            button3.Text = "Pobierz zaznaczone";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderColor = SystemColors.ControlDark;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(16, 39);
            button1.Name = "button1";
            button1.Size = new Size(75, 35);
            button1.TabIndex = 1;
            button1.Text = "Cofnij";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderColor = SystemColors.ControlDark;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(97, 39);
            button2.Name = "button2";
            button2.Size = new Size(123, 35);
            button2.TabIndex = 2;
            button2.Text = "Przekaż dalej";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // UserWorkflowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 553);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            Name = "UserWorkflowForm";
            Opacity = 1D;
            Text = "UserWorkflowForm";
            Controls.SetChildIndex(tabControl1, 0);
            Controls.SetChildIndex(button1, 0);
            Controls.SetChildIndex(button2, 0);
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)appGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)userHistoryEntryReadModelBindingSource).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)appGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)attachmentDtoBindingSource).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ErrorProvider errorProvider1;
        private Button button2;
        private Button button1;
        private StorageManager.App.Commons.Controls.AppGridView appGridView1;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn detailsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn actionUserLoginDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn actionDateDataGridViewTextBoxColumn;
        private BindingSource userHistoryEntryReadModelBindingSource;
        private TabPage tabPage3;
        private StorageManager.App.Commons.Controls.AppGridView appGridView2;
        private DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn creatorLoginDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn creationTimeDataGridViewTextBoxColumn;
        private BindingSource attachmentDtoBindingSource;
        private Panel panel2;
        private Button button3;
        private Button button4;
    }
}