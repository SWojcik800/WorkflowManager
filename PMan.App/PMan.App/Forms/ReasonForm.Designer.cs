namespace WorkflowManager.App.Forms
{
    partial class ReasonForm
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
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Location = new Point(13, 79);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(312, 306);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 51);
            label1.Name = "label1";
            label1.Size = new Size(224, 15);
            label1.TabIndex = 5;
            label1.Text = "Powód cofnięcia do poprzedniego etapu:";
            // 
            // button3
            // 
            button3.Location = new Point(91, 393);
            button3.Name = "button3";
            button3.Size = new Size(146, 41);
            button3.TabIndex = 6;
            button3.Text = "Zapisz";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ReasonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 446);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            MaximumSize = new Size(344, 446);
            MinimumSize = new Size(344, 446);
            Name = "ReasonForm";
            Opacity = 1D;
            Text = "Powód cofnięcia";
            Controls.SetChildIndex(richTextBox1, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(button3, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Label label1;
        private Button button3;
    }
}