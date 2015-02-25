namespace EsfSaveEditorControls
{
    partial class EsfTabControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCharacter = new System.Windows.Forms.TabPage();
            this.esfControlCharacter1 = new EsfSaveEditorControls.EsfTabPageCharacter();
            this.tabArmy = new System.Windows.Forms.TabPage();
            this.esfTabPageArmy1 = new EsfSaveEditorControls.EsfTabPageArmy();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelGameYear = new System.Windows.Forms.Label();
            this.comboBoxFaction = new System.Windows.Forms.ComboBox();
            this.labelFaction = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.tabCharacter.SuspendLayout();
            this.tabArmy.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabCharacter);
            this.tabControl1.Controls.Add(this.tabArmy);
            this.tabControl1.Location = new System.Drawing.Point(3, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(508, 356);
            this.tabControl1.TabIndex = 1;
            // 
            // tabCharacter
            // 
            this.tabCharacter.Controls.Add(this.esfControlCharacter1);
            this.tabCharacter.Location = new System.Drawing.Point(4, 29);
            this.tabCharacter.Name = "tabCharacter";
            this.tabCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tabCharacter.Size = new System.Drawing.Size(500, 323);
            this.tabCharacter.TabIndex = 0;
            this.tabCharacter.Text = "Character";
            this.tabCharacter.UseVisualStyleBackColor = true;
            // 
            // esfControlCharacter1
            // 
            this.esfControlCharacter1.AutoScroll = true;
            this.esfControlCharacter1.AutoScrollMargin = new System.Drawing.Size(21, 21);
            this.esfControlCharacter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.esfControlCharacter1.Location = new System.Drawing.Point(3, 3);
            this.esfControlCharacter1.Name = "esfControlCharacter1";
            this.esfControlCharacter1.Size = new System.Drawing.Size(494, 317);
            this.esfControlCharacter1.TabIndex = 0;
            this.esfControlCharacter1.Tag = "characters";
            // 
            // tabArmy
            // 
            this.tabArmy.Controls.Add(this.esfTabPageArmy1);
            this.tabArmy.Location = new System.Drawing.Point(4, 29);
            this.tabArmy.Name = "tabArmy";
            this.tabArmy.Padding = new System.Windows.Forms.Padding(3);
            this.tabArmy.Size = new System.Drawing.Size(192, 67);
            this.tabArmy.TabIndex = 1;
            this.tabArmy.Text = "Army";
            this.tabArmy.UseVisualStyleBackColor = true;
            // 
            // esfTabPageArmy1
            // 
            this.esfTabPageArmy1.AutoScroll = true;
            this.esfTabPageArmy1.AutoScrollMargin = new System.Drawing.Size(21, 21);
            this.esfTabPageArmy1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.esfTabPageArmy1.Location = new System.Drawing.Point(3, 3);
            this.esfTabPageArmy1.Name = "esfTabPageArmy1";
            this.esfTabPageArmy1.Size = new System.Drawing.Size(186, 61);
            this.esfTabPageArmy1.TabIndex = 0;
            this.esfTabPageArmy1.Tag = "armies";
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.AutoSize = true;
            this.buttonReset.Location = new System.Drawing.Point(282, 7);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(107, 35);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.AutoSize = true;
            this.buttonSave.Location = new System.Drawing.Point(397, 7);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(107, 35);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Apply";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelGameYear, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonReset, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 405);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(508, 47);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // labelGameYear
            // 
            this.labelGameYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelGameYear.AutoSize = true;
            this.labelGameYear.Location = new System.Drawing.Point(3, 27);
            this.labelGameYear.Name = "labelGameYear";
            this.labelGameYear.Size = new System.Drawing.Size(47, 20);
            this.labelGameYear.TabIndex = 13;
            this.labelGameYear.Text = "Year:";
            // 
            // comboBoxFaction
            // 
            this.comboBoxFaction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFaction.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxFaction.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxFaction.FormattingEnabled = true;
            this.comboBoxFaction.Location = new System.Drawing.Point(75, 3);
            this.comboBoxFaction.Name = "comboBoxFaction";
            this.comboBoxFaction.Size = new System.Drawing.Size(430, 28);
            this.comboBoxFaction.TabIndex = 0;
            this.comboBoxFaction.SelectedIndexChanged += new System.EventHandler(this.comboBoxFaction_SelectedIndexChanged);
            // 
            // labelFaction
            // 
            this.labelFaction.AutoSize = true;
            this.labelFaction.Location = new System.Drawing.Point(3, 0);
            this.labelFaction.Name = "labelFaction";
            this.labelFaction.Size = new System.Drawing.Size(66, 20);
            this.labelFaction.TabIndex = 12;
            this.labelFaction.Text = "Faction:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.labelFaction, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxFaction, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(508, 34);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(514, 455);
            this.tableLayoutPanel3.TabIndex = 15;
            // 
            // EsfTabControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "EsfTabControl";
            this.Size = new System.Drawing.Size(521, 461);
            this.tabControl1.ResumeLayout(false);
            this.tabCharacter.ResumeLayout(false);
            this.tabArmy.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCharacter;
        private System.Windows.Forms.TabPage tabArmy;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxFaction;
        private System.Windows.Forms.Label labelFaction;
        private System.Windows.Forms.Label labelGameYear;
        private EsfTabPageCharacter esfControlCharacter1;
        private EsfTabPageArmy esfTabPageArmy1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
