using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

namespace RareHunter
{
    class ChatMessages
    {
        public static Collection<Regex> TargetKilledByMe = new Collection<Regex>();
        public static Collection<Regex> RareFind = new Collection<Regex>();

        public ChatMessages()
        {
            RareFind.Add(new Regex("(?<targetname>.+) has discovered the (?<rarename>.+)$"));

            // Wight Blade Sorcerer's seared corpse smolders before you! (Fire)
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+)'s seared corpse smolders before you!$"));
            // Wight is reduced to cinders! (Fire)
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+) is reduced to cinders!$"));
            // Old Bones is shattered by your assault!
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+) is shattered by your assault!$"));
            // Gnawer Shreth catches your attack, with dire consequences!
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+) catches your attack, with dire consequences!$"));
            // Gnawer Shreth is utterly destroyed by your attack!
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+) is utterly destroyed by your attack!$"));
            // Ruschk Laktar suffers a frozen fate! (Frost)
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+) suffers a frozen fate!$"));
            // Insatiable Eater's perforated corpse falls before you! (Pierce)
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+)'s perforated corpse falls before you!$"));
            // Insatiable Eater is fatally punctured! (Pierce)
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+) is fatally punctured!$"));
            // Insatiable Eater's death is preceded by a sharp, stabbing pain! (Pierce)
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+)'s death is preceded by a sharp, stabbing pain!$"));
            // Insatiable Eater is torn to ribbons by your assault! (Slash)
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+) is torn to ribbons by your assault!$"));
            // Insatiable Eater is liquified by your attack! (Acid)
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+) is liquified by your attack!$"));
            // Insatiable Eater's last strength dissolves before you! (Acid)
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+)'s last strength dissolves before you!$"));
            // Electricity tears Insatiable Eater apart! (Lightning)
            TargetKilledByMe.Add(new Regex("^Electricity tears (?<targetname>.+) apart!$"));
            // Blistered by lightning, Insatiable Eater falls! (Lightning)
            TargetKilledByMe.Add(new Regex("^Blistered by lightning, (?<targetname>.+) falls!$"));
            // ____'s last strength withers before you! (Nether)
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+)'s last strength withers before you!$"));
            // ____ is dessicated by your attack! (Nether)
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+) is dessicated by your attack!$"));
            // ____ is incinerated by your assault! (Fire)
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+) is incinerated by your assault!$"));
            // ____ to a drained, twisted corpse!
            TargetKilledByMe.Add(new Regex("^You reduce (?<targetname>.+) to a drained, twisted corpse!$"));
            //You obliterate Olthoi Swarm Noble!
            TargetKilledByMe.Add(new Regex("^You obliterate (?<targetname>.+)!$"));

            //You beat Olthoi Swarm Eviscerator to a lifeless pulp!
            TargetKilledByMe.Add(new Regex("^You beat (?<targetname>.+) to a lifeless pulp!$"));
            //You flatten Olthoi Swarm Soldier's body with the force of your assault!
            TargetKilledByMe.Add(new Regex("^You flatten (?<targetname>.+)'s body with the force of your assault!$"));
            //The thunder of crushing Olthoi Swarm Noble is followed by the deafening silence of death!
            TargetKilledByMe.Add(new Regex("^The thunder of crushing (?<targetname>.+) is followed by the deafening silence of death!$"));
            //Olthoi Swarm Noble is utterly destroyed by your attack!
            TargetKilledByMe.Add(new Regex("^(?<targetname>.+) is utterly destroyed by your attack!$"));
            //Olthoi Swarm Noble is utterly destroyed by your attack!
            TargetKilledByMe.Add(new Regex("^You smite (?<targetname>.+) mightily!$"));
            //You bring Terebrous Hollow Minion to a fiery end!
            TargetKilledByMe.Add(new Regex("^You bring (?<targetname>.+) to a fiery end!$"));
            //You slay Rampager viciously enough to impart death several times over!
            TargetKilledByMe.Add(new Regex("^You slay (?<targetname>.+) viciously enough to impart death several times over!$"));

            TargetKilledByMe.Add(new Regex("^The deadly force of your attack is so strong that (?<targetname>.+)'s ancestors feel it!$"));
            TargetKilledByMe.Add(new Regex("^You cleave (?<targetname>.+) in twain!$"));
            TargetKilledByMe.Add(new Regex("^You killed (?<targetname>.+)!$"));
            TargetKilledByMe.Add(new Regex("^You knock (?<targetname>.+) into next Morningthaw!$"));
            TargetKilledByMe.Add(new Regex("^You reduce (?<targetname>.+) to a sizzling, oozing mass!$"));
            TargetKilledByMe.Add(new Regex("^You run (?<targetname>.+) through!$"));
            TargetKilledByMe.Add(new Regex("^You split (?<targetname>.+) apart!$"));
            TargetKilledByMe.Add(new Regex("^Your assault sends (?<targetname>.+) to an icy death!$"));
            TargetKilledByMe.Add(new Regex("^Your attack stops (?<targetname>.+) cold!$"));
            TargetKilledByMe.Add(new Regex("^Your killing blow nearly turns (?<targetname>.+) inside-out!$"));
            TargetKilledByMe.Add(new Regex("^Your lightning coruscates over (?<targetname>.+)'s mortal remains!$"));
        }

        public static bool IsKilledByMeMessage(string text)
        {
            foreach (Regex regex in TargetKilledByMe)
            {
                if (regex.IsMatch(text))
                    return true;
            }

            return false;
        }

        public static bool IsRareFindMessage(string text)
        {
            foreach (Regex regex in RareFind)
            {
                if (regex.IsMatch(text))
                    return true;
            }

            return false;
        }

    }
}
