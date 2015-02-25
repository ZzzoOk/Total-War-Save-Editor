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
    public partial class TraitEditor : AncillaryEditor
    {
        public TraitEditor()
            : base()
        {
            this.InitializeComponent();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Text = "Traits";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();
            this.tableLayoutPanel1.Controls.Clear();
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Controls.Add(this.comboBoxExistingItems, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxAvailableItems, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownExistingItemLevel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownModifiedItemLevel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxModifiedItemPreview, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonRemove, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 3, 1);

            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }
        public override void addFilter(string filter)
        {
            if (filter == "")
            {
                clearFilter();
                return;
            }
            filter = filter.ToLower();
            if (GameInfo.item_characters.Contains(filter))
            {
                string inner_filter = "!agent";
                if (filter == GameInfo.item_characters.First())
                {
                    if (!avaliable_traits_filter_strings.Contains(filter))
                    {
                        avaliable_traits_filter_strings.Add(inner_filter);
                        onFilterChanged();
                    }
                }
                else if (avaliable_traits_filter_strings.Remove(inner_filter))
                {
                    onFilterChanged();
                }
            }
        }
        protected override void onFilterChanged()
        {
            if (avaliable_traits_filter_strings.Count == 0)
                comboBoxAvailableItems.DataSource = bindingList;
            else
                comboBoxAvailableItems.DataSource = bindingList.Where(x =>
                    avaliable_traits_filter_strings.All(filter => filter.Contains('!') ?
                            !x.Key.Contains(filter.Replace("!", "")) : x.Key.Contains(filter))).ToList();
            comboBoxAvailableItems.DisplayMember = "Key";
        }
        protected override void setAvailable()
        {
            setAvailable(GameData.GetInstance().Traits);
        }
        protected override Dictionary<string, string> getSaveBundle(){
            Dictionary<string, string> bundle = base.getSaveBundle();
            bundle.Add((string)this.numericUpDownModifiedItemLevel.Tag, this.numericUpDownModifiedItemLevel.Text);
            return bundle;
        }
        public override void clear()
        {
            base.clear();
            this.numericUpDownExistingItemLevel.Value = 1;
        }
        public override void reset()
        {
            this.numericUpDownModifiedItemLevel.Value = this.numericUpDownExistingItemLevel.Value;
            base.reset();
        }
        protected override void onSetSelectedAvailableItem(GameData.GenericGameItem selectedItem)
        {
            if(selectedItem == null)
            {
                textBoxModifiedItemPreview.Text = "";
                toolTip1.SetToolTip(textBoxModifiedItemPreview, "");
            }
            else
            {
                int rank = (int)this.numericUpDownModifiedItemLevel.Value;
                textBoxModifiedItemPreview.Text = (selectedItem as GameData.RankedGameItem)[rank].name;
                toolTip1.SetToolTip(textBoxModifiedItemPreview, (selectedItem as GameData.RankedGameItem)[rank].description);
            }
        }
        protected override void onSetSelectedExistingItem(EsfTabControl.BaseGameItem selectedItem)
        {
            this.numericUpDownExistingItemLevel.Value = (selectedItem as EsfTabControl.Trait).getRank();
            base.onSetSelectedExistingItem(selectedItem);
        }
    }
    public class SkillEditor : TraitEditor
    {
        public SkillEditor()
            : base()
        {
            groupBox1.Text = "Skills";
            this.Name = "SkillEditor";
            this.Tag = "skills";
            this.numericUpDownModifiedItemLevel.Maximum = 3;
        }
        public override void addFilter(string filter)
        {
            if (filter == "")
            {
                clearFilter();
                return;
            }
            filter = filter.ToLower();
            if (!avaliable_traits_filter_strings.Contains(filter))
            {
                if (GameInfo.item_characters.Contains(filter))
                    foreach (string character in GameInfo.item_characters)
                        avaliable_traits_filter_strings.Remove(character);
                avaliable_traits_filter_strings.Add(filter);
                onFilterChanged();
            }
        }
        protected override void setAvailable()
        {
            setAvailable(GameData.GetInstance().Skills);
        }
        protected override Dictionary<string, string> getSaveBundle() {
            Dictionary<string, string> result = base.getSaveBundle();
            GameData.Skill skill = comboBoxAvailableItems.SelectedValue as GameData.Skill;
            result.Add(GameInfo.save_item_indent, skill.indent);
            result.Add(GameInfo.save_item_tier, skill.tier);
            return result;
        }
        protected override void onSetSelectedExistingItem(EsfTabControl.BaseGameItem selectedItem)
        {
            if (((EsfTabControl.Skill)selectedItem).isBackground())
                addFilter(GameInfo.save_item_background);
            else
                removeFilter(GameInfo.save_item_background);
            base.onSetSelectedExistingItem(selectedItem);
        }
    }
}
