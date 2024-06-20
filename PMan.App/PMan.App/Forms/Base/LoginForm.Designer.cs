using StorageManager.App.Database;

namespace StorageManager.App
{
    partial class LoginForm
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
            panel2 = new Panel();
            panel3 = new Panel();
            button6 = new Button();
            button7 = new Button();
            label5 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            textBox2 = new TextBox();
            checkBox2 = new CheckBox();
            label2 = new Label();
            button1 = new Button();
            label4 = new Label();
            textBox4 = new TextBox();
            panel4 = new Panel();
            button3 = new Button();
            button2 = new Button();
            sqlConnection1 = new Microsoft.Data.SqlClient.SqlConnection();
            panel5 = new Panel();
            button4 = new Button();
            button5 = new Button();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(41, 128, 185);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 626);
            panel2.TabIndex = 13;
            panel2.Paint += panel2_Paint;
            panel2.MouseDown += panel2_MouseDown;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(button6);
            panel3.Controls.Add(button7);
            panel3.Location = new Point(3, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(297, 40);
            panel3.TabIndex = 16;
            panel3.MouseDown += panel3_MouseDown_1;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.FromArgb(41, 128, 185);
            button6.Location = new Point(713, 0);
            button6.Name = "button6";
            button6.Size = new Size(40, 40);
            button6.TabIndex = 14;
            button6.Text = "_";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.FromArgb(41, 128, 185);
            button7.Location = new Point(759, 0);
            button7.Name = "button7";
            button7.Size = new Size(40, 40);
            button7.TabIndex = 13;
            button7.Text = "X";
            button7.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(63, 295);
            label5.Name = "label5";
            label5.Size = new Size(189, 30);
            label5.TabIndex = 2;
            label5.Text = "Workflow Manager";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(63, 257);
            label1.Name = "label1";
            label1.Size = new Size(183, 30);
            label1.TabIndex = 1;
            label1.Text = "Witaj w programie";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = WorkflowManager.App.Properties.Resources.user_solid;
            pictureBox1.Location = new Point(87, 91);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(132, 141);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(317, 601);
            label3.Name = "label3";
            label3.Size = new Size(126, 17);
            label3.TabIndex = 2;
            label3.Text = "Workflow manager";
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(300, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(556, 626);
            panel1.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(41, 128, 185);
            label6.Location = new Point(43, 130);
            label6.Name = "label6";
            label6.Size = new Size(113, 30);
            label6.TabIndex = 3;
            label6.Text = "Zaloguj się";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(101, 178);
            textBox2.MinimumSize = new Size(152, 23);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(413, 29);
            textBox2.TabIndex = 0;
            textBox2.KeyDown += textBox2_KeyDown;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 12F);
            checkBox2.Location = new Point(101, 270);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(145, 25);
            checkBox2.TabIndex = 12;
            checkBox2.Text = "Zapamiętaj mnie";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(43, 181);
            label2.Name = "label2";
            label2.Size = new Size(52, 21);
            label2.TabIndex = 1;
            label2.Text = "Login:";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(101, 301);
            button1.Name = "button1";
            button1.Size = new Size(152, 36);
            button1.TabIndex = 11;
            button1.Text = "Zaloguj się";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            button1.KeyDown += button1_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(43, 227);
            label4.Name = "label4";
            label4.Size = new Size(52, 21);
            label4.TabIndex = 4;
            label4.Text = "Hasło:";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 12F);
            textBox4.Location = new Point(101, 224);
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '*';
            textBox4.Size = new Size(413, 29);
            textBox4.TabIndex = 5;
            textBox4.KeyDown += textBox4_KeyDown;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.Controls.Add(button3);
            panel4.Controls.Add(button2);
            panel4.Location = new Point(300, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(701, 40);
            panel4.TabIndex = 15;
            panel4.MouseDown += panel4_MouseDown;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(41, 128, 185);
            button3.Location = new Point(474, -1);
            button3.Name = "button3";
            button3.Size = new Size(40, 40);
            button3.TabIndex = 14;
            button3.Text = "_";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(41, 128, 185);
            button2.Location = new Point(517, 0);
            button2.Name = "button2";
            button2.Size = new Size(40, 40);
            button2.TabIndex = 13;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // sqlConnection1
            // 
            sqlConnection1.AccessTokenCallback = null;
            sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(panel4);
            panel5.Controls.Add(panel1);
            panel5.Controls.Add(panel2);
            panel5.Controls.Add(button4);
            panel5.Controls.Add(button5);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(858, 628);
            panel5.TabIndex = 16;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.FromArgb(41, 128, 185);
            button4.Location = new Point(1275, 0);
            button4.Name = "button4";
            button4.Size = new Size(40, 40);
            button4.TabIndex = 14;
            button4.Text = "_";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.FromArgb(41, 128, 185);
            button5.Location = new Point(1321, 0);
            button5.Name = "button5";
            button5.Size = new Size(40, 40);
            button5.TabIndex = 13;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 628);
            ControlBox = false;
            Controls.Add(panel5);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(441, 317);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zaloguj się";
            Load += LoginForm_Load;
            KeyDown += LoginForm_KeyDown;
            MouseDown += LoginForm_MouseDown;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel panel1;
        private TextBox textBox2;
        private CheckBox checkBox2;
        private Label label2;
        private Button button1;
        private Label label4;
        private TextBox textBox4;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label1;
        private Label label5;
        private Button button2;
        private Label label6;
        private Microsoft.Data.SqlClient.SqlConnection sqlConnection1;
        private Panel panel4;
        private Button button3;
        private Panel panel5;
        private Button button4;
        private Button button5;
        private Panel panel3;
        private Button button6;
        private Button button7;
    }
}