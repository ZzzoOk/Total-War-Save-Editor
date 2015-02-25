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
    public partial class AncillaryEditor : UserControl, ISaveEditorControl
    {
        protected IList<KeyValuePair<string, GameData.GenericGameItem>> bindingList;
        protected IList<string> avaliable_traits_filter_strings = new List<string>(3);
        BindingList<EsfTabControl.BaseGameItem> existingItems;
        public AncillaryEditor()
        {
            InitializeComponent();
        }
        public void InitControl()
        {
            setAvailable();
        }
        public virtual void addFilter(string filter)
        {
            avaliable_traits_filter_strings.Clear();
            filter = filter.ToLower();
            avaliable_traits_filter_strings.Add(filter);
            onFilterChanged();
        }
        public void removeFilter(string filter)
        {
            if (avaliable_traits_filter_strings.Remove(filter))
                onFilterChanged();
        }
        public void clearFilter()
        {
            avaliable_traits_filter_strings.Clear();
            onFilterChanged();
        }
        protected virtual void onFilterChanged()
        {
            comboBoxAvailableItems.DataSource = bindingList;
            comboBoxAvailableItems.DisplayMember = "Key";
        }
        protected virtual void setAvailable()
        {
            setAvailable(GameData.GetInstance().Ancillaries);
        }
        protected void setAvailable(IEnumerable<KeyValuePair<string, GameData.GenericGameItem>> list)
        {
            bindingList = list.OrderBy(x => x.Key).ToList();
            onFilterChanged();
        }
        public void setExisting(EsfTabControl.BaseGameItemCollection baseGameItemCollection)
        {
            existingItems = baseGameItemCollection == null? null: baseGameItemCollection.getList();
            comboBoxExistingItems.DataSource = existingItems;
        }
        protected virtual Dictionary<string, string> getSaveBundle()
        {
            Dictionary<string, string> bundle = new Dictionary<string, string>(){
                { (string)comboBoxAvailableItems.Tag, comboBoxAvailableItems.Text }, 
            };
            return bundle;
        }
        public void save()
        {
            if (comboBoxExistingItems.SelectedIndex > -1)
            {
                ((EsfTabControl.BaseGameItem)comboBoxExistingItems.SelectedItem).save(getSaveBundle());
                if (existingItems != null)
                {
                    existingItems.ResetBindings();
                    comboBoxExistingItems_SelectedIndexChanged(null, null);
                }
            }
        }
        public virtual void clear()
        {
            comboBoxExistingItems.DataSource = null;
        }
        public virtual void reset()
        {
            if (comboBoxExistingItems.SelectedIndex > -1)
            {
                var item = (comboBoxExistingItems.SelectedItem
                    as EsfTabControl.BaseGameItem).getValue(GameInfo.save_item_key);
                comboBoxAvailableItems.SelectedIndex =
                    comboBoxAvailableItems.FindStringExact(item);

            }
            else
                comboBoxAvailableItems.SelectedIndex = 0;
        }
        protected void comboBoxAvailableItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAvailableItems.SelectedIndex > -1)
                onSetSelectedAvailableItem(
                    (comboBoxAvailableItems.SelectedValue as GameData.GenericGameItem));
            else
                onSetSelectedAvailableItem(null);
        }
        void comboBoxExistingItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxExistingItems.SelectedIndex > -1)
                onSetSelectedExistingItem(((EsfTabControl.BaseGameItem)comboBoxExistingItems.SelectedItem));
        }
        protected virtual void onSetSelectedAvailableItem(GameData.GenericGameItem selectedItem)
        {
            toolTip1.SetToolTip(comboBoxAvailableItems,
                selectedItem == null ? "" : selectedItem.description);
        }
        protected virtual void onSetSelectedExistingItem(EsfTabControl.BaseGameItem selectedItem)
        {
            toolTip1.SetToolTip(comboBoxExistingItems,
                selectedItem.getEffectDescription());
            reset();
        }
    }

    public class ArmyUnitEditor : AncillaryEditor
    {
        public ArmyUnitEditor()
            : base()
        {
            this.Tag = "units";
            this.groupBox1.Text = "Units";
        }
        protected override void onFilterChanged()
        {
            if (avaliable_traits_filter_strings.Count == 0)
                comboBoxAvailableItems.DataSource = bindingList;
            else
                comboBoxAvailableItems.DataSource = bindingList.Where(x =>
                    avaliable_traits_filter_strings.All(filter => filter.Contains(
                        (x.Value as GameData.ArmyUnit).isNavy ?
                        "navy" : "army"))).ToList();
            comboBoxAvailableItems.DisplayMember = "Key";
        }
        protected override Dictionary<string, string> getSaveBundle()
        {
            var bundle = base.getSaveBundle(); 
            GameData.ArmyUnit unit = comboBoxAvailableItems.SelectedValue as GameData.ArmyUnit;
            bundle.Add(GameInfo.save_item_size, unit.armySize);
            bundle.Add(GameInfo.save_item_max_size, unit.armySize);
            return bundle;
        }
        protected override void setAvailable()
        {
            setAvailable(GameData.GetInstance().Units);
        }
    }
}
