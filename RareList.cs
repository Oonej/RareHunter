using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace RareHunter
{
    public class RareList
    {
        public SortedDictionary<string, RareItem> rareCount = new SortedDictionary<string, RareItem>();

        public string[] tiers = { @"Adherent's Crystal
                                    ,Alchemist's Crystal
                                    ,Artificer's Crystal
                                    ,Artist's Crystal
                                    ,Ben Ten's Crystal
                                    ,Berzerker's Crystal
                                    ,Brawler's Crystal
                                    ,Chef's Crystal
                                    ,Converter's Crystal
                                    ,Corruptor's Crystal
                                    ,Deceiver's Crystal
                                    ,Dodger's Crystal
                                    ,Elysa's Crystal
                                    ,Enchanter's Crystal
                                    ,Evader's Crystal
                                    ,Fletcher's Crystal
                                    ,Hieromancer's Crystal
                                    ,Hunter's Crystal
                                    ,Imbuer's Crystal
				                    ,Knight's Crystal
                                    ,Lich's Pearl
                                    ,Life Giver's Crystal
                                    ,Lugian's Pearl
                                    ,Magus's Pearl
                                    ,Monarch's Crystal
                                    ,Observer's Crystal
                                    ,Oswald's Crystal
                                    ,Physician's Crystal
                                    ,Resister's Crystal
                                    ,Rogue's Crystal
                                    ,Scholar's Crystal
                                    ,Smithy's Crystal
                                    ,Sprinter's Pearl
                                    ,T'ing's Crystal
                                    ,Thief's Crystal
                                    ,Thorsten's Crystal
                                    ,Tinker's Crystal
                                    ,Ursuin's Pearl
                                    ,Vaulter's Crystal
                                    ,Warrior's Crystal
                                    ,Wayfarer's Pearl
                                    ,Zefir's Crystal",
                                    @"Archer's Jewel
                                    ,Astyrrian's Jewel
                                    ,Duelist's Jewel
                                    ,Executor's Jewel
                                    ,Gelid's Jewel
                                    ,Inferno's Jewel
                                    ,Invigorating Elixir
                                    ,Mage's Jewel
                                    ,Melee's Jewel
                                    ,Miraculous Elixir
                                    ,Olthoi's Jewel
                                    ,Pearl of Acid Baning
                                    ,Pearl of Blade Baning
                                    ,Pearl of Blood Drinking
                                    ,Pearl of Bludgeon Baning
                                    ,Pearl of Defending
                                    ,Pearl of Flame Baning
                                    ,Pearl of Frost Baning
                                    ,Pearl of Heart Seeking
                                    ,Pearl of Hermetic Linking
                                    ,Pearl of Impenetrability
                                    ,Pearl of Lightning Baning
                                    ,Pearl of Pierce Baning
                                    ,Pearl of Spirit Drinking
                                    ,Pearl of Swift Killing
                                    ,Refreshing Elixir
                                    ,Tusker's Jewel
                                    ,Warrior's Jewel",
                                    @"Casino Exquisite Keyring
                                    ,Medicated Health Kit
                                    ,Medicated Mana Kit
                                    ,Medicated Stamina Kit
                                    ,Shimmering Skeleton Key",
                                    @"Adept's Fervor
                                    ,Aristocrat's Bracelet
                                    ,Band of Elemental Harmony
                                    ,Bracelet of Binding
                                    ,Bracers of Leikotha's Tears
                                    ,Breastplate of Leikotha's Tears
                                    ,Circle of Pure Thought
                                    ,Dread Marauder Shield
                                    ,Dreamseer Bangle
                                    ,Dusk Coat
                                    ,Dusk Leggings
                                    ,Footman's Boots
                                    ,Gauntlets of Leikotha's Tears
                                    ,Gauntlets of the Crimson Star
                                    ,Gelidite Boots
                                    ,Gelidite Bracers
                                    ,Gelidite Breastplate
                                    ,Gelidite Gauntlets
                                    ,Gelidite Girth
                                    ,Gelidite Greaves
                                    ,Gelidite Mitre
                                    ,Gelidite Pauldrons
                                    ,Gelidite Tassets
                                    ,Girth of Leikotha's Tears
                                    ,Golden Snake Choker
                                    ,Greaves of Leikotha's Tears
                                    ,Helm of Leikotha's Tears
                                    ,Ibriya's Choice
                                    ,Imperial Chevaird's Helm
                                    ,Loop of Opposing Benedictions
                                    ,Love's Favor
                                    ,Mirrored Justice
                                    ,Necklace of Iniquity
                                    ,Patriarch's Twilight Coat
                                    ,Patriarch's Twilight Tights
                                    ,Pauldrons of Leikotha's Tears
                                    ,Ring of Channeling
                                    ,Shield of Engorgement
                                    ,Steel Wall Boots
                                    ,Swift Strike Ring
                                    ,Tassets of Leikotha's Tears
                                    ,Tracker Boots
                                    ,Twin Ward
                                    ,Unchained Prowess Ring
                                    ,Valkeer's Helm
                                    ,Weeping Ring
                                    ,Winter's Heart Ring",
                                    @"Foolproof Aquamarine
                                    ,Foolproof Black Garnet
                                    ,Foolproof Black Opal
                                    ,Foolproof Emerald
                                    ,Eternal Health Kit
                                    ,Eternal Mana Kit
                                    ,Eternal Stamina Kit
                                    ,Foolproof Fire Opal
                                    ,Hieroglyph of Alchemy Mastery
                                    ,Hieroglyph of Arcane Enlightenment
                                    ,Hieroglyph of Armor Tinkering Expertise
                                    ,Hieroglyph of Cooking Mastery
                                    ,Hieroglyph of Creature Enchantment Mastery
                                    ,Hieroglyph of Deception Mastery
                                    ,Hieroglyph of Dirty Fighting Mastery
                                    ,Hieroglyph of Dual Wield Mastery
                                    ,Hieroglyph of Fealty
                                    ,Hieroglyph of Finesse Weapon Mastery
                                    ,Hieroglyph of Fletching Mastery
                                    ,Hieroglyph of Healing Mastery
                                    ,Hieroglyph of Heavy Weapon Mastery
                                    ,Hieroglyph of Impregnability
                                    ,Hieroglyph of Invulnerability
                                    ,Hieroglyph of Item Enchantment Mastery
                                    ,Hieroglyph of Item Tinkering Expertise
                                    ,Hieroglyph of Jumping Mastery
                                    ,Hieroglyph of Leadership Mastery
                                    ,Hieroglyph of Life Magic Mastery
                                    ,Hieroglyph of Light Weapon Mastery
                                    ,Hieroglyph of Lockpick Mastery
                                    ,Hieroglyph of Magic Item Tinkering Expertise
                                    ,Hieroglyph of Magic Resistance
                                    ,Hieroglyph of Mana Conversion Mastery
                                    ,Hieroglyph of Missile Weapon Mastery
                                    ,Hieroglyph of Monster Attunement
                                    ,Hieroglyph of Person Attunement
                                    ,Hieroglyph of Recklessness Mastery
                                    ,Hieroglyph of Shield Mastery
                                    ,Hieroglyph of Sneak Attack Mastery
                                    ,Hieroglyph of Sprint
                                    ,Hieroglyph of Two Handed Weapons Mastery
                                    ,Hieroglyph of Void Magic Mastery
                                    ,Hieroglyph of War Magic Mastery
                                    ,Hieroglyph of Weapon Tinkering Expertise
                                    ,Ideograph of Acid Protection
                                    ,Ideograph of Armor
                                    ,Ideograph of Blade Protection
                                    ,Ideograph of Bludgeoning Protection
                                    ,Ideograph of Fire Protection
                                    ,Ideograph of Frost Protection
                                    ,Ideograph of Lightning Protection
                                    ,Ideograph of Battlemage's Blessing
                                    ,Ideograph of Piercing Protection
                                    ,Ideograph of Regeneration
                                    ,Ideograph of Revitalization
                                    ,Foolproof Imperial Topaz
                                    ,Infinite Deadly Acid Arrowheads
                                    ,Infinite Deadly Armor Piercing Arrowheads
                                    ,Infinite Deadly Blunt Arrowheads
                                    ,Infinite Deadly Broad Arrowheads
                                    ,Infinite Deadly Lightning Arrowheads
                                    ,Infinite Deadly Fire Arrowheads
                                    ,Infinite Deadly Frog Crotch Arrowheads
                                    ,Infinite Deadly Frost Arrowheads
                                    ,Infinite Elaborate Dried Rations
                                    ,Infinite Ivory
                                    ,Infinite Leather
                                    ,Infinite Simple Dried Rations
                                    ,Foolproof Jet
                                    ,Limitless Lockpick
                                    ,Pack
                                    ,Perennial Argenory Dye
                                    ,Perennial Berimphur Dye
                                    ,Perennial Botched Dye
                                    ,Perennial Colban Dye
                                    ,Perennial Hennacin Dye
                                    ,Perennial Lapyan Dye
                                    ,Perennial Minalim Dye
                                    ,Perennial Relanim Dye
                                    ,Perennial Thananim Dye
                                    ,Perennial Verdalim Dye
                                    ,Foolproof Peridot
                                    ,Pictograph of Coordination
                                    ,Pictograph of Endurance
                                    ,Pictograph of Focus
                                    ,Pictograph of Quickness
                                    ,Pictograph of Strength
                                    ,Pictograph of Willpower
                                    ,Foolproof Red Garnet
                                    ,Rune of Acid Bane
                                    ,Rune of Blade Bane
                                    ,Rune of Blood Drinker
                                    ,Rune of Bludgeon Bane
                                    ,Rune of Defender
                                    ,Rune of Dispel
                                    ,Rune of Flame Bane
                                    ,Rune of Frost Bane
                                    ,Rune of Heart Seeker
                                    ,Rune of Hermetic Link
                                    ,Rune of Impenetrability
                                    ,Rune of Lifestone Recall
                                    ,Rune of Lightning Bane
                                    ,Rune of Pierce Bane
                                    ,Rune of Portal Recall
                                    ,Rune of Spirit Drinker
                                    ,Rune of Swift Killer
                                    ,Foolproof Sunstone
                                    ,Foolproof White Sapphire
                                    ,Foolproof Yellow Topaz
                                    ,Foolproof Zircon",
                                    @"Assassin's Whisper
                                    ,Baton of Tirethas
                                    ,Bearded Axe of Souia-Vey
                                    ,Black Cloud Bow
                                    ,Black Thistle
                                    ,Bloodmark Crossbow
                                    ,Brador's Frozen Eye
                                    ,Canfield Cleaver
                                    ,Champion's Demise
                                    ,Chitin Cracker
                                    ,Corsair's Arc
                                    ,Count Renari's Equalizer
                                    ,Dart-Flicker
                                    ,Death's Grip Staff
                                    ,Decapitator's Blade
                                    ,Defiler of Milantos
                                    ,Deru Limb
                                    ,Desert Wyrm
                                    ,Dragonspine Bow
                                    ,Drifter's Atlatl
                                    ,Dripping Death
                                    ,Ebonwood Shortbow
                                    ,Eye of Muramm
                                    ,Feathered Razor
                                    ,Fist of Three Principles
                                    ,Guardian of Pwyll
                                    ,Heart of Darkest Flame
                                    ,Hevelio's Half-Moon
                                    ,Hooded Serpent Slinger
                                    ,Huntsman's Dart-Thrower
                                    ,Iron Bull
                                    ,Itaka's Naginata
                                    ,Malachite Slasher
                                    ,Moriharu's Kitchen Knife
                                    ,Morrigan's Vanity
                                    ,Orb of the Ironsea
                                    ,Pillar of Fearlessness
                                    ,Pitfighter's Edge
                                    ,Revenant's Scythe
                                    ,Ridgeback Dagger
                                    ,Royal Ladle
                                    ,Serpent's Flight
                                    ,Skullpuncher
                                    ,Smite
                                    ,Spear of Lost Truths
                                    ,Spirit Shifting Staff
                                    ,Squire's Glaive
                                    ,Staff of All Aspects
                                    ,Staff of Fettered Souls
                                    ,Staff of Tendrils
                                    ,Star of Gharu'n
                                    ,Star of Tukal
                                    ,Steel Butterfly
                                    ,Subjugator
                                    ,Thunderhead
                                    ,Tri-Blade Spear
                                    ,Tusked Axe of Ayan Baqur
                                    ,Wand of the Frore Crystal
                                    ,Wings of Rakhil
                                    ,Zefir's Breath
                                    ,Zharalim Crookblade"

        };

        public RareList()
        {
            try
            {
                for (int i = 0; i < 6; i++)
                {
                    string[] lines = tiers[i].Split(',');
                    foreach (string line in lines)
                    {
                        if(!rareCount.ContainsKey(line.Trim()))
                            rareCount.Add(line.Trim(), new RareItem() { name = line, count = 0, tier = i + 1 });
                        else
                            Util.WriteToChat("Duplicate Key " + line.Trim());
                    }
                }
            }
            catch(Exception e)
            {
                Util.WriteToChat("ERROR" + e.Message);
            }
           
        }

        public SortedDictionary<string, RareItem> getList()
        {
            return rareCount;
        }

        public void UpdateCount(string name, int value)
        {
            rareCount[name].count += value;
        }

        public void SetValue(string name, int value)
        {
            rareCount[name].count = value;
        }

        public void resetCounts()
        {
            foreach (KeyValuePair<string, RareItem> entry in rareCount)
            {
                rareCount[entry.Key].count = 0;
            }
        }

        public SortedDictionary<string, int> getNonZeros()
        {
            SortedDictionary<string, int> temp = new SortedDictionary<string, int>();
            foreach (KeyValuePair<string, RareItem> entry in rareCount)
            {
                if (entry.Value.count != 0)
                    temp.Add(entry.Key, entry.Value.count);
            }

            return temp;
        }
    }

    public class RareItem
    {
        public string name;
        public int tier;
        public int count;
    }
}
