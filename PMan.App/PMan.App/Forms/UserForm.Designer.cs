namespace StorageManager.App.Forms
{
    partial class UserForm
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
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            userBindingSource = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label4 = new Label();
            checkBox1 = new CheckBox();
            label5 = new Label();
            textBox5 = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(422, 216);
            button1.Name = "button1";
            button1.Size = new Size(115, 33);
            button1.TabIndex = 0;
            button1.Text = "Anuluj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(301, 216);
            button2.Name = "button2";
            button2.Size = new Size(115, 33);
            button2.TabIndex = 1;
            button2.Text = "Zapisz";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", userBindingSource, "FirstName", true));
            textBox1.Location = new Point(121, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(283, 23);
            textBox1.TabIndex = 2;
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(Models.User);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 42);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 3;
            label1.Text = "Imię:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 71);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 5;
            label2.Text = "Drugie imię:";
            // 
            // textBox2
            // 
            textBox2.DataBindings.Add(new Binding("Text", userBindingSource, "MiddleName", true));
            textBox2.Location = new Point(121, 68);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(283, 23);
            textBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 102);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 6;
            label3.Text = "Nazwisko:";
            // 
            // textBox3
            // 
            textBox3.DataBindings.Add(new Binding("Text", userBindingSource, "LastName", true));
            textBox3.Location = new Point(121, 99);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(283, 23);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.DataBindings.Add(new Binding("Text", userBindingSource, "Groups", true));
            textBox4.Location = new Point(121, 125);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(283, 23);
            textBox4.TabIndex = 8;
            textBox4.MouseDown += textBox4_MouseDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 128);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 9;
            label4.Text = "Grupy:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.DataBindings.Add(new Binding("Checked", userBindingSource, "IsAdmin", true));
            checkBox1.Location = new Point(121, 154);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(99, 19);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Administrator";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(77, 13);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 13;
            label5.Text = "Login:";
            // 
            // textBox5
            // 
            textBox5.DataBindings.Add(new Binding("Text", userBindingSource, "Login", true));
            textBox5.Location = new Point(121, 10);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(283, 23);
            textBox5.TabIndex = 12;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // button3
            // 
            button3.Location = new Point(12, 214);
            button3.MaximumSize = new Size(115, 33);
            button3.Name = "button3";
            button3.Size = new Size(115, 33);
            button3.TabIndex = 14;
            button3.Text = "Zmień hasło";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 259);
            Controls.Add(button3);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "UserForm";
            Text = "UserForm";
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label4;
        private CheckBox checkBox1;
        private Label label5;
        private TextBox textBox5;
        private BindingSource userBindingSource;
        private ErrorProvider errorProvider1;
        private Button button3;
    }
}