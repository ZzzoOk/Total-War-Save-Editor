using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsfLibrary;
using Common;
using Filetypes;
using System.Runtime.CompilerServices;

namespace EsfSaveEditorControls
{
    static public class GameDirSetting
    {
        public static void saveGamePath(string gamepath)
        {
            GameInfo.setting.gamePath = gamepath;
            GameInfo.setting.Save();
        }
        public static bool verifyGamePath()
        {
            var path = GameInfo.setting.gamePath;
            bool check = System.IO.Directory.Exists(path);
            if (check)
                check = System.IO.File.Exists(System.IO.Path.Combine(path, EsfSaveEditorControls.GameInfo.setting.exe));
            return check;
        }
        public static bool verifyGamePath(string path)
        {
            bool check = System.IO.Directory.Exists(path);
            if (check)
                check = System.IO.File.Exists(System.IO.Path.Combine(path, EsfSaveEditorControls.GameInfo.setting.exe));
            return check;
        }
        public static bool getDataPath(out string datapath)
        {
            if (verifyGamePath())
            {
                string gamepath = GameInfo.setting.gamePath;
                datapath = System.IO.Path.Combine(gamepath, GameInfo.packpath);
                return true;
            }
            else
                datapath = null;
            return false;
        }
    }
    public static class EsfLibraryExtension
    {
        public interface IFilter
        {
            int Filter(object input);
        }
        public class TextFilter : IFilter
        {
            string filter_string;
            public TextFilter(string filter_string)
            {
                this.filter_string = filter_string;
            }
            public int Filter(object input)
            {
                string input_string = input.ToString();

                return (input_string.Contains(filter_string)) ? 1 : 0;
            }
        }
        public static EsfLibrary.EsfNode GetNodeByPath(this EsfLibrary.ParentNode rootnode, string path)
        {
            var path_list = path.Split('\\').ToList();
            EsfLibrary.ParentNode result = rootnode;
            int array_node_index;
            for (int i = 0; i < path_list.Count; ++i)
            {
                try
                {
                    if (int.TryParse(path_list[i], out array_node_index))
                    {
                        if (i == path_list.Count - 1)
                            return result.Values[array_node_index];
                        else
                            result = result.Children[array_node_index];
                    }
                    else
                        result = result[path_list[i]];
                }
                catch
                {
                    throw new IndexOutOfRangeException(string.Format("Failed at subpath {0} of {1}", path_list[i], path));
                }
            }

            return result;
        }
        public static VirtualDirectory GetDirByPath(this PackFile stuff, string path)
        {
            VirtualDirectory result = stuff.Root;
            var path_list = path.Split('\\').ToList();
            foreach (string subpath in path_list)
            {
                result = result.Subdirectories.FirstOrDefault(x => x.Name.Equals(subpath));
                if (result == null)
                    return result;
            }
            return result;
        }
        public static Dictionary<string, DBFile> getDBFiles(this VirtualDirectory DB, string tablepathstring)
        {
            VirtualDirectory dir = DB.Subdirectories.FirstOrDefault(x => x.Name.Equals(tablepathstring));
            if (dir == null)
                return new Dictionary<string, DBFile>(0);

            Dictionary<string, DBFile> dbFiles = new Dictionary<string, DBFile>(dir.Count());
            foreach (var file in dir)
            {
                DBFile temp;
                try { temp = PackedFileDbCodec.Decode(file); }
                catch { continue; }
                dbFiles.Add(file.Name, temp);
            }
            return dbFiles;
        }
        public static DBFile[] getDBFiles(string tablepathstring, params VirtualDirectory[] DBs)
        {
            Dictionary<string, DBFile> DBFiles = new Dictionary<string, DBFile>();
            foreach (var db in DBs)
            {
                var tables = db.getDBFiles(tablepathstring);
                foreach (var table in tables)
                {
                    DBFiles[table.Key] = table.Value;
                }
            }
            return DBFiles.Select(x => x.Value).ToArray();
        }
        public static void fillDictionary(this LocFile locFile, Dictionary<string, string> dictionary, string key_filter, IFilter filter)
        {
            foreach (var entry in locFile.Entries)
            {
                string key = entry.Tag;
                if (key_filter != "")
                {
                    key = key.Replace(key_filter, "");
                }
                string locstring = entry.Localised;
                if (filter.Filter(key) == 0)
                    dictionary[key] = locstring;
            }
        }
        public static void fillDictionary(this LocFile locFile, Dictionary<string, string> dictionary, string key_filter)
        {
            foreach (var entry in locFile.Entries)
            {
                string key = entry.Tag;
                if (key_filter != "")
                {
                    key = key.Replace(key_filter, "");
                }
                string locstring = entry.Localised;
                dictionary[key] = locstring;
            }
        }
        public static IEnumerable<System.Windows.Forms.Control> FlattenChildren(this System.Windows.Forms.Control control)
        {
            var children = control.Controls.Cast<System.Windows.Forms.Control>();
            return children.SelectMany(c => FlattenChildren(c)).Concat(children);
        }
    }
    public class AsyncLazy<T> : Lazy<Task<T>>
    {
        public AsyncLazy(Func<T> valueFactory) :
            base(() => Task.Factory.StartNew(valueFactory)) { }

        public AsyncLazy(Func<Task<T>> taskFactory) :
            base(() => Task.Factory.StartNew(() => taskFactory()).Unwrap()) { }

        public TaskAwaiter<T> GetAwaiter() { return Value.GetAwaiter(); }
    }
    public interface IGameData
    {
        Dictionary<string, string> DictionaryCharacterName { get; }
        Dictionary<string, string> DictionaryArmyRomanRegion { get; }
        Dictionary<string, string> DictionaryArmyName { get; }
        GameData.GenericGameItemCollection Traits { get; }
        GameData.GenericGameItemCollection Skills { get; }
        GameData.GenericGameItemCollection Ancillaries { get; }
        GameData.GenericGameItemCollection Units { get; }
    }
    public sealed class GameData
    {
        #region structure
        public class GenericGameItem
        {
            public string name {get;set;}
            public virtual string description { get; set; }
            public override string ToString()
            {
                return name;
            }
        }
        public class RankedGameItem : GenericGameItem
        {
            protected List<GameItemsWithEffects> list = new List<GameItemsWithEffects>(3);
            public IEnumerator<GameItemsWithEffects> GetEnumerator()
            {
                return list.GetEnumerator();
            }
            protected virtual void Add(GameItemsWithEffects item)
            {
                list.Add(new GameItemsWithEffects());
            }
            protected void addRank(int level){
                lock (list)
                    while (list.Count <= level)
                    {
                        Add(new GameItemsWithEffects());
                    }
            }
            public void addEffect(int rank, string effectid, string value, string scope)
            {
                if (rank > 0)
                    --rank;
                addRank(rank);
                GameItemsWithEffects item = list[rank];
                item.addEffect(effectid, value, scope);
            }
            public virtual GameItemsWithEffects this[int rank]
            {
                get
                {
                    if (rank > 0 && rank <= list.Count)
                    {
                        return list[rank - 1];
                    }
                    return (new GameItemsWithEffects());
                }
                set
                {
                }
            }
        }
        public abstract class GenericGameItemCollection : Dictionary<string, GenericGameItem>
        {
            public new GenericGameItem this[string key]
            {
                get
                {
                    GenericGameItem result;
                    if (this.TryGetValue(key, out result))
                        return result;
                    else
                        Console.WriteLine(String.Format("Key {0} not found. Try loading some mod packs.", key));
                    return null;
                }
            }
            public abstract void Initialise(params VirtualDirectory[] db);
            public virtual void Localise(IReadOnlyDictionary<string, string> dict)
            {
                Parallel.ForEach(this.Values, anc =>
                {
                    string name;
                    bool got_name = dict.TryGetValue(anc.name, out name);
                    if (got_name)
                        anc.name = name;
                });
            }
            protected void iterateDBs(Action<DBRow> process, string DBpath, params VirtualDirectory[] db)
            {
                DBFile[] dBFiles = EsfLibraryExtension.getDBFiles(DBpath, db);
                foreach (var dBFile in dBFiles)
                    foreach (var row in dBFile.Entries)
                    {
                        process(row);
                    }
            }
        }
        public abstract class GameItemWithEffectsCollection : GenericGameItemCollection
        {
            public virtual void Localise(IReadOnlyDictionary<string, string> dict
                , Dictionary<string, string> effect_dict
                , Dictionary<string, string> scope_dict)
            {
                Parallel.ForEach(this.Values, anc =>
                {
                    string name;
                    bool got_name = dict.TryGetValue(anc.name, out name);
                    if (got_name)
                        anc.name = name;
                    (anc as GameItemsWithEffects).fixEffectKeyRef(effect_dict, scope_dict);
                });
            }
        }
        public abstract class RankedGameItemCollection : GameItemWithEffectsCollection
        {
            public override void Localise(IReadOnlyDictionary<string, string> dict
                , Dictionary<string, string> effect_dict
                , Dictionary<string, string> scope_dict)
            {
                Parallel.ForEach(this.Values, skill =>
                {
                    string name;
                    bool got_name = dict.TryGetValue(skill.name, out name);
                    if (got_name)
                        skill.name = name;
                    foreach (var ranked_skill in skill as RankedGameItem)
                    {
                        ranked_skill.name = skill.name;
                        ranked_skill.fixEffectKeyRef(effect_dict, scope_dict);
                    }
                });
            }
        }
        public class Effect : GenericGameItem
        {
            int value;
            public string scope { get; set; }
            public override string description
            {
                get
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(name);
                    sb.Replace(GameInfo.escape_character_positive_value, value > 0 ? "+" + value.ToString() : value.ToString());
                    sb.Replace("%n", value.ToString());
                    sb.Replace(@"%%", @"%");
                    sb.Append(scope);
                    return sb.ToString();
                }
                set
                {
                    this.value = int.Parse(value);
                }
            }
        }
        public class GameItemsWithEffects : GenericGameItem
        {
            List<Effect> effects = new List<Effect>();

            public void fixEffectKeyRef(Dictionary<string, string> effect_dict
                , Dictionary<string, string> scope_dict)
            {
                foreach (var effect in effects)
                {
                    try
                    {
                        var effect_desc = effect_dict[effect.name];
                        effect.name = effect_desc;
                    }
                    catch
                    {
                        lock (effect_dict)
                        {
                            string value;
                            var assigned = effect_dict.TryGetValue(effect.name, out value);
                            if (!assigned)
                            {
                                effect_dict.Add(effect.name, effect.name);
                                Console.WriteLine("Cannot find " + effect.name);
                            }
                        }
                    }
                    try
                    {
                        var scope_desc = scope_dict[effect.scope];
                        effect.scope = scope_desc;
                    }
                    catch
                    {
                        lock (scope_dict)
                        {
                            string value;
                            var assigned = scope_dict.TryGetValue(effect.scope, out value);
                            if (!assigned)
                            {
                                scope_dict.Add(effect.scope, effect.scope);
                                Console.WriteLine("Cannot find " + effect.scope);
                            }
                        }
                    }
                }
            }
            public void addEffect(string effectKey, string effectValue, string scope)
            {
                effects.Add(new Effect() { name = effectKey, description = effectValue, scope = scope});
            }
            public void addEffects(List<Effect> effects)
            {
                this.effects.AddRange(effects);
            }
            public override string description
            {
                get
                {
                    var description_text = effects.Select(effect => effect.description);
                    StringBuilder sb = new StringBuilder();
                    foreach (var text in description_text)
                    {
                        sb.AppendLine(text);
                    }
                    return sb.ToString();
                }
                set { }
            }
        }
        public class Ancillary : GameItemsWithEffects
        {
        }
        public class Trait : RankedGameItem
        {
            List<int> ranks = new List<int>();
            public int getRank(int rank)
            {
                for (int i = ranks.Count - 1; i >= 0; --i)
                    if (rank >= ranks[i])
                        return i;
                return -1;
            }
            protected override void Add(GameItemsWithEffects item)
            {
                base.Add(item);
                ranks.Add(0);
            }
            public void addRank(int level, int rank, string key, List<Effect> effects)
            {
                level = level > 0 ? level - 1 : level;
                addRank(level);
                ranks[level] = rank;
                var trait = list[level];
                trait.name = key;
                trait.addEffects(effects);
            }
            public override GameItemsWithEffects this[int rank]{
                get
                {
                    var level = getRank(rank);
                    return level >= 0 ? list[level] : new GameItemsWithEffects();
                }
                set
                {
                }
            }
        }
        public class Skill : RankedGameItem
        {
            public string indent { get; set; }
            public string tier { get; set; }
            public bool background { get; set; }
        }
        public class ArmyUnit : GenericGameItem
        {
            const string melee_description = "Category: {0}\nMelee Attack: {1}\nMelee Defense: {2}\nArmour Type: {3}\nCharge Bonus: {4}\nCampaign Action Points: {5}";
            const string range_description = "\nRange Type: {6}\nAccuracy: {7}\nAmmo: {8}\nReload Time: {9}";
            public List<object> values { get; set; }
            public bool isNavy { get; set; }
            public string armySize { get; set; }
            public override string description
            {
                get
                {
                    StringBuilder sb = new StringBuilder();
                    if (values.Count > 6)
                        sb.AppendFormat(melee_description + range_description, values.ToArray());
                    else
                        sb.AppendFormat(melee_description, values.ToArray());
                    return sb.ToString();
                }
            }
        }
        public class Ancillaries : GameItemWithEffectsCollection
        {
            public override void Initialise(params VirtualDirectory[] db)
            {

                DBFile[] anceffecttables = EsfLibraryExtension.getDBFiles(GameInfo.ancillary_to_effects_tables, db);
                foreach (var anceffecttable in anceffecttables)
                    Parallel.ForEach(anceffecttable.Entries, anceffect =>
                    {
                        string id = anceffect["ancillary"].Value;
                        string effectid = anceffect["effect"].Value;
                        string scopeid = anceffect["effect_scope"].Value;
                        string value = anceffect["value"].Value;
                        GameItemsWithEffects ancillary;

                        lock (this)
                            if (ContainsKey(id))
                                ancillary = this[id] as GameItemsWithEffects;
                            else
                            {
                                ancillary = new Ancillary() { name = id };
                                Add(id, ancillary);
                            }

                        ancillary.addEffect(effectid, value, scopeid);
                    });
            }
        }
        public class Skills : RankedGameItemCollection
        {
            public override void Initialise(params VirtualDirectory[] db)
            {

                Task[] tasks = new Task[2];
                DBFile[] characterskilltables = EsfLibraryExtension.getDBFiles(GameInfo.character_skills_tables, db);
                foreach (var characterskilltable in characterskilltables)
                    foreach(var skill_entry in characterskilltable.Entries)
                    {
                        string id = skill_entry["key"].Value;
                        var skill = new Skill() { name = id, 
                            background = skill_entry["is_background_skill"].Value.Equals(true.ToString())};
                        Add(id, skill);
                    }
                tasks[0] = Task.Factory.StartNew(delegate
                {
                    DBFile[] characterskillnodetables = EsfLibraryExtension.getDBFiles(GameInfo.character_skill_nodes_tables, db);//3 factions, 7 subcultures
                    foreach (var characterskillnodetable in characterskillnodetables)
                        Parallel.ForEach(characterskillnodetable.Entries, characterskillnode =>
                        {
                            string indent = characterskillnode["indent"].Value;
                            string tier = characterskillnode["tier"].Value;
                            string id = characterskillnode["character_skill_key"].Value;

                            try
                            {
                                Skill skill = this[id] as Skill;
                                skill.indent = indent;
                                skill.tier = tier;
                            }
                            catch
                            {
                                Console.WriteLine("Cannot find skill " + id + " in " +
                                  GameInfo.character_skill_nodes_tables);
                            }
                        });
                });
                tasks[1] = Task.Factory.StartNew(delegate
                {
                    DBFile[] characterskilleffecttables = EsfLibraryExtension.getDBFiles(GameInfo.character_skill_level_to_effects_junctions_tables, db);
                    foreach (var characterskilleffecttable in characterskilleffecttables)
                        Parallel.ForEach(characterskilleffecttable.Entries, characterskilleffect =>
                        {
                            string id = characterskilleffect["character_skill_key"].Value;
                            string effectid = characterskilleffect["effect_key"].Value;
                            int rank = int.Parse(characterskilleffect["level"].Value);
                            string value = characterskilleffect["value"].Value;
                            string scope = characterskilleffect["effect_scope"].Value;
                            try
                            {
                                var skill = this[id] as Skill;
                                skill.addEffect(rank, effectid, value, scope);
                            }
                            catch
                            {
                                Console.WriteLine("Cannot find skill " + id + " in " +
                                  GameInfo.character_skill_level_to_effects_junctions_tables);
                            }
                        });
                });
                Task.WaitAll(tasks);
            }
        }
        public class Traits : RankedGameItemCollection
        {
            public override void Initialise(params VirtualDirectory[] db)
            {
                DBFile[] traitleveleffectstables = EsfLibraryExtension.getDBFiles(GameInfo.trait_level_effects_tables, db);
                DBFile[] traitleveltables = EsfLibraryExtension.getDBFiles(GameInfo.character_trait_levels_tables, db);
                int effectCount = 0;
                foreach (var traitleveleffectstable in traitleveleffectstables)
                {
                    effectCount += (int)traitleveleffectstable.Header.EntryCount;
                }
                Dictionary<string, List<Effect>> temptraiteffects =
                    new Dictionary<string, List<Effect>>(effectCount);

                foreach (var traitleveleffectstable in traitleveleffectstables)
                {
                    foreach (var leveledtraitrow in traitleveleffectstable.Entries)
                    {
                        string rankkey = leveledtraitrow["trait_level"].Value;
                        string effectid = leveledtraitrow["effect"].Value;
                        string scope = leveledtraitrow["effect_scope"].Value;
                        string value = leveledtraitrow["value"].Value;
                        var new_effect = new Effect() { name = effectid, description = value, scope = scope };
                        List<Effect> effects;
                        bool declared = temptraiteffects.TryGetValue(rankkey, out effects);

                        if (declared)
                            effects.Add(new_effect);
                        else
                            temptraiteffects.Add(rankkey, new List<Effect>(3) { new_effect });
                    }
                }

                foreach (var traitleveltable in traitleveltables)
                {
                    Parallel.ForEach(traitleveltable.Entries, trait =>
                    {
                        string key = trait["trait"].Value;
                        int rank = int.Parse(trait["threshold_points"].Value);
                        int level = int.Parse(trait["level"].Value);
                        string rankkey = trait["key"].Value;
                        List<Effect> effects;
                        bool declared = temptraiteffects.TryGetValue(rankkey, out effects);
                        if (declared)
                        {
                            Trait trait_entry;

                            lock (this)
                                if (ContainsKey(key))
                                    trait_entry = (Trait)this[key];
                                else
                                {
                                    trait_entry = new Trait() { name = key };
                                    Add(key, trait_entry);
                                }
                            trait_entry.addRank(level, rank,rankkey,effects);
                        }
                    });
                }
            }

            public override void Localise(IReadOnlyDictionary<string, string> dict
                , Dictionary<string, string> effect_dict
                , Dictionary<string, string> scope_dict)
            {
                Parallel.ForEach(this.Values, skill =>
                {
                    foreach (var ranked_skill in skill as RankedGameItem)
                    {
                        if (ranked_skill.name == null)
                            ranked_skill.name = "";
                        else
                        {
                            string name;
                            bool got_name = dict.TryGetValue(ranked_skill.name, out name);
                            if (got_name)
                                ranked_skill.name = name;
                        }
                        ranked_skill.fixEffectKeyRef(effect_dict, scope_dict);
                    }
                });
            }
        }
        public class ArmyUnits : GenericGameItemCollection
        {
            public override void Initialise(params VirtualDirectory[] db)
            {
                Dictionary<string, List<object>> land_units = new Dictionary<string,List<object>>(400);
                iterateDBs(land_unit =>
                {
                    string landUnit = land_unit["key"].Value;
                    string range_weapon = land_unit["primary_missile_weapon"].Value;
                    List<object> values;
                    if (land_unit["primary_missile_weapon"].Value == "")
                    {
                        values = new List<object>(6);
                        values.Add(land_unit["category"].Value);
                        values.Add(land_unit["melee_attack"].Value);
                        values.Add(land_unit["melee_defence"].Value);
                        values.Add(land_unit["armour"].Value);
                        values.Add(land_unit["charge_bonus"].Value);
                        values.Add(land_unit["campaign_action_points"].Value);
                    }
                    else
                    {
                        values = new List<object>(10);
                        values.Add(land_unit["category"].Value);
                        values.Add(land_unit["melee_attack"].Value);
                        values.Add(land_unit["melee_defence"].Value);
                        values.Add(land_unit["armour"].Value);
                        values.Add(land_unit["charge_bonus"].Value);
                        values.Add(land_unit["campaign_action_points"].Value);
                        values.Add(land_unit["primary_missile_weapon"].Value);
                        values.Add(land_unit["accuracy"].Value);
                        values.Add(land_unit["ammo"].Value);
                        values.Add(land_unit["reload"].Value);
                    }
                    land_units.Add(landUnit, values);
                }, GameInfo.land_units_tables, db);
                iterateDBs(main_unit =>
                {
                    string key = main_unit["unit"].Value;
                    string landUnit = main_unit["land_unit"].Value;
                    bool isNaval = main_unit["is_naval"].Value.Equals(true.ToString());
                    string size = main_unit["num_men"].Value;

                    var armyUnit = new ArmyUnit() { isNavy = isNaval, armySize = size };
                    armyUnit.name = (key);
                    List<object> stats;
                    bool found = land_units.TryGetValue(landUnit, out stats);
                    if (found)
                        armyUnit.values = stats;
                    this.Add(key, armyUnit);
                }, GameInfo.main_units_tables, db);
            }
        }
        #endregion

        public static volatile bool initialised = false;
        static object m_lock = new object();
        static IGameData gameData;

        public static void Invalidate()
        {
            lock (m_lock)
            {
                gameData = null;
                initialised = false;
            }
        }
        public static IGameData GetInstance()
        {
            if (initialised)
                return gameData;
            else
                return null;
        }
        public static void Initialise(ProgressUpdater progressUpdater)
        {
            lock (m_lock)
            {
                if (!initialised)
                {
                    gameData = new Nested(progressUpdater);
                }
            }
        }
        class Nested : IGameData
        {
            class Factory
            {
                IGameData data;
                ProgressUpdater progressUpdater;
                VirtualDirectory[] locDBs, dataDBs;
                internal Factory(IGameData data, ProgressUpdater progressUpdater)
                {
                    this.data = data;
                    this.progressUpdater = progressUpdater;
                }
                PackFile getPackFile(ProgressUpdater pu, string gamedatapath, string packPath)
                {
                    string path = System.IO.Path.Combine(gamedatapath, packPath);
                    if (System.IO.File.Exists(path))
                    {
                        PackFileCodec codec = new PackFileCodec();
                        pu.ConnectPackCodec(codec, path.Replace('\\', System.IO.Path.DirectorySeparatorChar));
                        return codec.Open(path);
                    }
                    else
                        return null;
                }
                internal bool Build()
                {
                    if (!getDataPacks().Result)
                        return false;

                    Dictionary<string, string> skill_names = new Dictionary<string, string>(400);
                    Dictionary<string, string> trait_names = new Dictionary<string, string>(400);
                    Dictionary<string, string> anc_names = new Dictionary<string, string>(400);
                    Dictionary<string, string> dictionaryEffectDescription = new Dictionary<string, string>(400);
                    Dictionary<string, string> scope_dict = new Dictionary<string, string>(400);
                    Task[] dicTasks = new Task[8];
                    Task[] gameDataTasks = new Task[4];
                    Task[] locTasks = new Task[3];
                    dicTasks[0] = Task.Run(() => fillDictionary(skill_names, GameInfo.locpath_skills, GameInfo.characterkeytextremove, GameInfo.locnamecharacterskilllevel));
                    dicTasks[1] = Task.Run(() => fillDictionary(trait_names, GameInfo.locpath_traits, GameInfo.traitkeytextremove, GameInfo.locnamecharactertraitlevel));
                    dicTasks[2] = Task.Run(() => fillDictionary(anc_names, GameInfo.locpath_anc, GameInfo.anckeytextremove, GameInfo.locnameancillaries));
                    dicTasks[3] = Task.Run(() => fillDictionary(dictionaryEffectDescription, GameInfo.locpath_effects, null, GameInfo.locnameeffectdescription));
                    dicTasks[4] = Task.Run(() => fillDictionary(data.DictionaryCharacterName, GameInfo.locpath_names, null, ""));
                    dicTasks[5] = Task.Run(() => fillDictionary(data.DictionaryArmyName, GameInfo.locpath_army_name, null, ""));
                    dicTasks[6] = Task.Run(() => fillDictionary(data.DictionaryArmyRomanRegion, GameInfo.locpath_army_romanregion, null, ""));
                    dicTasks[7] = Task.Run(() => fillDictionary(scope_dict, GameInfo.locpath_effect_scope, null, GameInfo.locnameeffectscope));
                    gameDataTasks[0] = Task.Run(() => data.Ancillaries.Initialise(dataDBs));
                    gameDataTasks[1] = Task.Run(() => data.Skills.Initialise(dataDBs));
                    gameDataTasks[2] = Task.Run(() => data.Traits.Initialise(dataDBs));
                    gameDataTasks[3] = Task.Run(() => data.Units.Initialise(dataDBs));
                    locTasks[0] = new Task(() => (data.Traits as GameItemWithEffectsCollection).Localise(trait_names, dictionaryEffectDescription, scope_dict));
                    locTasks[1] = new Task(() => (data.Skills as GameItemWithEffectsCollection).Localise(skill_names, dictionaryEffectDescription, scope_dict));
                    locTasks[2] = new Task(() => (data.Ancillaries as GameItemWithEffectsCollection).Localise(anc_names, dictionaryEffectDescription, scope_dict));
                    Task.WaitAll(dicTasks);
                    Task.WaitAll(gameDataTasks);

                    //only if localisation files loaded correctly
                    locTasks[0].Start();
                    locTasks[1].Start();
                    locTasks[2].Start();
                    Task.WaitAll(locTasks);

                    return true;
                }
                async Task<bool> getDataPacks()
                {
                    string dataPath;
                    if (!GameDirSetting.getDataPath(out dataPath))
                        return false;

                    if (!DBTypeMap.Instance.Initialized)
                        DBTypeMap.Instance.InitializeTypeMap(AppDomain.CurrentDomain.BaseDirectory);

                    PackFile[] locPackFiles = await Task.WhenAll(GameInfo.locDataPacks.Select
                        (dataPack => { 
                            return Task<PackFile>.Run(() => { 
                            return getPackFile(progressUpdater, dataPath, dataPack); }); }));
                    PackFile[] dataPackFiles = await Task<PackFile>.WhenAll(GameInfo.dataPacks.Select
                        (dataPack => { 
                            return Task<PackFile>.Run(() => { 
                            return getPackFile(progressUpdater, dataPath, dataPack); }); }));
                    locDBs = locPackFiles.OfType<PackFile>().Select(PackFile =>
                            PackFile.GetDirByPath(GameInfo.locpath)).OfType<VirtualDirectory>().ToArray();
                    dataDBs = dataPackFiles.OfType<PackFile>().Select(PackFile =>
                            PackFile.GetDirByPath(GameInfo.dbPath)).OfType<VirtualDirectory>().ToArray();
                    return true;
                }
                void fillDictionary(Dictionary<string, string> dictionary, string locfilepath, string text_filter, string key_filter)
                {
                    EsfLibraryExtension.IFilter filter = null;
                    if (text_filter != null)
                        filter = new EsfLibraryExtension.TextFilter(text_filter);

                    foreach (var vd in locDBs)
                    {
                        try
                        {
                            LocFile locfile = getlocfile(vd, locfilepath);
                            if (filter == null)
                                locfile.fillDictionary(dictionary, key_filter);
                            else
                                locfile.fillDictionary(dictionary, key_filter, filter);
                        }
                        catch
                        {

                        }
                    }
                }
                LocFile getlocfile(VirtualDirectory locdb, string name)
                {
                    PackEntry fileEntry = locdb.GetEntry(name);
                    PackedFile encodedFile = null;
                    if (fileEntry == null)
                        throw new KeyNotFoundException(name + " not found in localisation database");
                    encodedFile = (PackedFile)fileEntry;
                    LocFile decodedFile = LocCodec.Instance.Decode(encodedFile.Data);
                    return decodedFile;
                }
            }
            #region properties
            readonly Dictionary<string, string> dictionaryCharacterName = new Dictionary<string, string>(400);
            readonly Dictionary<string, string> dictionaryArmyRomanRegion = new Dictionary<string, string>(400);
            readonly Dictionary<string, string> dictionaryArmyName = new Dictionary<string, string>(400);
            readonly GenericGameItemCollection traits = new Traits();
            readonly GenericGameItemCollection skills = new Skills();
            readonly GenericGameItemCollection ancillaries = new Ancillaries();
            readonly GenericGameItemCollection units = new ArmyUnits();
            public Dictionary<string, string> DictionaryCharacterName { get { return dictionaryCharacterName; } }
            public Dictionary<string, string> DictionaryArmyRomanRegion { get { return dictionaryArmyRomanRegion; } }
            public Dictionary<string, string> DictionaryArmyName { get { return dictionaryArmyName; } }
            public GenericGameItemCollection Traits { get { return traits; } }
            public GenericGameItemCollection Skills { get { return skills; } }
            public GenericGameItemCollection Ancillaries { get { return ancillaries; } }
            public GenericGameItemCollection Units { get { return units; } }
            #endregion
            internal Nested(ProgressUpdater progressUpdater)
            {
                Factory factory = new Factory(this, progressUpdater);
                GameData.initialised = factory.Build();
            }
        }
    }
    public class ProgressUpdater //make UI thread safe
    {
        #region properties
        readonly ProgressReporter progressReporter;
        System.Windows.Forms.ToolStripProgressBar progress;
        System.Windows.Forms.ToolStripLabel label;
        EsfCodec currentCodec;
        Dictionary<string, PackFileCodec> codec = new Dictionary<string, PackFileCodec>();
        uint codecFileCount, currentCount;
        string file;
        #endregion
        public ProgressUpdater(System.Windows.Forms.ToolStripProgressBar bar
            , System.Windows.Forms.ToolStripLabel l)
        {
            progressReporter = new ProgressReporter();
            bar.Maximum = 0;
            bar.Step = 10;
            progress = bar;
            label = l;
        }
        #region Esf
        public void StartLoading(string file, EsfCodec codec)
        {
            this.file = file;
            progress.Value = 0;
            progress.Maximum = (int)new System.IO.FileInfo(file).Length;
            currentCodec = codec;
            currentCodec.NodeReadFinished += Update;
        }
        public void LoadingFinished()
        {
            try
            {
                progress.Value = 0;
                currentCodec.NodeReadFinished -= Update;
                label.Text = file + " loaded.";
            }
            catch { }
        }
        void Update(EsfNode ignored, long position)
        {
            if (ignored is ParentNode)
            {
                try
                {
                    if ((int)position <= progress.Maximum)
                    {
                        progress.Value = (int)position;
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                catch
                {
                    progress.Value = 0;
                    currentCodec.NodeReadFinished -= Update;
                }
            }
        }
        #endregion
        #region pack
        public void ConnectPackCodec(PackFileCodec codec, string f) 
        {
            progressReporter.ReportProgressAsync(() =>
            {
                progress.Minimum = 0;
                progress.Value = 0;
            });
            Connect(codec, f);
        }
        void Connect(PackFileCodec codec, string f)
        {
            lock (this.codec)
                this.codec.Add(f, codec);
            codec.HeaderLoaded += HeaderLoaded;
            codec.PackedFileLoaded += PackedFileLoaded;
            codec.PackFileLoaded += PackFileLoaded;
        }
        void Disconnect(string f)
        {
                PackFileCodec codec = this.codec[f];
                codec.HeaderLoaded -= HeaderLoaded;
                codec.PackedFileLoaded -= PackedFileLoaded;
                codec.PackFileLoaded -= PackFileLoaded;
                lock (this.codec)
                { 
                    this.codec.Remove(f);
                    if (this.codec.Count == 0)
                        progressReporter.ReportProgressAsync(() =>
                        {
                            label.Text = "Done loading all packs.";
                            progress.Value = progress.Maximum;
                        });
                }
        }
        public void HeaderLoaded(PFHeader header)
        {
            codecFileCount += header.FileCount;
            progressReporter.ReportProgressAsync(() =>
            {
                progress.Maximum += (int)header.FileCount;
                label.Text = string.Format("Loading {0}: 0 of {1} files loaded", file, header.FileCount);
            });
        }
        public void PackedFileLoaded(PackedFile packedFile) 
        {
            currentCount++;
            if (currentCount % 10 <= 0) 
                progressReporter.ReportProgressAsync(() =>
                {
                    label.Text = string.Format("Opening {0} ({1} of {2} files loaded)", file, currentCount, codecFileCount);
                    progress.PerformStep();
                });
        }
        public void PackFileLoaded(PackFile packedFile)
        {
            progressReporter.ReportProgressAsync(() =>
            {
                label.Text = string.Format("Finished opening {0} - {1} files loaded", packedFile, codecFileCount);
            });
            Disconnect(packedFile.Filepath);
        }
        #endregion
    }
}
