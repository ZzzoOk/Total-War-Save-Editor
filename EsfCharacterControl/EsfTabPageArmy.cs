using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsfSaveEditorControls
{
    public partial class EsfTabPageArmy : EsfTabPage
    {
        public EsfTabPageArmy()
            : base()
        {
            InitializeComponent();
            this.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();

            System.Collections.Specialized.StringCollection sc = GameInfo.setting.army_filter;
            comboBoxFilter.Items.AddRange(sc.Cast<string>().ToArray());

            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.ResumeLayout(true);
            this.ResumeLayout(true);
        }
    }
}
