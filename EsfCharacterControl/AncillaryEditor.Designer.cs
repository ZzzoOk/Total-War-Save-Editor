namespace EsfSaveEditorControls
{
    public partial class AncillaryEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxExistingItems = new System.Windows.Forms.ComboBox();
            this.comboBoxAvailableItems = new System.Windows.Forms.ComboBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 123);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ancillaries";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxExistingItems, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxAvailableItems, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonRemove, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(188, 76);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(98, 41);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(87, 30);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // comboBoxExistingItems
            // 
            this.comboBoxExistingItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxExistingItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExistingItems.FormattingEnabled = true;
            this.comboBoxExistingItems.Location = new System.Drawing.Point(4, 5);
            this.comboBoxExistingItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxExistingItems.Name = "comboBoxExistingItems";
            this.comboBoxExistingItems.Size = new System.Drawing.Size(87, 28);
            this.comboBoxExistingItems.TabIndex = 0;
            this.comboBoxExistingItems.SelectedIndexChanged += new System.EventHandler(this.comboBoxExistingItems_SelectedIndexChanged);
            // 
            // comboBoxAvailableItems
            // 
            this.comboBoxAvailableItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAvailableItems.DisplayMember = "Value";
            this.comboBoxAvailableItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAvailableItems.FormattingEnabled = true;
            this.comboBoxAvailableItems.Location = new System.Drawing.Point(4, 43);
            this.comboBoxAvailableItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxAvailableItems.Name = "comboBoxAvailableItems";
            this.comboBoxAvailableItems.Size = new System.Drawing.Size(87, 28);
            this.comboBoxAvailableItems.TabIndex = 1;
            this.comboBoxAvailableItems.Tag = "key";
            this.comboBoxAvailableItems.ValueMember = "Value";
            this.comboBoxAvailableItems.SelectedIndexChanged += new System.EventHandler(this.comboBoxAvailableItems_SelectedIndexChanged);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(98, 3);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(87, 30);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            // 
            // AncillaryEditor
            // 
            this.AutoSize = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.groupBox1);
            this.Name = "AncillaryEditor";
            this.Size = new System.Drawing.Size(197, 123);
            this.Tag = "ancillaries";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
            this.AutoSize = false;
        }

        #endregion

        protected System.Windows.Forms.ComboBox comboBoxExistingItems;
        protected System.Windows.Forms.ComboBox comboBoxAvailableItems;
        protected System.Windows.Forms.Button buttonAdd;
        protected System.Windows.Forms.Button buttonRemove;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.ToolTip toolTip1;
    }
}
