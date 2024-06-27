namespace WorkflowManager.App.Forms
{
    partial class CreateUserWorkflowForm
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
            comboBox1 = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 52);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(311, 23);
            comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderColor = SystemColors.ControlDark;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(95, 90);
            button1.Name = "button1";
            button1.Size = new Size(150, 42);
            button1.TabIndex = 1;
            button1.Text = "Zatwierdź";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // CreateUserWorkflowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 150);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            MinimumSize = new Size(250, 150);
            Name = "CreateUserWorkflowForm";
            Opacity = 1D;
            Text = "Utwórz nowy przepływ";
            Controls.SetChildIndex(comboBox1, 0);
            Controls.SetChildIndex(button1, 0);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private Button button1;
    }
}