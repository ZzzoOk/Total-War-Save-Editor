namespace EsfSaveEditorControls
{
    public partial class EsfTabPageArmy
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
        void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.SuspendLayout();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3.SuspendLayout();
            this.textBoxSkillPoints = new Rankep.NumericTextBox.NumericTextBox(this.components);
            this.textBoxEXP = new Rankep.NumericTextBox.NumericTextBox(this.components);
            this.textBoxLevel = new Rankep.NumericTextBox.NumericTextBox(this.components);
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4.SuspendLayout();
            this.labelSkillPoints = new System.Windows.Forms.Label();
            this.labelEXP = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.skillEditor1 = new EsfSaveEditorControls.SkillEditor();
            this.armyUnitEditor1 = new EsfSaveEditorControls.ArmyUnitEditor();
            // 
            // tableLayoutPanel3
            //
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.textBoxSkillPoints, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxEXP, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxLevel, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelSkillPoints, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelEXP, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelLevel, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(471, 1);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.skillEditor1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.armyUnitEditor1, 0, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(471, 1);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // textBoxSkillPoints
            // 
            this.textBoxSkillPoints.AutoValidate = true;
            this.textBoxSkillPoints.AutoValidationTime = 5000;
            this.textBoxSkillPoints.BackColor = System.Drawing.Color.White;
            this.textBoxSkillPoints.DecimalPlaces = 0;
            this.textBoxSkillPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSkillPoints.EnableErrorValue = false;
            this.textBoxSkillPoints.EnableWarningValue = false;
            this.textBoxSkillPoints.ErrorColor = System.Drawing.Color.OrangeRed;
            this.textBoxSkillPoints.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxSkillPoints.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textBoxSkillPoints.InterceptArrowKeys = true;
            this.textBoxSkillPoints.Location = new System.Drawing.Point(4, 26);
            this.textBoxSkillPoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxSkillPoints.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.textBoxSkillPoints.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxSkillPoints.Name = "textBoxSkillPoints";
            this.textBoxSkillPoints.Size = new System.Drawing.Size(109, 26);
            this.textBoxSkillPoints.TabIndex = 0;
            this.textBoxSkillPoints.Tag = GameInfo.save_item_skill_point;
            this.textBoxSkillPoints.Text = "0";
            this.textBoxSkillPoints.ThousandsSeparator = false;
            this.textBoxSkillPoints.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxSkillPoints.WarningColor = System.Drawing.Color.Gold;
            this.textBoxSkillPoints.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // textBoxEXP
            // 
            this.textBoxEXP.AutoValidate = true;
            this.textBoxEXP.AutoValidationTime = 5000;
            this.textBoxEXP.BackColor = System.Drawing.Color.White;
            this.textBoxEXP.DecimalPlaces = 0;
            this.textBoxEXP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEXP.EnableErrorValue = false;
            this.textBoxEXP.EnableWarningValue = false;
            this.textBoxEXP.ErrorColor = System.Drawing.Color.OrangeRed;
            this.textBoxEXP.ErrorValue = new decimal(new int[] {0,0,0,0});
            this.textBoxEXP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textBoxEXP.InterceptArrowKeys = true;
            this.textBoxEXP.Location = new System.Drawing.Point(121, 26);
            this.textBoxEXP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxEXP.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.textBoxEXP.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxEXP.Name = "textBoxEXP";
            this.textBoxEXP.Size = new System.Drawing.Size(109, 26);
            this.textBoxEXP.TabIndex = 1;
            this.textBoxEXP.Tag = "exp";
            this.textBoxEXP.Text = "0";
            this.textBoxEXP.ThousandsSeparator = false;
            this.textBoxEXP.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxEXP.WarningColor = System.Drawing.Color.Gold;
            this.textBoxEXP.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // textBoxLevel
            // 
            this.textBoxLevel.AutoValidate = true;
            this.textBoxLevel.AutoValidationTime = 5000;
            this.textBoxLevel.BackColor = System.Drawing.Color.White;
            this.textBoxLevel.DecimalPlaces = 0;
            this.textBoxLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLevel.EnableErrorValue = false;
            this.textBoxLevel.EnableWarningValue = false;
            this.textBoxLevel.ErrorColor = System.Drawing.Color.OrangeRed;
            this.textBoxLevel.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxLevel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textBoxLevel.InterceptArrowKeys = true;
            this.textBoxLevel.Location = new System.Drawing.Point(238, 26);
            this.textBoxLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxLevel.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.textBoxLevel.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxLevel.Name = "textBoxLevel";
            this.textBoxLevel.Size = new System.Drawing.Size(109, 26);
            this.textBoxLevel.TabIndex = 2;
            this.textBoxLevel.Tag = "level";
            this.textBoxLevel.Text = "0";
            this.textBoxLevel.ThousandsSeparator = false;
            this.textBoxLevel.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxLevel.WarningColor = System.Drawing.Color.Gold;
            this.textBoxLevel.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // labelSkillPoints
            // 
            this.labelSkillPoints.AutoSize = true;
            this.labelSkillPoints.Location = new System.Drawing.Point(238, 0);
            this.labelSkillPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSkillPoints.Name = "labelSkillPoints";
            this.labelSkillPoints.Size = new System.Drawing.Size(89, 20);
            this.labelSkillPoints.TabIndex = 3;
            this.labelSkillPoints.Text = "Skill Points:";
            // 
            // labelEXP
            // 
            this.labelEXP.AutoSize = true;
            this.labelEXP.Location = new System.Drawing.Point(121, 0);
            this.labelEXP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEXP.Name = "labelEXP";
            this.labelEXP.Size = new System.Drawing.Size(40, 20);
            this.labelEXP.TabIndex = 2;
            this.labelEXP.Text = "Exp:";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(4, 0);
            this.labelLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(50, 20);
            this.labelLevel.TabIndex = 1;
            this.labelLevel.Text = "Level:";
            // 
            // skillEditor1
            // 
            this.skillEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skillEditor1.Location = new System.Drawing.Point(3, 104);
            this.skillEditor1.Name = "skillEditor1";
            this.skillEditor1.Size = new System.Drawing.Size(471, 115);
            this.skillEditor1.TabIndex = 3;
            // 
            // armyUnitEditor1
            // 
            this.armyUnitEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.armyUnitEditor1.Location = new System.Drawing.Point(3, 222);
            this.armyUnitEditor1.Name = "armyUnitEditor1";
            this.armyUnitEditor1.Size = new System.Drawing.Size(471, 115);
            this.armyUnitEditor1.TabIndex = 4;
            // 
            // EsfTabPageArmy
            // 
            this.Tag = "armies";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Rankep.NumericTextBox.NumericTextBox textBoxSkillPoints;
        private Rankep.NumericTextBox.NumericTextBox textBoxEXP;
        private Rankep.NumericTextBox.NumericTextBox textBoxLevel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelSkillPoints;
        private System.Windows.Forms.Label labelEXP;
        private System.Windows.Forms.Label labelLevel;
        private SkillEditor skillEditor1;
        ArmyUnitEditor armyUnitEditor1;
    }
}
