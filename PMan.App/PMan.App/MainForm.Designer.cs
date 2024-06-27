namespace StorageManager.App
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            sideBarContainerPanel = new Panel();
            administrationSubMenuPanel = new Panel();
            workflowsButton = new Button();
            dictionariesButton = new Button();
            usersButton = new Button();
            administrationSubmenuButton = new Button();
            button4 = new Button();
            myAccountSubMenuPanel = new Panel();
            button3 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            myAccountButton = new Button();
            myWorkflowsSubMenuPanel = new Panel();
            button8 = new Button();
            button2 = new Button();
            button1 = new Button();
            myWorkflowsButton = new Button();
            panel5 = new Panel();
            panel6 = new Panel();
            currentUserLabel = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel4 = new Panel();
            versionLabel = new Label();
            panel3 = new Panel();
            pageTitleLabel = new Label();
            sideBarContainerPanel.SuspendLayout();
            administrationSubMenuPanel.SuspendLayout();
            myAccountSubMenuPanel.SuspendLayout();
            myWorkflowsSubMenuPanel.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // sideBarContainerPanel
            // 
            sideBarContainerPanel.AutoScroll = true;
            sideBarContainerPanel.BackColor = Color.FromArgb(41, 128, 185);
            sideBarContainerPanel.Controls.Add(administrationSubMenuPanel);
            sideBarContainerPanel.Controls.Add(administrationSubmenuButton);
            sideBarContainerPanel.Controls.Add(button4);
            sideBarContainerPanel.Controls.Add(myAccountSubMenuPanel);
            sideBarContainerPanel.Controls.Add(myAccountButton);
            sideBarContainerPanel.Controls.Add(myWorkflowsSubMenuPanel);
            sideBarContainerPanel.Controls.Add(myWorkflowsButton);
            sideBarContainerPanel.Controls.Add(panel5);
            sideBarContainerPanel.Dock = DockStyle.Left;
            sideBarContainerPanel.Location = new Point(0, 0);
            sideBarContainerPanel.Name = "sideBarContainerPanel";
            sideBarContainerPanel.Size = new Size(300, 881);
            sideBarContainerPanel.TabIndex = 2;
            // 
            // administrationSubMenuPanel
            // 
            administrationSubMenuPanel.Controls.Add(workflowsButton);
            administrationSubMenuPanel.Controls.Add(dictionariesButton);
            administrationSubMenuPanel.Controls.Add(usersButton);
            administrationSubMenuPanel.Dock = DockStyle.Top;
            administrationSubMenuPanel.Location = new Point(0, 772);
            administrationSubMenuPanel.Name = "administrationSubMenuPanel";
            administrationSubMenuPanel.Size = new Size(283, 182);
            administrationSubMenuPanel.TabIndex = 13;
            // 
            // workflowsButton
            // 
            workflowsButton.Dock = DockStyle.Top;
            workflowsButton.FlatAppearance.BorderSize = 0;
            workflowsButton.FlatStyle = FlatStyle.Flat;
            workflowsButton.Font = new Font("Segoe UI", 12F);
            workflowsButton.ForeColor = Color.White;
            workflowsButton.Image = (Image)resources.GetObject("workflowsButton.Image");
            workflowsButton.ImageAlign = ContentAlignment.MiddleLeft;
            workflowsButton.Location = new Point(0, 118);
            workflowsButton.Name = "workflowsButton";
            workflowsButton.Padding = new Padding(20, 0, 0, 0);
            workflowsButton.Size = new Size(283, 59);
            workflowsButton.TabIndex = 5;
            workflowsButton.Text = "Szablony przepływów";
            workflowsButton.TextAlign = ContentAlignment.MiddleLeft;
            workflowsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            workflowsButton.UseVisualStyleBackColor = true;
            workflowsButton.Click += workflowsButton_Click;
            // 
            // dictionariesButton
            // 
            dictionariesButton.Dock = DockStyle.Top;
            dictionariesButton.FlatAppearance.BorderSize = 0;
            dictionariesButton.FlatStyle = FlatStyle.Flat;
            dictionariesButton.Font = new Font("Segoe UI", 12F);
            dictionariesButton.ForeColor = Color.White;
            dictionariesButton.Image = (Image)resources.GetObject("dictionariesButton.Image");
            dictionariesButton.ImageAlign = ContentAlignment.MiddleLeft;
            dictionariesButton.Location = new Point(0, 59);
            dictionariesButton.Name = "dictionariesButton";
            dictionariesButton.Padding = new Padding(20, 0, 0, 0);
            dictionariesButton.Size = new Size(283, 59);
            dictionariesButton.TabIndex = 4;
            dictionariesButton.Text = "Słowniki";
            dictionariesButton.TextAlign = ContentAlignment.MiddleLeft;
            dictionariesButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            dictionariesButton.UseVisualStyleBackColor = true;
            dictionariesButton.Click += dictionariesButton_Click;
            // 
            // usersButton
            // 
            usersButton.Dock = DockStyle.Top;
            usersButton.FlatAppearance.BorderSize = 0;
            usersButton.FlatStyle = FlatStyle.Flat;
            usersButton.Font = new Font("Segoe UI", 12F);
            usersButton.ForeColor = Color.White;
            usersButton.Image = (Image)resources.GetObject("usersButton.Image");
            usersButton.ImageAlign = ContentAlignment.MiddleLeft;
            usersButton.Location = new Point(0, 0);
            usersButton.Name = "usersButton";
            usersButton.Padding = new Padding(20, 0, 0, 0);
            usersButton.Size = new Size(283, 59);
            usersButton.TabIndex = 3;
            usersButton.Text = "Użytkownicy";
            usersButton.TextAlign = ContentAlignment.MiddleLeft;
            usersButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            usersButton.UseVisualStyleBackColor = true;
            usersButton.Click += usersButton_Click;
            // 
            // administrationSubmenuButton
            // 
            administrationSubmenuButton.Dock = DockStyle.Top;
            administrationSubmenuButton.FlatAppearance.BorderSize = 0;
            administrationSubmenuButton.FlatStyle = FlatStyle.Flat;
            administrationSubmenuButton.Font = new Font("Segoe UI", 12F);
            administrationSubmenuButton.ForeColor = Color.White;
            administrationSubmenuButton.Image = (Image)resources.GetObject("administrationSubmenuButton.Image");
            administrationSubmenuButton.ImageAlign = ContentAlignment.MiddleLeft;
            administrationSubmenuButton.Location = new Point(0, 713);
            administrationSubmenuButton.Name = "administrationSubmenuButton";
            administrationSubmenuButton.Size = new Size(283, 59);
            administrationSubmenuButton.TabIndex = 12;
            administrationSubmenuButton.Text = "Administracja";
            administrationSubmenuButton.TextAlign = ContentAlignment.MiddleLeft;
            administrationSubmenuButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            administrationSubmenuButton.UseVisualStyleBackColor = true;
            administrationSubmenuButton.Click += administrationSubmenuButton_Click;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Bottom;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F);
            button4.ForeColor = Color.White;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(0, 954);
            button4.Name = "button4";
            button4.Size = new Size(283, 59);
            button4.TabIndex = 4;
            button4.Text = "Wyjdź";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // myAccountSubMenuPanel
            // 
            myAccountSubMenuPanel.Controls.Add(button3);
            myAccountSubMenuPanel.Controls.Add(button7);
            myAccountSubMenuPanel.Controls.Add(button6);
            myAccountSubMenuPanel.Controls.Add(button5);
            myAccountSubMenuPanel.Dock = DockStyle.Top;
            myAccountSubMenuPanel.Location = new Point(0, 478);
            myAccountSubMenuPanel.Name = "myAccountSubMenuPanel";
            myAccountSubMenuPanel.Size = new Size(283, 235);
            myAccountSubMenuPanel.TabIndex = 8;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Bottom;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F);
            button3.ForeColor = Color.White;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(0, 176);
            button3.Name = "button3";
            button3.Padding = new Padding(20, 0, 0, 0);
            button3.Size = new Size(283, 59);
            button3.TabIndex = 8;
            button3.Text = "Połączenie z bazą danych";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_2;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Top;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 12F);
            button7.ForeColor = Color.White;
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(0, 118);
            button7.Name = "button7";
            button7.Padding = new Padding(20, 0, 0, 0);
            button7.Size = new Size(283, 59);
            button7.TabIndex = 4;
            button7.Text = "Zmień użytkownika";
            button7.TextAlign = ContentAlignment.MiddleLeft;
            button7.TextImageRelation = TextImageRelation.ImageBeforeText;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Top;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 12F);
            button6.ForeColor = Color.White;
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(0, 59);
            button6.Name = "button6";
            button6.Padding = new Padding(20, 0, 0, 0);
            button6.Size = new Size(283, 59);
            button6.TabIndex = 3;
            button6.Text = "Zmień hasło";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.TextImageRelation = TextImageRelation.ImageBeforeText;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Top;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 12F);
            button5.ForeColor = Color.White;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(0, 0);
            button5.Name = "button5";
            button5.Padding = new Padding(20, 0, 0, 0);
            button5.Size = new Size(283, 59);
            button5.TabIndex = 2;
            button5.Text = "Szczegóły";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // myAccountButton
            // 
            myAccountButton.Dock = DockStyle.Top;
            myAccountButton.FlatAppearance.BorderSize = 0;
            myAccountButton.FlatStyle = FlatStyle.Flat;
            myAccountButton.Font = new Font("Segoe UI", 12F);
            myAccountButton.ForeColor = Color.White;
            myAccountButton.Image = (Image)resources.GetObject("myAccountButton.Image");
            myAccountButton.ImageAlign = ContentAlignment.MiddleLeft;
            myAccountButton.Location = new Point(0, 419);
            myAccountButton.Name = "myAccountButton";
            myAccountButton.Size = new Size(283, 59);
            myAccountButton.TabIndex = 7;
            myAccountButton.Text = "Moje konto";
            myAccountButton.TextAlign = ContentAlignment.MiddleLeft;
            myAccountButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            myAccountButton.UseVisualStyleBackColor = true;
            myAccountButton.Click += myAccountButton_Click_1;
            // 
            // myWorkflowsSubMenuPanel
            // 
            myWorkflowsSubMenuPanel.Controls.Add(button8);
            myWorkflowsSubMenuPanel.Controls.Add(button2);
            myWorkflowsSubMenuPanel.Controls.Add(button1);
            myWorkflowsSubMenuPanel.Dock = DockStyle.Top;
            myWorkflowsSubMenuPanel.Location = new Point(0, 237);
            myWorkflowsSubMenuPanel.Name = "myWorkflowsSubMenuPanel";
            myWorkflowsSubMenuPanel.Size = new Size(283, 182);
            myWorkflowsSubMenuPanel.TabIndex = 6;
            // 
            // button8
            // 
            button8.Dock = DockStyle.Top;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI", 12F);
            button8.ForeColor = Color.White;
            button8.Image = WorkflowManager.App.Properties.Resources.Document_Check;
            button8.ImageAlign = ContentAlignment.MiddleLeft;
            button8.Location = new Point(0, 118);
            button8.Name = "button8";
            button8.Padding = new Padding(20, 0, 0, 0);
            button8.Size = new Size(283, 59);
            button8.TabIndex = 3;
            button8.Text = "Dodaj nowy";
            button8.TextAlign = ContentAlignment.MiddleLeft;
            button8.TextImageRelation = TextImageRelation.ImageBeforeText;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F);
            button2.ForeColor = Color.White;
            button2.Image = WorkflowManager.App.Properties.Resources.Document_ZoomOut_WF;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 59);
            button2.Name = "button2";
            button2.Padding = new Padding(20, 0, 0, 0);
            button2.Size = new Size(283, 59);
            button2.TabIndex = 2;
            button2.Text = "Do obsłużenia";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = Color.White;
            button1.Image = WorkflowManager.App.Properties.Resources.Document_Check;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Padding = new Padding(20, 0, 0, 0);
            button1.Size = new Size(283, 59);
            button1.TabIndex = 1;
            button1.Text = "Utworzone przeze mnie";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // myWorkflowsButton
            // 
            myWorkflowsButton.Dock = DockStyle.Top;
            myWorkflowsButton.FlatAppearance.BorderSize = 0;
            myWorkflowsButton.FlatStyle = FlatStyle.Flat;
            myWorkflowsButton.Font = new Font("Segoe UI", 12F);
            myWorkflowsButton.ForeColor = Color.White;
            myWorkflowsButton.Image = WorkflowManager.App.Properties.Resources.Document_Check;
            myWorkflowsButton.ImageAlign = ContentAlignment.MiddleLeft;
            myWorkflowsButton.Location = new Point(0, 178);
            myWorkflowsButton.Name = "myWorkflowsButton";
            myWorkflowsButton.Size = new Size(283, 59);
            myWorkflowsButton.TabIndex = 5;
            myWorkflowsButton.Text = "Moje przepływy";
            myWorkflowsButton.TextAlign = ContentAlignment.MiddleLeft;
            myWorkflowsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            myWorkflowsButton.UseVisualStyleBackColor = true;
            myWorkflowsButton.Click += myWorkflowsButton_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(36, 113, 163);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(pictureBox1);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(283, 178);
            panel5.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(currentUserLabel);
            panel6.Dock = DockStyle.Bottom;
            panel6.ForeColor = Color.White;
            panel6.Location = new Point(0, 126);
            panel6.Name = "panel6";
            panel6.Size = new Size(283, 52);
            panel6.TabIndex = 1;
            // 
            // currentUserLabel
            // 
            currentUserLabel.Dock = DockStyle.Fill;
            currentUserLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentUserLabel.Location = new Point(0, 0);
            currentUserLabel.Name = "currentUserLabel";
            currentUserLabel.Size = new Size(283, 52);
            currentUserLabel.TabIndex = 0;
            currentUserLabel.Text = "USER";
            currentUserLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(71, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(138, 161);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Location = new Point(300, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(789, 799);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(versionLabel);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(300, 848);
            panel4.Name = "panel4";
            panel4.Size = new Size(801, 33);
            panel4.TabIndex = 0;
            // 
            // versionLabel
            // 
            versionLabel.Anchor = AnchorStyles.Right;
            versionLabel.AutoSize = true;
            versionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            versionLabel.Location = new Point(567, 9);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(194, 15);
            versionLabel.TabIndex = 0;
            versionLabel.Text = "Workflow manager - Wersja 1.0.0";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gainsboro;
            panel3.Controls.Add(pageTitleLabel);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(300, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(801, 44);
            panel3.TabIndex = 3;
            // 
            // pageTitleLabel
            // 
            pageTitleLabel.AutoSize = true;
            pageTitleLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pageTitleLabel.ForeColor = Color.DimGray;
            pageTitleLabel.Location = new Point(8, 9);
            pageTitleLabel.Name = "pageTitleLabel";
            pageTitleLabel.Size = new Size(90, 25);
            pageTitleLabel.TabIndex = 0;
            pageTitleLabel.Text = "Page title";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 881);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(sideBarContainerPanel);
            Name = "MainForm";
            Text = "Workflow manager";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            sideBarContainerPanel.ResumeLayout(false);
            administrationSubMenuPanel.ResumeLayout(false);
            myAccountSubMenuPanel.ResumeLayout(false);
            myWorkflowsSubMenuPanel.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel sideBarContainerPanel;
        private Panel panel2;
        private Panel panel4;
        private Label versionLabel;
        private Label signedInUserLabel;
        private Label label1;
        private Panel panel5;
        private PictureBox pictureBox1;
        private Button button2;
        private Button button4;
        private Panel panel6;
        private Label currentUserLabel;
        private Panel myWorkflowsSubMenuPanel;
        private Button button1;
        private Button myWorkflowsButton;
        private Panel myAccountSubMenuPanel;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button myAccountButton;
        private Button button8;
        private Button button3;
        private Panel panel3;
        private Label pageTitleLabel;
        private Button button11;
        private Button administrationSubmenuButton;
        private Panel administrationSubMenuPanel;
        private Button workflowsButton;
        private Button dictionariesButton;
        private Button usersButton;
    }
}