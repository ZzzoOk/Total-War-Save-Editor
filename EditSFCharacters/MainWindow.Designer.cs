namespace EditSFCharacters {
    partial class EditSFCharacters {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rome2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseDatapackToLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseLocDatabaseToLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runSingleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runTestsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(624, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Enabled = false;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(158, 30);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(158, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(158, 30);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.chooseDatapackToLoadToolStripMenuItem,
            this.chooseLocDatabaseToLoadToolStripMenuItem,
            this.writeLogFileToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rome2ToolStripMenuItem,
            this.attilaToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(311, 30);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // rome2ToolStripMenuItem
            // 
            this.rome2ToolStripMenuItem.Name = "rome2ToolStripMenuItem";
            this.rome2ToolStripMenuItem.Size = new System.Drawing.Size(198, 30);
            this.rome2ToolStripMenuItem.Tag = "R2TW";
            this.rome2ToolStripMenuItem.Text = "Rome 2";
            this.rome2ToolStripMenuItem.Click += new System.EventHandler(this.rome2ToolStripMenuItem_Click);
            // 
            // attilaToolStripMenuItem
            // 
            this.attilaToolStripMenuItem.Name = "attilaToolStripMenuItem";
            this.attilaToolStripMenuItem.Size = new System.Drawing.Size(198, 30);
            this.attilaToolStripMenuItem.Tag = "ATW";
            this.attilaToolStripMenuItem.Text = "Attila";
            this.attilaToolStripMenuItem.Click += new System.EventHandler(this.rome2ToolStripMenuItem_Click);
            // 
            // chooseDatapackToLoadToolStripMenuItem
            // 
            this.chooseDatapackToLoadToolStripMenuItem.Enabled = false;
            this.chooseDatapackToLoadToolStripMenuItem.Name = "chooseDatapackToLoadToolStripMenuItem";
            this.chooseDatapackToLoadToolStripMenuItem.Size = new System.Drawing.Size(311, 30);
            this.chooseDatapackToLoadToolStripMenuItem.Text = "Choose data packs to load";
            this.chooseDatapackToLoadToolStripMenuItem.Click += new System.EventHandler(this.chooseDatapackToLoadToolStripMenuItem_Click);
            // 
            // chooseLocDatabaseToLoadToolStripMenuItem
            // 
            this.chooseLocDatabaseToLoadToolStripMenuItem.Enabled = false;
            this.chooseLocDatabaseToLoadToolStripMenuItem.Name = "chooseLocDatabaseToLoadToolStripMenuItem";
            this.chooseLocDatabaseToLoadToolStripMenuItem.Size = new System.Drawing.Size(311, 30);
            this.chooseLocDatabaseToLoadToolStripMenuItem.Text = "Choose loc database to load";
            this.chooseLocDatabaseToLoadToolStripMenuItem.Click += new System.EventHandler(this.chooseLocDatabaseToLoadToolStripMenuItem_Click);
            // 
            // writeLogFileToolStripMenuItem
            // 
            this.writeLogFileToolStripMenuItem.CheckOnClick = true;
            this.writeLogFileToolStripMenuItem.Name = "writeLogFileToolStripMenuItem";
            this.writeLogFileToolStripMenuItem.Size = new System.Drawing.Size(311, 30);
            this.writeLogFileToolStripMenuItem.Text = "Write Log File";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runSingleTestToolStripMenuItem,
            this.runTestsStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.testToolStripMenuItem.Text = "Tests";
            this.testToolStripMenuItem.Visible = false;
            // 
            // runSingleTestToolStripMenuItem
            // 
            this.runSingleTestToolStripMenuItem.Name = "runSingleTestToolStripMenuItem";
            this.runSingleTestToolStripMenuItem.Size = new System.Drawing.Size(240, 30);
            this.runSingleTestToolStripMenuItem.Text = "Run Load/Save Test";
            this.runSingleTestToolStripMenuItem.Click += new System.EventHandler(this.runSingleTestToolStripMenuItem_Click);
            // 
            // runTestsStripMenuItem
            // 
            this.runTestsStripMenuItem.Name = "runTestsStripMenuItem";
            this.runTestsStripMenuItem.Size = new System.Drawing.Size(240, 30);
            this.runTestsStripMenuItem.Text = "Multiple Tests";
            this.runTestsStripMenuItem.Click += new System.EventHandler(this.runTestsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(134, 30);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.statusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 389);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusBar.Size = new System.Drawing.Size(624, 31);
            this.statusBar.TabIndex = 2;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(150, 25);
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(131, 26);
            this.statusLabel.Text = "No File Loaded";
            // 
            // EditSFCharacters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(624, 420);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EditSFCharacters";
            this.Text = "Rome2 Save Editor";
            this.Shown += new System.EventHandler(this.EditSFCharacters_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runTestsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runSingleTestToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseDatapackToLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseLocDatabaseToLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rome2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attilaToolStripMenuItem;
    }
}

