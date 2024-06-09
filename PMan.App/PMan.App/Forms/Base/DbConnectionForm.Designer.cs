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
            textBox1 = new TextBox();
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
            ((System.ComponentModel.ISupportInitialize)connectionCredsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", connectionCredsBindingSource, "Server", true));
            textBox1.Location = new Point(150, 58);
            textBox1.MaximumSize = new Size(152, 23);
            textBox1.MinimumSize = new Size(152, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(152, 23);
            textBox1.TabIndex = 0;
            // 
            // connectionCredsBindingSource
            // 
            connectionCredsBindingSource.DataSource = typeof(ConnectionCreds);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 61);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Server:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 116);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 2;
            label2.Text = "Login:";
            // 
            // textBox2
            // 
            textBox2.DataBindings.Add(new Binding("Text", connectionCredsBindingSource, "Login", true));
            textBox2.Location = new Point(150, 116);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(152, 23);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 148);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 4;
            label3.Text = "Hasło:";
            // 
            // textBox3
            // 
            textBox3.DataBindings.Add(new Binding("Text", connectionCredsBindingSource, "Password", true));
            textBox3.Location = new Point(150, 148);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(152, 23);
            textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            textBox4.DataBindings.Add(new Binding("Text", connectionCredsBindingSource, "Database", true));
            textBox4.Location = new Point(150, 87);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(152, 23);
            textBox4.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 90);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 7;
            label4.Text = "Baza danych:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.DataBindings.Add(new Binding("Checked", connectionCredsBindingSource, "IntegratedSecurity", true));
            checkBox1.Location = new Point(150, 177);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(124, 19);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Integrated security";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.DataBindings.Add(new Binding("Checked", connectionCredsBindingSource, "TrustServerCertificate", true));
            checkBox2.Location = new Point(150, 202);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(140, 19);
            checkBox2.TabIndex = 9;
            checkBox2.Text = "Trust server certificate";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(153, 240);
            button2.Name = "button2";
            button2.Size = new Size(137, 26);
            button2.TabIndex = 11;
            button2.Text = "Zaloguj się";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // DbConnectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 278);
            Controls.Add(button2);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            MaximumSize = new Size(441, 317);
            MinimumSize = new Size(441, 317);
            Name = "DbConnectionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "DbConnectionForm";
            ((System.ComponentModel.ISupportInitialize)connectionCredsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
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
    }
}