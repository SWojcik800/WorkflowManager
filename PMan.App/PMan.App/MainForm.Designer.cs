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
            panel1 = new Panel();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            konfiguracjaToolStripMenuItem = new ToolStripMenuItem();
            użytkownicyToolStripMenuItem = new ToolStripMenuItem();
            słownikiToolStripMenuItem = new ToolStripMenuItem();
            szablonyPrzepływówToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            zmieńHasłoToolStripMenuItem = new ToolStripMenuItem();
            szczegółyToolStripMenuItem = new ToolStripMenuItem();
            wylogujToolStripMenuItem = new ToolStripMenuItem();
            wyjdźZProgramuToolStripMenuItem = new ToolStripMenuItem();
            mojePrzepływyToolStripMenuItem = new ToolStripMenuItem();
            dodajNowyToolStripMenuItem = new ToolStripMenuItem();
            utworzonePrzezeMnieToolStripMenuItem = new ToolStripMenuItem();
            doObsłużeniaToolStripMenuItem = new ToolStripMenuItem();
            panel3 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            versionLabel = new Label();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuBar;
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(300, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(766, 29);
            panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, konfiguracjaToolStripMenuItem, toolStripMenuItem2, mojePrzepływyToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(766, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(145, 25);
            toolStripMenuItem1.Text = "Ustawienia bazy danych";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // konfiguracjaToolStripMenuItem
            // 
            konfiguracjaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { użytkownicyToolStripMenuItem, słownikiToolStripMenuItem, szablonyPrzepływówToolStripMenuItem });
            konfiguracjaToolStripMenuItem.Name = "konfiguracjaToolStripMenuItem";
            konfiguracjaToolStripMenuItem.Size = new Size(86, 25);
            konfiguracjaToolStripMenuItem.Text = "Konfiguracja";
            // 
            // użytkownicyToolStripMenuItem
            // 
            użytkownicyToolStripMenuItem.Name = "użytkownicyToolStripMenuItem";
            użytkownicyToolStripMenuItem.Size = new Size(187, 22);
            użytkownicyToolStripMenuItem.Text = "Użytkownicy";
            użytkownicyToolStripMenuItem.Click += użytkownicyToolStripMenuItem_Click;
            // 
            // słownikiToolStripMenuItem
            // 
            słownikiToolStripMenuItem.Name = "słownikiToolStripMenuItem";
            słownikiToolStripMenuItem.Size = new Size(187, 22);
            słownikiToolStripMenuItem.Text = "Słowniki";
            słownikiToolStripMenuItem.Click += słownikiToolStripMenuItem_Click;
            // 
            // szablonyPrzepływówToolStripMenuItem
            // 
            szablonyPrzepływówToolStripMenuItem.Name = "szablonyPrzepływówToolStripMenuItem";
            szablonyPrzepływówToolStripMenuItem.Size = new Size(187, 22);
            szablonyPrzepływówToolStripMenuItem.Text = "Szablony przepływów";
            szablonyPrzepływówToolStripMenuItem.Click += szablonyPrzepływówToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { zmieńHasłoToolStripMenuItem, szczegółyToolStripMenuItem, wylogujToolStripMenuItem, wyjdźZProgramuToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(80, 25);
            toolStripMenuItem2.Text = "Moje konto";
            // 
            // zmieńHasłoToolStripMenuItem
            // 
            zmieńHasłoToolStripMenuItem.Name = "zmieńHasłoToolStripMenuItem";
            zmieńHasłoToolStripMenuItem.Size = new Size(177, 22);
            zmieńHasłoToolStripMenuItem.Text = "Zmień hasło";
            zmieńHasłoToolStripMenuItem.Click += zmieńHasłoToolStripMenuItem_Click;
            // 
            // szczegółyToolStripMenuItem
            // 
            szczegółyToolStripMenuItem.Name = "szczegółyToolStripMenuItem";
            szczegółyToolStripMenuItem.Size = new Size(177, 22);
            szczegółyToolStripMenuItem.Text = "Szczegóły";
            szczegółyToolStripMenuItem.Click += szczegółyToolStripMenuItem_Click;
            // 
            // wylogujToolStripMenuItem
            // 
            wylogujToolStripMenuItem.Name = "wylogujToolStripMenuItem";
            wylogujToolStripMenuItem.Size = new Size(177, 22);
            wylogujToolStripMenuItem.Text = "Zmień użytkownika";
            wylogujToolStripMenuItem.Click += wylogujToolStripMenuItem_Click;
            // 
            // wyjdźZProgramuToolStripMenuItem
            // 
            wyjdźZProgramuToolStripMenuItem.Name = "wyjdźZProgramuToolStripMenuItem";
            wyjdźZProgramuToolStripMenuItem.Size = new Size(177, 22);
            wyjdźZProgramuToolStripMenuItem.Text = "Wyjdź z programu";
            wyjdźZProgramuToolStripMenuItem.Click += wyjdźZProgramuToolStripMenuItem_Click;
            // 
            // mojePrzepływyToolStripMenuItem
            // 
            mojePrzepływyToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dodajNowyToolStripMenuItem, utworzonePrzezeMnieToolStripMenuItem, doObsłużeniaToolStripMenuItem });
            mojePrzepływyToolStripMenuItem.Name = "mojePrzepływyToolStripMenuItem";
            mojePrzepływyToolStripMenuItem.Size = new Size(102, 25);
            mojePrzepływyToolStripMenuItem.Text = "Moje przepływy";
            // 
            // dodajNowyToolStripMenuItem
            // 
            dodajNowyToolStripMenuItem.Name = "dodajNowyToolStripMenuItem";
            dodajNowyToolStripMenuItem.Size = new Size(197, 22);
            dodajNowyToolStripMenuItem.Text = "Dodaj nowy";
            dodajNowyToolStripMenuItem.Click += dodajNowyToolStripMenuItem_Click;
            // 
            // utworzonePrzezeMnieToolStripMenuItem
            // 
            utworzonePrzezeMnieToolStripMenuItem.Name = "utworzonePrzezeMnieToolStripMenuItem";
            utworzonePrzezeMnieToolStripMenuItem.Size = new Size(197, 22);
            utworzonePrzezeMnieToolStripMenuItem.Text = "Utworzone przeze mnie";
            utworzonePrzezeMnieToolStripMenuItem.Click += utworzonePrzezeMnieToolStripMenuItem_Click;
            // 
            // doObsłużeniaToolStripMenuItem
            // 
            doObsłużeniaToolStripMenuItem.Name = "doObsłużeniaToolStripMenuItem";
            doObsłużeniaToolStripMenuItem.Size = new Size(197, 22);
            doObsłużeniaToolStripMenuItem.Text = "Do obsłużenia";
            doObsłużeniaToolStripMenuItem.Click += doObsłużeniaToolStripMenuItem_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(41, 128, 185);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 556);
            panel3.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Location = new Point(300, 29);
            panel2.Name = "panel2";
            panel2.Size = new Size(766, 495);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(versionLabel);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(300, 523);
            panel4.Name = "panel4";
            panel4.Size = new Size(766, 33);
            panel4.TabIndex = 0;
            // 
            // versionLabel
            // 
            versionLabel.Anchor = AnchorStyles.Right;
            versionLabel.AutoSize = true;
            versionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            versionLabel.Location = new Point(545, 9);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(194, 15);
            versionLabel.TabIndex = 0;
            versionLabel.Text = "Workflow manager - Wersja 1.0.0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 556);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Workflow manager";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem zmieńHasłoToolStripMenuItem;
        private ToolStripMenuItem konfiguracjaToolStripMenuItem;
        private ToolStripMenuItem użytkownicyToolStripMenuItem;
        private ToolStripMenuItem szczegółyToolStripMenuItem;
        private ToolStripMenuItem słownikiToolStripMenuItem;
        private ToolStripMenuItem szablonyPrzepływówToolStripMenuItem;
        private ToolStripMenuItem wylogujToolStripMenuItem;
        private ToolStripMenuItem wyjdźZProgramuToolStripMenuItem;
        private ToolStripMenuItem mojePrzepływyToolStripMenuItem;
        private ToolStripMenuItem dodajNowyToolStripMenuItem;
        private ToolStripMenuItem utworzonePrzezeMnieToolStripMenuItem;
        private ToolStripMenuItem doObsłużeniaToolStripMenuItem;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
        private Label versionLabel;
        private Label signedInUserLabel;
        private Label label1;
    }
}