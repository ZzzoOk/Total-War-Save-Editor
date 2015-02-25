namespace EsfSaveEditorControls
{
    partial class TraitEditor
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
            this.components = new System.ComponentModel.Container();
            this.numericUpDownExistingItemLevel = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownModifiedItemLevel = new System.Windows.Forms.NumericUpDown();
            this.textBoxModifiedItemPreview = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(234, 123);
            // 
            // numericUpDownExistingItemLevel
            // 
            this.numericUpDownExistingItemLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownExistingItemLevel.BackColor = System.Drawing.SystemColors.Control;
            this.numericUpDownExistingItemLevel.DecimalPlaces = 0;
            this.numericUpDownExistingItemLevel.Increment = new decimal(1);
            this.numericUpDownExistingItemLevel.InterceptArrowKeys = true;
            this.numericUpDownExistingItemLevel.Location = new System.Drawing.Point(0, 0);
            this.numericUpDownExistingItemLevel.Maximum = new decimal(16);
            this.numericUpDownExistingItemLevel.Minimum = new decimal(1);
            this.numericUpDownExistingItemLevel.Name = "numericUpDownExistingItemLevel";
            this.numericUpDownExistingItemLevel.ReadOnly = true;
            this.numericUpDownExistingItemLevel.TabIndex = 1;
            this.numericUpDownExistingItemLevel.Text = "1";
            this.numericUpDownExistingItemLevel.ThousandsSeparator = false;
            this.numericUpDownExistingItemLevel.Value = new decimal(1);
            // 
            // numericUpDownModifiedItemLevel
            // 
            this.numericUpDownModifiedItemLevel.ValueChanged += comboBoxAvailableItems_SelectedIndexChanged;
            this.numericUpDownModifiedItemLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownModifiedItemLevel.BackColor = System.Drawing.Color.White;
            this.numericUpDownModifiedItemLevel.DecimalPlaces = 0;
            this.numericUpDownModifiedItemLevel.Increment = new decimal(1);
            this.numericUpDownModifiedItemLevel.InterceptArrowKeys = true;
            this.numericUpDownModifiedItemLevel.Location = new System.Drawing.Point(0, 0);
            this.numericUpDownModifiedItemLevel.Maximum = new decimal(16);
            this.numericUpDownModifiedItemLevel.Minimum = new decimal(1);
            this.numericUpDownModifiedItemLevel.Name = "numericUpDownModifiedItemLevel";
            this.numericUpDownModifiedItemLevel.TabIndex = 3;
            this.numericUpDownModifiedItemLevel.Tag = "rank";
            this.numericUpDownModifiedItemLevel.Text = "1";
            this.numericUpDownModifiedItemLevel.ThousandsSeparator = false;
            this.numericUpDownModifiedItemLevel.Value = new decimal(1);
            // 
            // textBoxModifiedItemPreview
            // 
            this.textBoxModifiedItemPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxModifiedItemPreview.Location = new System.Drawing.Point(0, 0);
            this.textBoxModifiedItemPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxModifiedItemPreview.Name = "textBoxModifiedItemPreview";
            this.textBoxModifiedItemPreview.ReadOnly = true;
            this.textBoxModifiedItemPreview.Size = new System.Drawing.Size(140, 26);
            this.textBoxModifiedItemPreview.TabIndex = 4;
            // 
            // TraitEditor
            // 
            this.Name = "TraitEditor";
            this.Size = new System.Drawing.Size(240, 129);
            this.Tag = "traits";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownExistingItemLevel;
        protected System.Windows.Forms.NumericUpDown numericUpDownModifiedItemLevel;
        private System.Windows.Forms.TextBox textBoxModifiedItemPreview;
    }
}
