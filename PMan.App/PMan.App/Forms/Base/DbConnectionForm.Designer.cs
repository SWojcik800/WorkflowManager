using StorageManager.App.Database;

namespace StorageManager.App
{
    partial class DbConnectionForm
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
            connectionCredsBindingSource = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label4 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            button2 = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            button1 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            label5 = new Label();
            panel5 = new Panel();
            ((System.ComponentModel.ISupportInitialize)connectionCredsBindingSource).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // connectionCredsBindingSource
            // 
            connectionCredsBindingSource.DataSource = typeof(ConnectionCreds);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 117);
            label1.Name = "label1";
            label1.Size = new Size(58, 21);
            label1.TabIndex = 1;
            label1.Text = "Server:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(52, 187);
            label2.Name = "label2";
            label2.Size = new Size(52, 21);
            label2.TabIndex = 2;
            label2.Text = "Login:";
            // 
            // textBox2
            // 
            textBox2.DataBindings.Add(new Binding("Text", connectionCredsBindingSource, "Login", true));
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(157, 184);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(341, 29);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(52, 219);
            label3.Name = "label3";
            label3.Size = new Size(52, 21);
            label3.TabIndex = 4;
            label3.Text = "Hasło:";
            // 
            // textBox3
            // 
            textBox3.DataBindings.Add(new Binding("Text", connectionCredsBindingSource, "Password", true));
            textBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(157, 219);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(341, 29);
            textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            textBox4.DataBindings.Add(new Binding("Text", connectionCredsBindingSource, "Database", true));
            textBox4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(157, 149);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(341, 29);
            textBox4.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(52, 152);
            label4.Name = "label4";
            label4.Size = new Size(99, 21);
            label4.TabIndex = 7;
            label4.Text = "Baza danych:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.DataBindings.Add(new Binding("Checked", connectionCredsBindingSource, "IntegratedSecurity", true));
            checkBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(157, 254);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(158, 25);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Integrated security";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.DataBindings.Add(new Binding("Checked", connectionCredsBindingSource, "TrustServerCertificate", true));
            checkBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox2.Location = new Point(157, 285);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(181, 25);
            checkBox2.TabIndex = 9;
            checkBox2.Text = "Trust server certificate";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderColor = SystemColors.ControlDark;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(157, 326);
            button2.Name = "button2";
            button2.Size = new Size(158, 38);
            button2.TabIndex = 11;
            button2.Text = "Połącz";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(211, 441);
            panel1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = WorkflowManager.App.Properties.Resources.database_solid;
            pictureBox1.Location = new Point(35, 83);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(140, 165);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(211, 40);
            panel3.TabIndex = 0;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(checkBox2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(checkBox1);
            panel2.Controls.Add(textBox2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(211, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(570, 441);
            panel2.TabIndex = 13;
            // 
            // panel4
            // 
            panel4.Controls.Add(button1);
            panel4.Controls.Add(button3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(570, 40);
            panel4.TabIndex = 17;
            panel4.MouseDown += panel4_MouseDown;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(41, 128, 185);
            button1.Location = new Point(530, 0);
            button1.Name = "button1";
            button1.Size = new Size(40, 40);
            button1.TabIndex = 15;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(41, 128, 185);
            button3.Location = new Point(484, 0);
            button3.Name = "button3";
            button3.Size = new Size(40, 40);
            button3.TabIndex = 16;
            button3.Text = "_";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", connectionCredsBindingSource, "Server", true));
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(157, 114);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(341, 29);
            textBox1.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(41, 128, 185);
            label5.Location = new Point(52, 59);
            label5.Name = "label5";
            label5.Size = new Size(251, 30);
            label5.TabIndex = 12;
            label5.Text = "Połączenie z bazą danych";
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(panel2);
            panel5.Controls.Add(panel1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(783, 443);
            panel5.TabIndex = 14;
            // 
            // DbConnectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 443);
            Controls.Add(panel5);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(783, 443);
            MinimumSize = new Size(783, 443);
            Name = "DbConnectionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "DbConnectionForm";
            ((System.ComponentModel.ISupportInitialize)connectionCredsBindingSource).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label4;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Button button2;
        private BindingSource connectionCredsBindingSource;
        private Panel panel1;
        private Panel panel2;
        private Label label5;
        private TextBox textBox1;
        private Button button3;
        private Button button1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private PictureBox pictureBox1;
    }
}