using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsfSaveEditorControls
{
    public static class GameInfo
    {
        public static dynamic setting = null;
        public const string gamebuildpath = @"COMPRESSED_DATA\BUILD";
        public const string gamedatepath = @"SAVE_GAME_HEADER\DATE\0";
        public const string factionarraypath = @"COMPRESSED_DATA\CAMPAIGN_ENV\CAMPAIGN_MODEL\WORLD\FACTION_ARRAY";
        public const string characterarraypath = @"CHARACTER_ARRAY";
        public const string characterpath = @"CHARACTER\CHARACTER_DETAILS";
        public const string characternamepath = @"CHARACTER_NAME\NAMES_BLOCK";
        public const string characterlevelpath = @"CAMPAIGN_SKILLS";
        public const string charactertraitpath = @"TRAITS\TRAIT";
        public const string characterskillpath = @"CAMPAIGN_SKILLS\CAMPAIGN_SKILLS_BLOCK";
        public const string characterancillarypath = @"ANCILLARY";
        public const string armyarraypath = @"ARMY_ARRAY";
        public const string armydetailpath = @"MILITARY_FORCE_LEGACY";
        public const string armylevelpath = @"MILITARY_FORCE_LEGACY\CAMPAIGN_SKILLS";
        public const string armyunitpath = @"UNIT_CONTAINER\UNITS_ARRAY";
        public const string packpath = "data";
        public const string locpath = @"text\db";
        public const string dbPath = "db";
        public const string tablepath_traitlevels = "character_trait_levels_tables";
        public const string tablepath_characterskills = "character_skills_tables";
        public const string tablepath_main_units = "main_units_tables";
        public const string tablepath_land_units = "land_units_tables";
        public const string characterskillnodepath = "character_skill_nodes_tables";
        public const string traitleveleffectstablepath = "trait_level_effects_tables";
        public const string characterskilleveleffectpath = "character_skill_level_to_effects_junctions_tables";
        public const string anceffectpath = "ancillary_to_effects_tables";
        public const string tablepath_units = "main_units_tables";
        public const string schema_R2TW = "maxVersions_R2TW.xml";
        public const string schema_ATW = "maxVersions_ATW.xml";
        public const string traitkeytextremove = "character_trait_levels_colour_text_";
        public const string anckeytextremove = "ancillaries_colour_text_";
        public const string characterkeytextremove = "character_skills_localised_description";
        public const string locpath_names = "names.loc";
        public const string locpath_skills = "character_skills.loc";
        public const string locpath_traits = "character_trait_levels.loc";
        public const string locpath_effects = "effects.loc";
        public const string locpath_anc = "ancillaries.loc";
        public const string locpath_army_name = "military_force_legacy_names.loc";
        public const string locpath_army_romanregion = "region_groups.loc";
        public const string locpath_effect_scope = "campaign_effect_scopes.loc";
        public const string locnamecharactertraitlevel = "character_trait_levels_onscreen_name_";
        public const string locnameancillaries = "ancillaries_onscreen_name_";
        public const string locnamecharacterskilllevel = "character_skills_localised_name_";
        public const string locnameeffectdescription = "effects_description_";
        public const string locnameeffectscope = "campaign_effect_scopes_localised_text_";
        public const string escape_character_positive_value = @"%+n";
        public const string save_item_cclass = "cclass";
        public const string save_item_background = "background";
        public const string save_item_skill_point = "skill_point";
        public const string save_item_level = "level";
        public const string save_item_exp = "exp";
        public const string save_item_age = "age";
        public const string save_item_key = "key";
        public const string save_item_rank = "rank";
        public const string save_item_tier = "tier";
        public const string save_item_indent = "indent";
        public const string save_item_size = "size";
        public const string save_item_max_size = "max_size";
        public const string save_item_action = "action";
        public const string save_item_max_action = "max_action";
        public static readonly List<string> dataPacks = new List<string>();
        public static readonly List<string> locDataPacks = new List<string>();
        public static readonly List<string> item_characters = new List<string>(){
         "general", "spy", "dignitary", "champion", "army", "navy" };

        public static void SetGame(string gameid)
        {
            var type = Type.GetType("EsfSaveEditorControls." + gameid);
            setting = type.GetProperty("Default").GetValue(setting);
        }
        public static void LoadDataPacks()
        {
            dataPacks.Clear();
            locDataPacks.Clear();
            System.Collections.Specialized.StringCollection sc = setting.dataPacks;
            dataPacks.AddRange(sc.Cast<string>().Distinct());
            sc = setting.locDataPacks;
            locDataPacks.AddRange(sc.Cast<string>().Distinct());
        }
        public static void SaveDataPackSettings(IList<string> input, List<string> internal_list)
        {
            internal_list.Clear();
            System.Collections.Specialized.StringCollection sc;

            if (internal_list == EsfSaveEditorControls.GameInfo.dataPacks)
                sc = EsfSaveEditorControls.GameInfo.setting.dataPacks;
            else
                sc = EsfSaveEditorControls.GameInfo.setting.locDataPacks;

            internal_list.AddRange(input);

            sc.Clear();
            sc.AddRange(input.ToArray());
            EsfSaveEditorControls.GameInfo.setting.Save();
        }
        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900); //EDIT: i've typed 400 instead 900
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }
        public static EsfTabControl.BaseGameItemCollection getItemCollection(object item, string property)
        {
            return (EsfTabControl.BaseGameItemCollection)item.GetType().GetProperty(property).GetValue(item);
        }
    }
}
