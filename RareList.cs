using System;
using System.Collections.Generic;
using System.Text;

namespace RareHunter
{
    public class RareList
    {
        public SortedDictionary<string, int> rareCount = new SortedDictionary<string, int>();
        public RareList()
        {
            try
            {
                rareCount.Add("Lugian's Pearl", 0);
                rareCount.Add("Ursuin's Pearl", 0);
                rareCount.Add("Wayfarer's Pearl", 0);
                rareCount.Add("Sprinter's Pearl", 0);
                rareCount.Add("Magus's Pearl", 0);
                rareCount.Add("Lich's Pearl", 0);
                rareCount.Add("Alchemist's Crystal", 0);
                rareCount.Add("Berzerker's Crystal", 0);
                rareCount.Add("Brawler's Crystal", 0);
                rareCount.Add("Knight's Crystal", 0);
                rareCount.Add("Rogue's Crystal", 0);
                rareCount.Add("Warrior's Crystal", 0);
                rareCount.Add("Scholar's Crystal", 0);
                rareCount.Add("Smithy's Crystal", 0);
                rareCount.Add("Hunter's Crystal", 0);
                rareCount.Add("Observer's Crystal", 0);
                rareCount.Add("Thorsten's Crystal", 0);
                rareCount.Add("Elysa's Crystal", 0);
                rareCount.Add("Chef's Crystal", 0);
                rareCount.Add("Enchanter's Crystal", 0);
                rareCount.Add("Oswald's Crystal", 0);
                rareCount.Add("Deceiver's Crystal", 0);
                rareCount.Add("Fletcher's Crystal", 0);
                rareCount.Add("Physician's Crystal", 0);
                rareCount.Add("Artificer's Crystal", 0);
                rareCount.Add("Tinker's Crystal", 0);
                rareCount.Add("Vaulter's Crystal", 0);
                rareCount.Add("Monarch's Crystal", 0);
                rareCount.Add("Life Giver's Crystal", 0);
                rareCount.Add("Thief's Crystal", 0);
                rareCount.Add("Adherent's Crystal", 0);
                rareCount.Add("Resister's Crystal", 0);
                rareCount.Add("Imbuer's Crystal", 0);
                rareCount.Add("Converter's Crystal", 0);
                rareCount.Add("Evader's Crystal", 0);
                rareCount.Add("Dodger's Crystal", 0);
                rareCount.Add("Zefir's Crystal", 0);
                rareCount.Add("Ben Ten's Crystal", 0);
                rareCount.Add("Hieromancer's Crystal", 0);
                rareCount.Add("Corruptor's Crystal", 0);
                rareCount.Add("Artist's Crystal", 0);
                rareCount.Add("T'ing's Crystal", 0);
                rareCount.Add("Warrior's Jewel", 0);
                rareCount.Add("Melee's Jewel", 0);
                rareCount.Add("Mage's Jewel", 0);
                rareCount.Add("Duelist's Jewel", 0);
                rareCount.Add("Archer's Jewel", 0);
                rareCount.Add("Tusker's Jewel", 0);
                rareCount.Add("Olthoi's Jewel", 0);
                rareCount.Add("Inferno's Jewel", 0);
                rareCount.Add("Gelid's Jewel", 0);
                rareCount.Add("Astyrrian's Jewel", 0);
                rareCount.Add("Executor's Jewel", 0);
                rareCount.Add("Pearl of Blood Drinking", 0);
                rareCount.Add("Pearl of Heart Seeking", 0);
                rareCount.Add("Pearl of Defending", 0);
                rareCount.Add("Pearl of Swift Killing", 0);
                rareCount.Add("Pearl of Spirit Drinking", 0);
                rareCount.Add("Pearl of Hermetic Linking", 0);
                rareCount.Add("Pearl of Blade Baning", 0);
                rareCount.Add("Pearl of Pierce Baning", 0);
                rareCount.Add("Pearl of Bludgeon Baning", 0);
                rareCount.Add("Pearl of Acid Baning", 0);
                rareCount.Add("Pearl of Flame Baning", 0);
                rareCount.Add("Pearl of Frost Baning", 0);
                rareCount.Add("Pearl of Lightning Baning", 0);
                rareCount.Add("Pearl of Impenetrability", 0);
                rareCount.Add("Refreshing Elixir", 0);
                rareCount.Add("Invigorating Elixir", 0);
                rareCount.Add("Miraculous Elixir", 0);
                rareCount.Add("Medicated Health Kit", 0);
                rareCount.Add("Medicated Stamina Kit", 0);
                rareCount.Add("Medicated Mana Kit", 0);
                rareCount.Add("Casino Exquisite Keyring", 0);
                rareCount.Add("Grand Casino Golden Keyring", 0);
                rareCount.Add("Grand Casino Golden Keyring", 0);
                rareCount.Add("Shimmering Skeleton Key", 0);
                rareCount.Add("Adept's Fervor", 0);
                rareCount.Add("Bracers of Leikotha's Tears", 0);
                rareCount.Add("Breastplate of Leikotha's Tears", 0);
                rareCount.Add("Dusk Coat", 0);
                rareCount.Add("Dusk Leggings", 0);
                rareCount.Add("Footman's Boots", 0);
                rareCount.Add("Gauntlets of the Crimson Star", 0);
                rareCount.Add("Gauntlets of Leikotha's Tears", 0);
                rareCount.Add("Gelidite Bracers", 0);
                rareCount.Add("Gelidite Breastplate", 0);
                rareCount.Add("Gelidite Gauntlets", 0);
                rareCount.Add("Gelidite Girth", 0);
                rareCount.Add("Gelidite Greaves", 0);
                rareCount.Add("Gelidite Mitre", 0);
                rareCount.Add("Gelidite Pauldrons", 0);
                rareCount.Add("Gelidite Tassets", 0);
                rareCount.Add("Gelidite Boots", 0);
                rareCount.Add("Girth of Leikotha's Tears", 0);
                rareCount.Add("Greaves of Leikotha's Tears", 0);
                rareCount.Add("Helm of Leikotha's Tears", 0);
                rareCount.Add("Imperial Chevaird's Helm", 0);
                rareCount.Add("Patriarch's Twilight Coat", 0);
                rareCount.Add("Patriarch's Twilight Tights", 0);
                rareCount.Add("Pauldrons of Leikotha's Tears", 0);
                rareCount.Add("Reinforced Boots", 0);
                rareCount.Add("Steel Wall Boots", 0);
                rareCount.Add("Tassets of Leikotha's Tears", 0);
                rareCount.Add("Tracker Boots", 0);
                rareCount.Add("Valkeer's Helm", 0);
                rareCount.Add("Dread Marauder Shield", 0);
                rareCount.Add("Mirrored Justice", 0);
                rareCount.Add("Shield of Engorgement", 0);
                rareCount.Add("Twin Ward", 0);
                rareCount.Add("Aristocrat's Bracelet", 0);
                rareCount.Add("Band of Elemental Harmony", 0);
                rareCount.Add("Bracelet of Binding", 0);
                rareCount.Add("Circle of Pure Thought", 0);
                rareCount.Add("Dreamseer Bangle", 0);
                rareCount.Add("Golden Snake Choker", 0);
                rareCount.Add("Ibriya's Choice", 0);
                rareCount.Add("Loop of Opposing Benedictions", 0);
                rareCount.Add("Love's Favor", 0);
                rareCount.Add("Necklace of Iniquity", 0);
                rareCount.Add("Ring of Channeling", 0);
                rareCount.Add("Swift Strike Ring", 0);
                rareCount.Add("Unchained Prowess Ring", 0);
                rareCount.Add("Weeping Ring", 0);
                rareCount.Add("Winter's Heart", 0);
                rareCount.Add("Pictograph of Strength", 0);
                rareCount.Add("Pictograph of Endurance", 0);
                rareCount.Add("Pictograph of Coordination", 0);
                rareCount.Add("Pictograph of Quickness", 0);
                rareCount.Add("Pictograph of Focus", 0);
                rareCount.Add("Pictograph of Willpower", 0);
                rareCount.Add("Hieroglyph of Alchemy Mastery", 0);
                rareCount.Add("Hieroglyph of Arcane Enlightenment", 0);
                rareCount.Add("Hieroglyph of Armor Tinkering Expertise", 0);
                rareCount.Add("Hieroglyph of Monster Attunement", 0);
                rareCount.Add("Hieroglyph of Person Attunement", 0);
                rareCount.Add("Hieroglyph of Light Weapon Mastery", 0);
                rareCount.Add("Hieroglyph of Missile Weapon Mastery", 0);
                rareCount.Add("Hieroglyph of Cooking Mastery", 0);
                rareCount.Add("Hieroglyph of Creature Enchantment Mastery", 0);
                rareCount.Add("Hieroglyph of Finesse Weapon Mastery", 0);
                rareCount.Add("Hieroglyph of Deception Mastery", 0);
                rareCount.Add("Hieroglyph of Fletching Mastery", 0);
                rareCount.Add("Hieroglyph of Healing Mastery", 0);
                rareCount.Add("Hieroglyph of Item Enchantment Mastery", 0);
                rareCount.Add("Hieroglyph of Item Tinkering Expertise", 0);
                rareCount.Add("Hieroglyph of Jumping Mastery", 0);
                rareCount.Add("Hieroglyph of Leadership Mastery", 0);
                rareCount.Add("Hieroglyph of Life Magic Mastery", 0);
                rareCount.Add("Hieroglyph of Lockpick Mastery", 0);
                rareCount.Add("Hieroglyph of Fealty", 0);
                rareCount.Add("Hieroglyph of Magic Item Tinkering Expertise", 0);
                rareCount.Add("Hieroglyph of Magic Resistance", 0);
                rareCount.Add("Hieroglyph of Mana Conversion Mastery", 0);
                rareCount.Add("Hieroglyph of Invulnerability", 0);
                rareCount.Add("Hieroglyph of Impregnability", 0);
                rareCount.Add("Hieroglyph of Sprint", 0);
                rareCount.Add("Hieroglyph of Heavy Weapon Mastery", 0);
                rareCount.Add("Hieroglyph of War Magic Mastery", 0);
                rareCount.Add("Hieroglyph of Weapon Tinkering Expertise", 0);
                rareCount.Add("Ideograph of Regeneration", 0);
                rareCount.Add("Ideograph of Revitalization", 0);
                rareCount.Add("Ideograph of Battlemage's Blessing", 0);
                rareCount.Add("Ideograph of Blade Protection", 0);
                rareCount.Add("Ideograph of Piercing Protection", 0);
                rareCount.Add("Ideograph of Bludgeoning Protection", 0);
                rareCount.Add("Ideograph of Acid Protection", 0);
                rareCount.Add("Ideograph of Fire Protection", 0);
                rareCount.Add("Ideograph of Frost Protection", 0);
                rareCount.Add("Ideograph of Lightning Protection", 0);
                rareCount.Add("Ideograph of Armor", 0);
                rareCount.Add("Rune of Blood Drinker", 0);
                rareCount.Add("Rune of Heart Seeker", 0);
                rareCount.Add("Rune of Defender", 0);
                rareCount.Add("Rune of Swift Killer", 0);
                rareCount.Add("Rune of Spirit Drinker", 0);
                rareCount.Add("Rune of Hermetic Link", 0);
                rareCount.Add("Rune of Blade Bane", 0);
                rareCount.Add("Rune of Pierce Bane", 0);
                rareCount.Add("Rune of Bludgeon Bane", 0);
                rareCount.Add("Rune of Acid Bane", 0);
                rareCount.Add("Rune of Flame Bane", 0);
                rareCount.Add("Rune of Frost Bane", 0);
                rareCount.Add("Rune of Lightning Bane", 0);
                rareCount.Add("Rune of Impenetrability", 0);
                rareCount.Add("Rune of Portal Recall", 0);
                rareCount.Add("Rune of Lifestone Recall", 0);
                rareCount.Add("Rune of Dispel", 0);
                rareCount.Add("Eternal Health Kit", 0);
                rareCount.Add("Eternal Stamina Kit", 0);
                rareCount.Add("Eternal Mana Kit", 0);
                rareCount.Add("Limitless Lockpick", 0);
                rareCount.Add("Infinite Deadly Frog Crotch Arrowheads", 0);
                rareCount.Add("Infinite Deadly Broad Arrowheads", 0);
                rareCount.Add("Infinite Deadly Armor Piercing Arrowheads", 0);
                rareCount.Add("Infinite Deadly Blunt Arrowheads", 0);
                rareCount.Add("Infinite Deadly Acid Arrowheads", 0);
                rareCount.Add("Infinite Deadly Fire Arrowheads", 0);
                rareCount.Add("Infinite Deadly Frost Arrowheads", 0);
                rareCount.Add("Infinite Deadly Electric Arrowheads", 0);
                rareCount.Add("Infinite Ivory", 0);
                rareCount.Add("Infinite Leather", 0);
                rareCount.Add("Infinite Major Mana Charge", 0);
                rareCount.Add("Infinite Simple Dried Rations", 0);
                rareCount.Add("Infinite Elaborate Dried Rations", 0);
                rareCount.Add("Perennial Verdalim Dye", 0);
                rareCount.Add("Perennial Hennacin Dye", 0);
                rareCount.Add("Perennial Berimphur Dye", 0);
                rareCount.Add("Perennial Thananim Dye", 0);
                rareCount.Add("Perennial Colban Dye", 0);
                rareCount.Add("Perennial Relanim Dye", 0);
                rareCount.Add("Perennial Lapyan Dye", 0);
                rareCount.Add("Perennial Minalim Dye", 0);
                rareCount.Add("Perennial Argenory Dye", 0);
                rareCount.Add("Perennial Botched Dye", 0);
                rareCount.Add("Foolproof Black Opal", 0);
                rareCount.Add("Foolproof Fire Opal", 0);
                rareCount.Add("Foolproof Sunstone", 0);
                rareCount.Add("Foolproof Imperial Topaz", 0);
                rareCount.Add("Foolproof Black Garnet", 0);
                rareCount.Add("Foolproof White Sapphire", 0);
                rareCount.Add("Foolproof Emerald", 0);
                rareCount.Add("Foolproof Aquamarine", 0);
                rareCount.Add("Foolproof Red Garnet", 0);
                rareCount.Add("Foolproof Jet", 0);
                rareCount.Add("Foolproof Peridot", 0);
                rareCount.Add("Foolproof Yellow Topaz", 0);
                rareCount.Add("Foolproof Zircon", 0);
                rareCount.Add("Count Renari's Equalizer", 0);
                rareCount.Add("Smite", 0);
                rareCount.Add("Ridgeback Dagger", 0);
                rareCount.Add("Star of Tukal", 0);
                rareCount.Add("Subjugator", 0);
                rareCount.Add("Pillar of Fearlessness", 0);
                rareCount.Add("Staff of All Aspects", 0);
                rareCount.Add("Staff of Tendrils", 0);
                rareCount.Add("Brador's Frozen Eye", 0);
                rareCount.Add("Morrigan's Vanity", 0);
                rareCount.Add("Steel Butterfly", 0);
                rareCount.Add("Bearded Axe of Souia-Vey", 0);
                rareCount.Add("Black Thistle", 0);
                rareCount.Add("Moriharu's Kitchen Knife", 0);
                rareCount.Add("Baton of Tirethas", 0);
                rareCount.Add("Thunderhead", 0);
                rareCount.Add("Star of Gharu'n", 0);
                rareCount.Add("Spirit Shifting Staff", 0);
                rareCount.Add("Staff of Fettered Souls", 0);
                rareCount.Add("Guardian of Pwyll", 0);
                rareCount.Add("Fist of Three Principles", 0);
                rareCount.Add("Skullpuncher", 0);
                rareCount.Add("Canfield Cleaver", 0);
                rareCount.Add("Tusked Axe of Ayan Baqur", 0);
                rareCount.Add("Pitfighter's Edge", 0);
                rareCount.Add("Zharalim Crookblade", 0);
                rareCount.Add("Dripping Death", 0);
                rareCount.Add("Champion's Demise", 0);
                rareCount.Add("Squire's Glaive", 0);
                rareCount.Add("Tri-Blade Spear", 0);
                rareCount.Add("Death's Grip Staff", 0);
                rareCount.Add("Defiler of Milantos", 0);
                rareCount.Add("Desert Wyrm", 0);
                rareCount.Add("Hevelio's Half-Moon", 0);
                rareCount.Add("Malachite Slasher", 0);
                rareCount.Add("Chitin Cracker", 0);
                rareCount.Add("Decapitator's Blade", 0);
                rareCount.Add("Itaka's Naginata", 0);
                rareCount.Add("Revenant's Scythe", 0);
                rareCount.Add("Spear of Lost Truths", 0);
                rareCount.Add("Black Cloud Bow", 0);
                rareCount.Add("Corsair's Arc", 0);
                rareCount.Add("Dragonspine Bow", 0);
                rareCount.Add("Ebonwood Shortbow", 0);
                rareCount.Add("Serpent's Flight", 0);
                rareCount.Add("Assassin's Whisper", 0);
                rareCount.Add("Feathered Razor", 0);
                rareCount.Add("Iron Bull", 0);
                rareCount.Add("Zefir's Breath", 0);
                rareCount.Add("Bloodmark Crossbow", 0);
                rareCount.Add("Drifter's Atlatl", 0);
                rareCount.Add("Hooded Serpent Slinger", 0);
                rareCount.Add("Huntsman's Dart-Thrower", 0);
                rareCount.Add("Dart Flicker", 0);
                rareCount.Add("Royal Ladle", 0);
                rareCount.Add("Deru Limb", 0);
                rareCount.Add("Eye of Muramm", 0);
                rareCount.Add("Orb of the Ironsea", 0);
                rareCount.Add("Wand of the Frore Crystal", 0);
                rareCount.Add("Wings of Rakhil", 0);
                rareCount.Add("Heart of Darkest Flame", 0);
            }
            catch(Exception e)
            {
                Util.WriteToChat("ERROR" + e.Message);
            }
           
        }

        public SortedDictionary<string, int> getList()
        {
            
            return rareCount;
        }

        public void UpdateCount(string name, int value)
        {
            rareCount[name] += value;
        }

        public void SetValue(string name, int value)
        {
            rareCount[name] = value;
        }

        public void resetCounts()
        {
            foreach (KeyValuePair<string, int> entry in rareCount)
            {
                rareCount[entry.Key] = 0;
            }
        }

        public SortedDictionary<string, int> getNonZeros()
        {
            SortedDictionary<string, int> temp = new SortedDictionary<string, int>();
            foreach (KeyValuePair<string, int> entry in rareCount)
            {
                if (entry.Value != 0)
                    temp.Add(entry.Key, entry.Value);
            }

            return temp;
        }

    }
}
