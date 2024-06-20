namespace StorageManager.App.Forms
{
    partial class DictionaryForm
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
            button1 = new Button();
            panel1 = new Panel();
            textBox1 = new TextBox();
            dictionaryBindingSource = new BindingSource(components);
            label1 = new Label();
            button2 = new Button();
            appGridView1 = new Commons.Controls.AppGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            IsDefault = new DataGridViewCheckBoxColumn();
            dictionaryItemBindingSource = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dictionaryBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)appGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dictionaryItemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Right;
            button1.Location = new Point(633, 33);
            button1.Name = "button1";
            button1.Size = new Size(121, 31);
            button1.TabIndex = 0;
            button1.Text = "Zapisz";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(12, 39);
            panel1.Name = "panel1";
            panel1.Size = new Size(757, 67);
            panel1.TabIndex = 3;
            panel1.Controls.SetChildIndex(button1, 0);
            panel1.Controls.SetChildIndex(label1, 0);
            panel1.Controls.SetChildIndex(textBox1, 0);
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", dictionaryBindingSource, "Name", true));
            textBox1.Location = new Point(103, 7);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(217, 23);
            textBox1.TabIndex = 2;
            // 
            // dictionaryBindingSource
            // 
            dictionaryBindingSource.DataSource = typeof(Models.Dictionary);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 1;
            label1.Text = "Nazwa słownika:";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Right;
            button2.Location = new Point(506, 33);
            button2.Name = "button2";
            button2.Size = new Size(121, 31);
            button2.TabIndex = 3;
            button2.Text = "Anuluj";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // appGridView1
            // 
            appGridView1.AllowUserToAddRows = false;
            appGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 220, 220);
            appGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            appGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            appGridView1.AutoGenerateColumns = false;
            appGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            appGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
            appGridView1.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, valueDataGridViewTextBoxColumn, IsDefault });
            appGridView1.DataSource = dictionaryItemBindingSource;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            appGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            appGridView1.EnableHeadersVisualStyles = false;
            appGridView1.GridColor = Color.FromArgb(166, 166, 166);
            appGridView1.Location = new Point(12, 112);
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
            appGridView1.Size = new Size(757, 326);
            appGridView1.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Nazwa";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            valueDataGridViewTextBoxColumn.HeaderText = "Wartość";
            valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // IsDefault
            // 
            IsDefault.DataPropertyName = "IsDefault";
            IsDefault.HeaderText = "Wartość domyślna";
            IsDefault.Name = "IsDefault";
            IsDefault.ReadOnly = true;
            // 
            // dictionaryItemBindingSource
            // 
            dictionaryItemBindingSource.DataSource = typeof(Models.DictionaryItem);
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // DictionaryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 450);
            Controls.Add(appGridView1);
            Controls.Add(panel1);
            Name = "DictionaryForm";
            Opacity = 1D;
            Text = "Lista słowników";
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(appGridView1, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dictionaryBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)appGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dictionaryItemBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Panel panel1;
        private Commons.Controls.AppGridView appGridView1;
        private BindingSource dictionaryItemBindingSource;
        private TextBox textBox1;
        private Label label1;
        private BindingSource dictionaryBindingSource;
        private ErrorProvider errorProvider1;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn IsDefault;
        private Button button2;
    }
}