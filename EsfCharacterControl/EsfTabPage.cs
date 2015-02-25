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
    public partial class EsfTabPage : UserControl, ISaveEditorControl
    {
        protected IList<TextBox> tbs = new List<TextBox>(4);
        protected IList<EsfTabControl.BaseGameItem> bindingList;
        public EsfTabPage()
        {
            InitializeComponent();
            //this.SizeChanged += OnSizeChanged;
        }
        public void InitControl()
        {
            foreach (var control in this.FlattenChildren().OfType<ISaveEditorControl>())
                control.InitControl();
            getEditTextBoxes();
        }
        public virtual void setExisting(EsfTabControl.BaseGameItemCollection baseGameItemCollection)
        {
            if (baseGameItemCollection != null)
            {
                bindingList = baseGameItemCollection.getList();
                addFilter(comboBoxFilter.Text);
            }
            else
            {
                comboBoxItems.DataSource = null;
                clear();
            }
        }
        void getEditTextBoxes()
        {
            if (tbs.Count == 0)
            {
                foreach (var tb in this.FlattenChildren().OfType<TextBox>())
                {
                    if (tb.Tag != null)
                    {
                        this.tbs.Add(tb);
                    }
                }
            }
        }
        public virtual void save()
        {
            if (comboBoxItems.SelectedIndex > -1)
            {
                foreach (var special in this.FlattenChildren().OfType<ISaveEditorControl>())
                    special.save();
                EsfTabControl.BaseGameItem baseGameItem =
                    (comboBoxItems.SelectedItem as EsfTabControl.BaseGameItem);
                Dictionary<string, string> bundle =
                    new Dictionary<string, string>(baseGameItem.bundleSize());
                foreach (var tb in this.tbs)
                    bundle.Add((string)tb.Tag, tb.Text);
                baseGameItem.save(bundle);
            }
        }
        public virtual void reset()
        {
            if (comboBoxItems.SelectedIndex > -1)
            {
                EsfTabControl.BaseGameItem character =
                    (comboBoxItems.SelectedItem as EsfTabControl.BaseGameItem);
                foreach (var tb in this.tbs)
                    tb.Text = character.getValue((string)tb.Tag);
                foreach (var sdc in this.FlattenChildren().OfType<ISaveEditorControl>())
                {
                    sdc.setExisting(GameInfo.getItemCollection(
                        comboBoxItems.SelectedItem, ((Control)sdc).Tag as string));
                    sdc.reset();
                }
            }
            else
                clear();
        }
        public virtual void clear()
        {
            foreach (var tb in this.tbs)
                tb.Text = "";
            foreach (var sdc in this.FlattenChildren().OfType<ISaveEditorControl>())
                sdc.clear();
        }
        public virtual void addFilter(string filter)
        {
            if (bindingList != null){
                var filtered_list = bindingList.Where(x => temp_compare(x)).ToList();
                comboBoxItems.DataSource = filtered_list;
            }
            else
                comboBoxItems.DataSource = null;
        }
        bool temp_compare(EsfTabControl.BaseGameItem x)
        {
            var cclass = x.getValue(GameInfo.save_item_cclass);
            var filter_text = comboBoxFilter.Text.ToLower();
            var result = cclass == filter_text;
            return result;
        }
        public virtual void clearFilter()
        {
        }
        void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            addFilter(comboBoxFilter.Text);
            foreach (var sdc in this.FlattenChildren().OfType<ISaveEditorControl>())
                sdc.addFilter(comboBoxFilter.Text);
            reset();
        }
        void comboBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxItems.SelectedIndex > -1)
                foreach (var sdc in this.FlattenChildren().OfType<ISaveEditorControl>())
                    sdc.setExisting(GameInfo.getItemCollection(
                        comboBoxItems.SelectedItem, ((Control)sdc).Tag as string));
            else
                foreach (var sdc in this.FlattenChildren().OfType<ISaveEditorControl>())
                    sdc.setExisting(null);
            reset();
        }
        void OnSizeChanged(object sender, EventArgs e)
        {/*
            var children = this.FlattenChildren();
            foreach (var child in children)
            {
                child.PerformLayout();
            }*/
        }
    }
}
