namespace WorkflowManager.App.Forms.Base
{
    partial class AppOkDialogForm
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
            label1 = new Label();
            button3 = new Button();
            panel2 = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(438, 76);
            label1.TabIndex = 4;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom;
            button3.BackColor = Color.White;
            button3.FlatAppearance.BorderColor = SystemColors.ControlDark;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(172, 117);
            button3.Name = "button3";
            button3.Size = new Size(123, 39);
            button3.TabIndex = 5;
            button3.Text = "OK";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Location = new Point(13, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(438, 76);
            panel2.TabIndex = 6;
            // 
            // AppOkDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 168);
            Controls.Add(panel2);
            Controls.Add(button3);
            MinimumSize = new Size(0, 0);
            Name = "AppOkDialogForm";
            Opacity = 1D;
            Text = "ErrorMessageDialogForm";
            Controls.SetChildIndex(button3, 0);
            Controls.SetChildIndex(panel2, 0);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button3;
        private Panel panel2;
    }
}