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
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoEllipsis = true;
            label1.AutoSize = true;
            label1.Location = new Point(165, 84);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom;
            button3.Location = new Point(165, 143);
            button3.Name = "button3";
            button3.Size = new Size(123, 39);
            button3.TabIndex = 5;
            button3.Text = "OK";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ErrorMessageDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 194);
            Controls.Add(button3);
            Controls.Add(label1);
            MinimumSize = new Size(463, 194);
            Name = "ErrorMessageDialogForm";
            Opacity = 1D;
            Text = "ErrorMessageDialogForm";
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(button3, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button3;
    }
}