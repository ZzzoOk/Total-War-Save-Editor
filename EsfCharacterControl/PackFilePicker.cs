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
    public partial class PackFilePicker : UserControl
    {
        List<string> _newFileList = new List<string>();
        public IList<string> newFileList
        {
            get
            {
                return new System.Collections.ObjectModel.ReadOnlyCollection<string>(_newFileList);
            }
        }
        public PackFilePicker(string dataPath, IList<string> packFileList)
        {
            InitializeComponent();

            var dataFiles = System.IO.Directory.GetFiles(dataPath).Select(x=>System.IO.Path.GetFileName(x));
            userSortableCheckedListBox1.SuspendLayout();
            userSortableCheckedListBox1.Items.AddRange(dataFiles.ToArray());
            for (int i = 0; i < userSortableCheckedListBox1.Items.Count; ++i)
            {
                if (packFileList.Contains(userSortableCheckedListBox1.Items[i].ToString()))
                    userSortableCheckedListBox1.SetItemChecked(i, true);
            }
            userSortableCheckedListBox1.ResumeLayout();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            _newFileList.AddRange(userSortableCheckedListBox1.CheckedItems.Cast<string>());
        }
    }
}
