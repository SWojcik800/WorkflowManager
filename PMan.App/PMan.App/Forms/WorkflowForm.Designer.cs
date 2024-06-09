using StorageManager.App.Commons.Controls;

namespace StorageManager.App
{
    partial class WorkflowForm
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
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel2 = new Panel();
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            textBox1 = new TextBox();
            editedItemBindingSource = new BindingSource(components);
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            appGridView1 = new AppGridView();
            codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            displayNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fieldTypeDataGridViewTextBoxColumn = new DataGridViewComboBoxColumn();
            displayDataDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            workflowFieldBindingSource = new BindingSource(components);
            tabPage3 = new TabPage();
            appGridView2 = new AppGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            AssignedEntityTypeDisplayName = new DataGridViewComboBoxColumn();
            AssignedEntityDisplayName = new DataGridViewTextBoxColumn();
            stageIndexDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            workflowStageBindingSource = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            dataGridView1 = new AppGridView();
            nameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            workflowFieldsCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            workflowStageCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            groupsThatCanStartDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            workflowBindingSource = new BindingSource(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)editedItemBindingSource).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)workflowFieldBindingSource).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)workflowStageBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)workflowBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(tabControl1);
            panel1.Location = new Point(12, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1045, 303);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1045, 39);
            panel2.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(7, 13);
            button3.Name = "button3";
            button3.Size = new Size(103, 23);
            button3.TabIndex = 5;
            button3.Text = "Dodaj nowy";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(116, 13);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Zapisz";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(1533, -48);
            button2.Name = "button2";
            button2.Size = new Size(109, 35);
            button2.TabIndex = 0;
            button2.Text = "Zatwierdź";
            button2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(3, 45);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1039, 255);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1031, 227);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dane podstawowe";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", editedItemBindingSource, "Name", true));
            textBox1.Location = new Point(109, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(309, 23);
            textBox1.TabIndex = 1;
            // 
            // editedItemBindingSource
            // 
            editedItemBindingSource.DataSource = typeof(Models.Workflow);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 48);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 2;
            label2.Text = "Mogą rozpocząć:";
            // 
            // textBox2
            // 
            textBox2.DataBindings.Add(new Binding("Text", editedItemBindingSource, "GroupsThatCanStart", true));
            textBox2.Location = new Point(109, 45);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(309, 23);
            textBox2.TabIndex = 3;
            textBox2.KeyDown += textBox2_KeyDown;
            textBox2.MouseDown += textBox2_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 13);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Nazwa:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(appGridView1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1031, 227);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Pola formularza";
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
            appGridView1.Columns.AddRange(new DataGridViewColumn[] { codeDataGridViewTextBoxColumn, displayNameDataGridViewTextBoxColumn, fieldTypeDataGridViewTextBoxColumn, displayDataDataGridViewTextBoxColumn });
            appGridView1.DataSource = workflowFieldBindingSource;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
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
            appGridView1.Size = new Size(1025, 221);
            appGridView1.TabIndex = 0;
            appGridView1.EditingControlShowing += appGridView1_EditingControlShowing;
            appGridView1.UserDeletingRow += appGridView1_UserDeletingRow;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            codeDataGridViewTextBoxColumn.HeaderText = "Kod pola";
            codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // displayNameDataGridViewTextBoxColumn
            // 
            displayNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayName";
            displayNameDataGridViewTextBoxColumn.HeaderText = "Nazwa wyświetlana";
            displayNameDataGridViewTextBoxColumn.Name = "displayNameDataGridViewTextBoxColumn";
            displayNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fieldTypeDataGridViewTextBoxColumn
            // 
            fieldTypeDataGridViewTextBoxColumn.DataPropertyName = "FieldType";
            fieldTypeDataGridViewTextBoxColumn.HeaderText = "Typ pola";
            fieldTypeDataGridViewTextBoxColumn.Name = "fieldTypeDataGridViewTextBoxColumn";
            fieldTypeDataGridViewTextBoxColumn.ReadOnly = true;
            fieldTypeDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            fieldTypeDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // displayDataDataGridViewTextBoxColumn
            // 
            displayDataDataGridViewTextBoxColumn.DataPropertyName = "DisplayData";
            displayDataDataGridViewTextBoxColumn.HeaderText = "Dane dodatkowe";
            displayDataDataGridViewTextBoxColumn.Name = "displayDataDataGridViewTextBoxColumn";
            displayDataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // workflowFieldBindingSource
            // 
            workflowFieldBindingSource.DataSource = typeof(Models.WorkflowField);
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(appGridView2);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1031, 227);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Etapy";
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
            appGridView2.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, AssignedEntityTypeDisplayName, AssignedEntityDisplayName, stageIndexDataGridViewTextBoxColumn });
            appGridView2.DataSource = workflowStageBindingSource;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            appGridView2.DefaultCellStyle = dataGridViewCellStyle8;
            appGridView2.Dock = DockStyle.Fill;
            appGridView2.EnableHeadersVisualStyles = false;
            appGridView2.GridColor = Color.FromArgb(166, 166, 166);
            appGridView2.Location = new Point(0, 0);
            appGridView2.MultiSelect = false;
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
            appGridView2.Size = new Size(1031, 227);
            appGridView2.TabIndex = 0;
            appGridView2.EditingControlShowing += appGridView2_EditingControlShowing;
            appGridView2.UserDeletingRow += appGridView2_UserDeletingRow;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Nazwa";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // AssignedEntityTypeDisplayName
            // 
            AssignedEntityTypeDisplayName.DataPropertyName = "AssignedEntityTypeDisplayName";
            AssignedEntityTypeDisplayName.HeaderText = "Typ przypisanego";
            AssignedEntityTypeDisplayName.Name = "AssignedEntityTypeDisplayName";
            AssignedEntityTypeDisplayName.ReadOnly = true;
            AssignedEntityTypeDisplayName.Resizable = DataGridViewTriState.True;
            AssignedEntityTypeDisplayName.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // AssignedEntityDisplayName
            // 
            AssignedEntityDisplayName.DataPropertyName = "AssignedEntityDisplayName";
            AssignedEntityDisplayName.HeaderText = "Przypisany";
            AssignedEntityDisplayName.Name = "AssignedEntityDisplayName";
            AssignedEntityDisplayName.ReadOnly = true;
            // 
            // stageIndexDataGridViewTextBoxColumn
            // 
            stageIndexDataGridViewTextBoxColumn.DataPropertyName = "StageIndex";
            stageIndexDataGridViewTextBoxColumn.HeaderText = "Kolejność etapu";
            stageIndexDataGridViewTextBoxColumn.Name = "stageIndexDataGridViewTextBoxColumn";
            stageIndexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // workflowStageBindingSource
            // 
            workflowStageBindingSource.DataSource = typeof(Models.WorkflowStage);
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(220, 220, 220);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = Color.Black;
            dataGridViewCellStyle12.Padding = new Padding(2);
            dataGridViewCellStyle12.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle12.SelectionForeColor = Color.Black;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn1, workflowFieldsCountDataGridViewTextBoxColumn, workflowStageCountDataGridViewTextBoxColumn, groupsThatCanStartDataGridViewTextBoxColumn });
            dataGridView1.DataSource = workflowBindingSource;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.White;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle13.ForeColor = Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = Color.White;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle13;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(166, 166, 166);
            dataGridView1.Location = new Point(12, 307);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = SystemColors.Control;
            dataGridViewCellStyle14.Font = new Font("Segoe UI Semilight", 9F);
            dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewCellStyle15.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle15.ForeColor = Color.White;
            dataGridViewCellStyle15.Padding = new Padding(4);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle15;
            dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(46, 46, 46);
            dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1045, 138);
            dataGridView1.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn1.HeaderText = "Nazwa";
            nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // workflowFieldsCountDataGridViewTextBoxColumn
            // 
            workflowFieldsCountDataGridViewTextBoxColumn.DataPropertyName = "WorkflowFieldsCount";
            workflowFieldsCountDataGridViewTextBoxColumn.HeaderText = "Liczba pól";
            workflowFieldsCountDataGridViewTextBoxColumn.Name = "workflowFieldsCountDataGridViewTextBoxColumn";
            workflowFieldsCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // workflowStageCountDataGridViewTextBoxColumn
            // 
            workflowStageCountDataGridViewTextBoxColumn.DataPropertyName = "WorkflowStageCount";
            workflowStageCountDataGridViewTextBoxColumn.HeaderText = "Liczba etapów";
            workflowStageCountDataGridViewTextBoxColumn.Name = "workflowStageCountDataGridViewTextBoxColumn";
            workflowStageCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupsThatCanStartDataGridViewTextBoxColumn
            // 
            groupsThatCanStartDataGridViewTextBoxColumn.DataPropertyName = "GroupsThatCanStart";
            groupsThatCanStartDataGridViewTextBoxColumn.HeaderText = "Grupy, które mogą rozpocząć";
            groupsThatCanStartDataGridViewTextBoxColumn.Name = "groupsThatCanStartDataGridViewTextBoxColumn";
            groupsThatCanStartDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // workflowBindingSource
            // 
            workflowBindingSource.DataSource = typeof(Models.Workflow);
            // 
            // WorkflowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "WorkflowForm";
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)editedItemBindingSource).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)appGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)workflowFieldBindingSource).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)appGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)workflowStageBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)workflowBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private ErrorProvider errorProvider1;
        private Panel panel2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private AppGridView dataGridView1;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private AppGridView appGridView1;
        private BindingSource workflowFieldBindingSource;
        private Button button1;
        private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn displayNameDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn fieldTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn displayDataDataGridViewTextBoxColumn;
        private BindingSource editedItemBindingSource;
        private AppGridView appGridView2;
        private BindingSource workflowStageBindingSource;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn AssignedEntityTypeDisplayName;
        private DataGridViewTextBoxColumn AssignedEntityDisplayName;
        private DataGridViewTextBoxColumn stageIndexDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn workflowFieldsCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn workflowStageCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn groupsThatCanStartDataGridViewTextBoxColumn;
        private BindingSource workflowBindingSource;
        private Button button3;
        private Button button2;
    }
}