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
    public partial class EsfTabControl : UserControl, ISaveEditorControl
    {
        #region structures
        public abstract class BaseGameItem
        {
            const bool set = true;
            const bool get = false;
            public int bundleSize() { return getSaveTableSignature().Count(); }
            public EsfLibrary.ParentNode node { get; protected set; }
            public abstract override string ToString();
            public virtual string getEffectDescription()
            {
                return "";
            }
            public BaseGameItem(EsfLibrary.ParentNode node)
            {
                this.node = node;
            }
            public virtual void save(Dictionary<string, string> bundle)
            {
                foreach (var item in bundle)
                {
                    var inputValue = processValue(set, item.Key, item.Value);
                    if (getSaveTableSignature() != null)
                    {
                        var valueNode = getValueNode(getSaveTableSignature()[item.Key]);
                        if (valueNode.ToString() != inputValue)
                            valueNode.FromString(inputValue);
                    }
                }
            }
            public string getValue(string type)
            {
                var path = getSaveTableSignature()[type];
                if (path.ToString().Contains(GameInfo.setting_static_field_string))
                {
                    path = GameInfo.GetSetting((path as string)
                        .Replace(GameInfo.setting_static_field_string, ""));
                }
                var valueNode = getValueNode(path);
                string result = processValue(get, type, valueNode.ToString());
                return result;
            }
            EsfLibrary.EsfNode getValueNode(object path)
            {
                EsfLibrary.EsfNode valueNode;
                if (path is int)
                    valueNode = node.Values[(int)path];
                else if (path is String)
                    valueNode = node.GetNodeByPath((string)path);
                else
                    throw new InvalidCastException("Signature "+path.ToString()+@" is not int/string");

                return valueNode;
            }
            protected abstract Dictionary<string, object> getSaveTableSignature();
            protected virtual string processValue(bool set, string type, string value){
                return value;
            }
        }
        public class BaseGameItemCollection : IEnumerable<BaseGameItem>
        {
            public EsfLibrary.ParentNode node { get; private set; }
            protected readonly BindingList<BaseGameItem> baseGameItems = new BindingList<BaseGameItem>();
            public BaseGameItemCollection(EsfLibrary.ParentNode node)
            {
                this.node = node;
                initialise(null);
            }
            public BaseGameItemCollection(Type type, EsfLibrary.ParentNode node)
            {
                if (!type.IsSubclassOf(typeof(BaseGameItem)))
                    throw new ArgumentException(string.Format("Invalid type {0}", type));
                this.node = node;
                initialise(type);
            }
            public BindingList<BaseGameItem> getList()
            {
                return baseGameItems;
            }
            protected virtual void initialise(Type type)
            {
                if (type != null)
                {
                    foreach (EsfLibrary.ParentNode baseGameItemNode in node.Children)
                    {
                        baseGameItems.Add((BaseGameItem)type.GetConstructor
                            (new[] { typeof(EsfLibrary.ParentNode) }).Invoke(new[] { baseGameItemNode }));
                    }
                }
                else
                    throw new ArgumentNullException();
            }
            public void Add(BaseGameItem baseGameItem)
            {
                baseGameItems.Add(baseGameItem);
            }
            public void Clear()
            {
                baseGameItems.Clear();
            }
            public BaseGameItem this[int index]
            {
                get
                {
                    return baseGameItems[index];
                }
                set
                {
                    throw new NotImplementedException();
                }
            }
            public int Count
            {
                get { return baseGameItems.Count; }
            }
            public IEnumerator<BaseGameItem> GetEnumerator()
            {
                return baseGameItems.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return baseGameItems.GetEnumerator();
            }
        }
        public class Faction : BaseGameItem
        {
            public static readonly int name = 1;
            public Faction(EsfLibrary.ParentNode node) : base(node) {
                try
                {
                    obtainfactioncharacters();
                    obtainfactionarmies();
                }
                catch
                {
                    Console.WriteLine("faction creation fail at " + node.Values[name]);
                }
            }
            public override string ToString()
            {
                return node.Values[name].ToString();
            }
            public BaseGameItemCollection characters { get; set; }
            public BaseGameItemCollection armies { get; set; }
            public void obtainfactioncharacters()
            {
                characters = new Characters((EsfLibrary.ParentNode)node.
                    GetNodeByPath(GameInfo.characterarraypath));
            }
            public void obtainfactionarmies()
            {
                armies = new Armies((EsfLibrary.ParentNode)node.GetNodeByPath(GameInfo.armyarraypath));
            }
            protected override Dictionary<string, object> getSaveTableSignature()
            {
                throw new NotImplementedException();
            }
        }
        public class Character : BaseGameItem
        {
            internal static readonly Dictionary<string, object> characterSignatures = new Dictionary<string, object>(){
                { GameInfo.save_item_age, @"2\0" }, { GameInfo.save_item_cclass, "GameInfo.setting.character_class_path" },
                { GameInfo.save_item_gender, "GameInfo.setting.character_gender" },
                { GameInfo.save_item_background, GameInfo.characterlevelpath + @"\0" },
                { GameInfo.save_item_skill_point, GameInfo.characterlevelpath + @"\5" },
                { GameInfo.save_item_level, GameInfo.characterlevelpath + @"\4" }, 
                { GameInfo.save_item_exp, GameInfo.characterlevelpath + @"\6" }
            };
            public BaseGameItemCollection traits { get; set; }
            public BaseGameItemCollection skills { get; set; }
            public BaseGameItemCollection ancillaries { get; set; }
            public Character(EsfLibrary.ParentNode charnode)
                : base(charnode)
            {
                traits = new BaseGameItemCollection(typeof(Trait),
                    (EsfLibrary.ParentNode)node.GetNodeByPath(GameInfo.charactertraitpath));
                skills = new BaseGameItemCollection(typeof(Skill),
                    (EsfLibrary.ParentNode)node.GetNodeByPath(GameInfo.characterskillpath));
                ancillaries = new Ancillaries(node);
            }
            public override string ToString()
            {
                EsfLibrary.ParentNode characternamenode = (EsfLibrary.ParentNode)node.GetNodeByPath(GameInfo.characternamepath);
                List<string> characternames = new List<string>(4);
                foreach (EsfLibrary.ParentNode characternameblock in characternamenode.Children)
                {
                    EsfLibrary.ParentNode namenode = characternameblock.Children[0];
                    string tempname = namenode.Values[0].ToString();
                    if (tempname != "")
                    {
                        if (GameData.GetInstance().DictionaryCharacterName.ContainsKey(tempname))
                            tempname = GameData.GetInstance().DictionaryCharacterName[tempname];
                        characternames.Add(tempname);
                    }
                }
                return string.Join(" ", characternames);
            }
            protected override Dictionary<string, object> getSaveTableSignature()
            {
                return Character.characterSignatures;
            }
            protected override string processValue(bool set, string type, string value)
            {
                switch (type)
                {
                    case GameInfo.save_item_cclass:
                        if (value == "general")
                            return getValue(GameInfo.save_item_gender).Equals("True") ? value : "wife";
                        break;
                    case GameInfo.save_item_age:
                        if (set)
                            return (gameYear - int.Parse(value)).ToString();
                        else
                            return (gameYear - int.Parse(value)).ToString();
                    default:
                        break;
                }
                return value;
            }
            public override void save(Dictionary<string, string> bundle)
            {
                bundle.Add(GameInfo.save_item_background, getBackgroundSkill());
                base.save(bundle);
            }
            public string getBackgroundSkill()
            {
                foreach(Skill skill in skills)
                    if (skill.isBackground())
                        return skill.getKey();
                return null;
            }
        }
        public class Trait : BaseGameItem
        {
            internal static readonly Dictionary<string, object> traitSignatures = new Dictionary<string, object>(){
                { GameInfo.save_item_key, 0 }, { GameInfo.save_item_rank, 1 }
            };
            public Trait(EsfLibrary.ParentNode node) : base(node) { }

            public virtual int getRank()
            {
                return int.Parse(node.Values[(int)getSaveTableSignature()[GameInfo.save_item_rank]].ToString());
            }
            public string getKey()
            {
                return node.Values[(int)traitSignatures[GameInfo.save_item_key]].ToString();
            }
            protected virtual GameData.GenericGameItem getItem()
            {
                return (GameData.GetInstance().Traits[getKey()] as GameData.Trait)[getRank()];
            }
            public override string getEffectDescription()
            {
                return getItem().description;
            }
            public override string ToString()
            {
                return getItem().name;
            }
            protected override Dictionary<string, object> getSaveTableSignature()
            {
                return Trait.traitSignatures;
            }
        }
        public class Skill : Trait
        {
            static readonly Dictionary<string, object> skillSignatures = new Dictionary<string, object>(){
                { GameInfo.save_item_key, 0 }, { GameInfo.save_item_tier, 1 }, 
                { GameInfo.save_item_indent, 2 }, { GameInfo.save_item_rank, 3 }
            };
            public Skill(EsfLibrary.ParentNode node) : base(node) { }
            protected override GameData.GenericGameItem getItem()
            {
                return getBaseItem()[getRank()];
            }
            protected override Dictionary<string, object> getSaveTableSignature()
            {
                return Skill.skillSignatures;
            }
            GameData.Skill getBaseItem()
            {
                return (GameData.GetInstance().Skills[getKey()] as GameData.Skill);
            }
            public bool isBackground()
            {
                return getBaseItem().background;
            }
        }
        public class Ancillary : BaseGameItem
        {
            public Ancillary(EsfLibrary.ParentNode node) : base(node) { }
            protected virtual GameData.GenericGameItem getItem()
            {
                return GameData.GetInstance().Ancillaries[getKey()];
            }
            public string getKey()
            {
                return getValue(GameInfo.save_item_key);
            }
            public override string ToString()
            {
                return getItem().name;
            }
            public override string getEffectDescription()
            {
                return getItem().description;
            }
            protected override Dictionary<string, object> getSaveTableSignature()
            {
                return Trait.traitSignatures;
            }
        }
        public class Army : BaseGameItem
        {
            static readonly Dictionary<string, object> armySignatures = new Dictionary<string, object>(){
                { GameInfo.save_item_skill_point, GameInfo.armylevelpath + @"\5" },
                { GameInfo.save_item_level, GameInfo.armylevelpath + @"\4" }, 
                { GameInfo.save_item_exp, GameInfo.armylevelpath + @"\6" },
                { GameInfo.save_item_cclass, "GameInfo.setting.army_class" }, 
                { "index", "GameInfo.setting.army_index" }
            };
            public BaseGameItemCollection skills { get; set; }
            public BaseGameItemCollection units { get; set; }
            public Army(EsfLibrary.ParentNode armynode) : base (armynode)
            {
                skills = new BaseGameItemCollection(typeof(Skill),
                    (EsfLibrary.ParentNode)node.Children[0].Children[0].Children[0]);
                units = new BaseGameItemCollection(typeof(Unit),
                    (EsfLibrary.ParentNode)node.Children[1].Children[0]);
            }
            public int getIndex()
            {
                return int.Parse(getValue("index"));
            }
            public override string ToString()
            { 
                string gameid = GameInfo.setting.GetType().ToString();
                switch (gameid)
                {
                    case "EsfSaveEditorControls.R2TW":
                        string campaign_localisation = node.Children[0].Children[1].Values[0].ToString();
                        if (campaign_localisation.Contains("roman"))
                        {
                            string armytype = getValue(GameInfo.save_item_cclass).Equals("army") ? "Legio" : "Classis";
                            string romanindex = GameInfo.ToRoman(getIndex());
                            campaign_localisation = GameData.GetInstance().DictionaryArmyRomanRegion[campaign_localisation];
                            campaign_localisation = String.Format("{0} {1} {2}", armytype, romanindex, campaign_localisation);
                        }
                        return campaign_localisation;
                    default:
                        return node.Children[0].Children[1].Values[1].ToString();
                }
            }
            protected override Dictionary<string, object> getSaveTableSignature()
            {
                return armySignatures;
            }
            protected override string processValue(bool set, string type, string value)
            {
                switch (type)
                {
                    case GameInfo.save_item_cclass:
                        return value.Equals("0") ? "army" : "navy";
                    default:
                        return value;
                }
            }
        }
        public class Unit : Ancillary
        {
            static readonly Dictionary<string, object> armyUnitSignatures = new Dictionary<string, object>(){
                { GameInfo.save_item_key, @"0\0\0" }, { GameInfo.save_item_size, @"0\1" }
                , { GameInfo.save_item_max_size, @"0\2" }, { GameInfo.save_item_max_action, @"0\3" }
                , { GameInfo.save_item_action, @"0\8" }
            };
            public Unit(EsfLibrary.ParentNode node) : base(node) { }
            protected override Dictionary<string, object> getSaveTableSignature()
            {
                return Unit.armyUnitSignatures;
            }
            protected override GameData.GenericGameItem getItem()
            {
                return GameData.GetInstance().Units[getKey()];
            }
        }
        public class Factions : BaseGameItemCollection
        {
            public Factions(EsfLibrary.ParentNode node) : base(node) { }
            protected override void initialise(Type type)
            {
                Parallel.ForEach(node.Children, faction_node_upper =>
                    {
                        EsfLibrary.ParentNode faction_node = faction_node_upper.Children[0];
                        Add(new Faction(faction_node));
                    });
            }
        }
        public class Ancillaries : BaseGameItemCollection
        {
            public Ancillaries(EsfLibrary.ParentNode node) : base(node) { }
            protected override void initialise(Type type)
            {
                var characterancillarynodes = node.Children.Where(x => x.GetName().
                    Equals(GameInfo.characterancillarypath));
                foreach (var ancillarynode in characterancillarynodes)
                {
                    Add(new Ancillary(ancillarynode));
                }
            }
        }
        public class Characters : BaseGameItemCollection
        {
            public Characters(EsfLibrary.ParentNode node) : base(node) { }
            protected override void initialise(Type type)
            {
                Parallel.ForEach(node.Children, (characternode) =>
                {
                    EsfLibrary.ParentNode chardetailsnode = characternode.Children[0].Children[1];
                    string cclass = chardetailsnode.Values[GameInfo.setting.character_class_path].ToString();
                    if (cclass != "colonel")
                    {
                        Add(new Character(chardetailsnode));
                    }
                });
            }
        }
        public class Armies : BaseGameItemCollection
        {
            public Armies(EsfLibrary.ParentNode node) : base(node) { }
            protected override void initialise(Type type)
            {
                Parallel.ForEach(node.Children, (armynode) =>
                {
                    EsfLibrary.ParentNode militaryforce = armynode.Children[0];
                    string cclass = militaryforce.GetNodeByPath((string)GameInfo.setting.army_class).ToString();
                    if (cclass.Equals("0") || cclass.Equals("1"))
                    {
                        Add(new Army(militaryforce));
                    }
                });
            }
        }
        #endregion
        #region properties
        EsfLibrary.ParentNode rootNode;
        public EsfLibrary.ParentNode RootNode
        {
            get
            {
                return rootNode;
            }
            set
            {
                if (value != null)
                {
                    rootNode = value as EsfLibrary.ParentNode;
                    value.Modified = false;

                    clear();
                    if (checksave())
                    {
                        obtainfactions();
                        getYear();
                    }
                }
            }
        }

        static int gameYear;
        Factions factions;
        #endregion
        public EsfTabControl(){
            InitializeComponent();
        }
        #region methods
        public void InitControl()
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
                foreach (var sdc in tabPage.Controls.OfType<ISaveEditorControl>())
                    sdc.InitControl();
        }
        bool checksave(){
            EsfLibrary.ParentNode gamebuildnode = (EsfLibrary.ParentNode)rootNode.GetNodeByPath(GameInfo.gamebuildpath);
            return gamebuildnode.Values[0].ToString().Contains(GameInfo.setting.gameName);
        }
        void getYear()
        {
            string gameYearString = rootNode.GetNodeByPath(GameInfo.gamedatepath).ToString();
            labelGameYear.Text = "Year: " + gameYearString;
            gameYear = int.Parse(gameYearString);
        }
        void obtainfactions()
        {
            EsfLibrary.ParentNode factionarraynode = 
                rootNode.GetNodeByPath(GameInfo.factionarraypath) as EsfLibrary.ParentNode;
            factions = new Factions(factionarraynode);
            this.setExisting(factions);
        }
        public void addFilter(string filter)
        {
            throw new NotImplementedException();
        }
        public void clearFilter()
        {
            throw new NotImplementedException();
        }
        public void setExisting(EsfTabControl.BaseGameItemCollection baseGameItemCollection)
        {
            comboBoxFaction.DataSource = baseGameItemCollection.getList();
        }
        public void save()
        {
            if (comboBoxFaction.SelectedIndex > -1)
                foreach (TabPage tabPage in tabControl1.TabPages)
                    foreach (var sdc in tabPage.Controls.OfType<ISaveEditorControl>())
                        sdc.save();
        }
        public void clear()
        {
            if (comboBoxFaction.SelectedIndex > -1)
            foreach (TabPage tabPage in tabControl1.TabPages)
                foreach (var sdc in tabPage.Controls.OfType<ISaveEditorControl>())
                    sdc.clear();
        }
        public void reset()
        {
            if (comboBoxFaction.SelectedIndex > -1)
                foreach (TabPage tabPage in tabControl1.TabPages)
                    foreach (var sdc in tabPage.Controls.OfType<ISaveEditorControl>())
                        sdc.reset();
        }
        #endregion
        #region events
        void comboBoxFaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFaction.SelectedIndex > -1)
                foreach (TabPage tabPage in tabControl1.TabPages)
                    foreach (var sdc in tabPage.Controls.OfType<ISaveEditorControl>())
                        sdc.setExisting(GameInfo.getItemCollection
                            (comboBoxFaction.SelectedItem, ((Control)sdc).Tag as string));
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            save();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            reset();
        }
        #endregion
    }
    public interface ISaveEditorControl
    {
        void InitControl();
        void addFilter(string filter);
        void clearFilter();
        void setExisting(EsfTabControl.BaseGameItemCollection baseGameItemCollection);
        void save();
        void clear();
        void reset();
    }
}
