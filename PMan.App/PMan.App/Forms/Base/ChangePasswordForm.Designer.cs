namespace StorageManager.App.Forms.Base
{
    partial class ChangePasswordForm
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
            oldPasswordTextbox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            newPasswordTexbox = new TextBox();
            newPasswordTextboxRepeat = new TextBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // oldPasswordTextbox
            // 
            oldPasswordTextbox.Location = new Point(160, 6);
            oldPasswordTextbox.Name = "oldPasswordTextbox";
            oldPasswordTextbox.PasswordChar = '*';
            oldPasswordTextbox.Size = new Size(167, 23);
            oldPasswordTextbox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 1;
            label1.Text = "Obecne hasło:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 43);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 2;
            label2.Text = "Nowe hasło:";
            // 
            // newPasswordTexbox
            // 
            newPasswordTexbox.Location = new Point(160, 40);
            newPasswordTexbox.Name = "newPasswordTexbox";
            newPasswordTexbox.PasswordChar = '*';
            newPasswordTexbox.Size = new Size(167, 23);
            newPasswordTexbox.TabIndex = 3;
            // 
            // newPasswordTextboxRepeat
            // 
            newPasswordTextboxRepeat.Location = new Point(160, 75);
            newPasswordTextboxRepeat.Name = "newPasswordTextboxRepeat";
            newPasswordTextboxRepeat.PasswordChar = '*';
            newPasswordTextboxRepeat.Size = new Size(167, 23);
            newPasswordTextboxRepeat.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 78);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 4;
            label3.Text = "Powtórz hasło:";
            // 
            // button1
            // 
            button1.Location = new Point(217, 121);
            button1.Name = "button1";
            button1.Size = new Size(110, 35);
            button1.TabIndex = 6;
            button1.Text = "Zapisz zmiany";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(106, 121);
            button2.Name = "button2";
            button2.Size = new Size(105, 35);
            button2.TabIndex = 7;
            button2.Text = "Anuluj";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 181);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(newPasswordTextboxRepeat);
            Controls.Add(label3);
            Controls.Add(newPasswordTexbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(oldPasswordTextbox);
            MaximumSize = new Size(429, 220);
            MinimumSize = new Size(429, 220);
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Zmiana hasła";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox oldPasswordTextbox;
        private Label label1;
        private Label label2;
        private TextBox newPasswordTexbox;
        private TextBox newPasswordTextboxRepeat;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}