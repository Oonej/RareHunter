using System;

using Decal.Adapter;
using Decal.Adapter.Wrappers;
using MyClasses.MetaViewWrappers;
using VirindiViewService.Controls;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Timers;

/*
 * Created by Mag-nus. 8/19/2011, VVS added by Virindi-Inquisitor.
 * 
 * No license applied, feel free to use as you wish. H4CK TH3 PL4N3T? TR45H1NG 0UR R1GHT5? Y0U D3C1D3!
 * 
 * Notice how I use try/catch on every function that is called or raised by decal (by base events or user initiated events like buttons, etc...).
 * This is very important. Don't crash out your users!
 * 
 * In 2.9.6.4+ Host and Core both have Actions objects in them. They are essentially the same thing.
 * You sould use Host.Actions though so that your code compiles against 2.9.6.0 (even though I reference 2.9.6.5 in this project)
 * 
 * If you add this plugin to decal and then also create another plugin off of this sample, you will need to change the guid in
 * Properties/AssemblyInfo.cs to have both plugins in decal at the same time.
 * 
 * If you have issues compiling, remove the Decal.Adapater and VirindiViewService references and add the ones you have locally.
 * Decal.Adapter should be in C:\Games\Decal 3.0\
 * VirindiViewService should be in C:\Games\VirindiPlugins\VirindiViewService\
*/

namespace RareHunter
{
    //Attaches events from core
    [WireUpBaseEvents]

    //View (UI) handling
    [MVView("RareHunter.mainView.xml")]
    [MVWireUpControlEvents]


    // FriendlyName is the name that will show up in the plugins list of the decal agent (the one in windows, not in-game)
    // View is the path to the xml file that contains info on how to draw our in-game plugin. The xml contains the name and icon our plugin shows in-game.
    // The view here is SamplePlugin.mainView.xml because our projects default namespace is SamplePlugin, and the file name is mainView.xml.
    // The other key here is that mainView.xml must be included as an embeded resource. If its not, your plugin will not show up in-game.
    [FriendlyName("RareHunter")]
    public class RareHunter : PluginBase
    {
        private ChatMessages cm = new ChatMessages();
        private static Email EmailSender;
        private static Discord DiscordSender;
        private VirindiViewService.ViewProperties properties;
        private VirindiViewService.ControlGroup controls;
        private VirindiViewService.HudView view;
        public HudTabView TabView { get; private set; }

        public HudStaticText killrate { get; private set; }
        int killValue = 0;

        public HudStaticText time { get; private set; }
        string timeValue;

        public HudStaticText killshr { get; private set; }
        double killshrValue = 0.0;

        public HudStaticText rares { get; private set; }
        int raresValue = 0;

        public HudStaticText totalInvRares { get; private set; }

        public HudButton broadcaststats { get; private set; }
        public HudButton broadcaststatsa { get; private set; }
        public HudButton broadcaststatsf { get; private set; }
        public HudButton refreshRares { get; private set; }
        public HudButton resetstats { get; private set; }
        public HudButton saveEmail { get; private set; }
        public HudButton saveDiscord { get; private set; }

        public HudList raresFound { get; private set; }
        public HudList totalRares { get; private set; }

        public HudTextBox email { get; private set; }
        public HudTextBox pass { get; private set; }
        public HudTextBox port { get; private set; }
        public HudTextBox host { get; private set; }
        public HudCheckBox ss1 { get; private set; }
        public HudCheckBox sendemail { get; private set; }
        public HudCheckBox discordwebhook { get; private set; }

        public HudButton testEmail { get; private set; }
        public HudButton testDiscord { get; private set; }
        public HudTextBox discordurl { get; private set; }

        public HudButton exportHistory { get; private set; }
        public HudButton resetHistory { get; private set; }

        public HudCheckBox tier1cb { get; private set; }
        public HudCheckBox tier2cb { get; private set; }
        public HudCheckBox tier3cb { get; private set; }
        public HudCheckBox tier4cb { get; private set; }
        public HudCheckBox tier5cb { get; private set; }
        public HudCheckBox tier6cb { get; private set; }

        public HudCheckBox showAllCB { get; private set; }

        readonly Timer timer = new Timer();
        public TimeSpan timeSpan = new TimeSpan(0, 0, 0);
        public double updateRate = 100;

        public bool SendEmail = false;
        public bool SendDiscord = false;
        public static bool discordSending = false;
        public static bool emailSending = false;
        public static bool addingToList = false;
        public int killssincelast = 0;

        public RareList rl;
        /// <summary>
        /// This is called when the plugin is started up. This happens only once.
        /// </summary>
        protected override void Startup()
		{
			try
			{
				// This initializes our static Globals class with references to the key objects your plugin will use, Host and Core.
				// The OOP way would be to pass Host and Core to your objects, but this is easier.
				Globals.Init("RareHunter", Host, Core);

                CoreManager.Current.ChatBoxMessage += new EventHandler<ChatTextInterceptEventArgs>(Current_ChatBoxMessage);
                timer.Interval = updateRate;
                timer.Elapsed += new ElapsedEventHandler(UpdateTime);
                timer.Enabled = true;
                timer.Start();

                rl = new RareList();

                LoadWindow();
                LoadEmailSettings();
                GenerateLists();
                
                EmailSender = new Email(email.Text, host.Text, int.Parse(port.Text), ss1.Checked, pass.Text);
                DiscordSender = new Discord(discordurl.Text);
            }
			catch (Exception ex) { Util.LogError(ex); }
		}

        private void UpdateTime(object sender, ElapsedEventArgs e)
        {
            timeSpan = timeSpan.Add(TimeSpan.FromMilliseconds(updateRate));
            time.Text = String.Format("{0}d, {1}h, {2}m, {3}s", timeSpan.Duration().Days, timeSpan.Duration().Hours, timeSpan.Duration().Minutes, timeSpan.Duration().Seconds);
            killshr.Text = String.Format("{0} kills/hr", (int)(killValue / timeSpan.TotalHours));
        }

        private void Current_ChatBoxMessage(object sender, ChatTextInterceptEventArgs e)
        {
            try
            {
                if (ChatMessages.IsKilledByMeMessage(e.Text))
                {
                    foreach (Regex regex in ChatMessages.TargetKilledByMe)
                    {
                        Match match = regex.Match(e.Text);

                        if (match.Success)
                        {
                            killValue++;
                            killrate.Text = killValue + "";
                            break;
                        }
                    }
                }
                else if (ChatMessages.IsRareFindMessage(e.Text))
                {
                    string rareName = "";
                    foreach (Regex regex in ChatMessages.RareFind)
                    {
                        Match match = regex.Match(e.Text);

                        if (match.Success && match.Groups["targetname"].Value.Equals(Core.CharacterFilter.Name))
                        {
                            raresValue++;
                            rares.Text = raresValue + "";

                            int killstoObtain = killValue - killssincelast;
                            killssincelast = killValue;
                            string playerName = match.Groups["targetname"].Value;

                            rareName = match.Groups["rarename"].Value;

                            if (!addingToList)
                            {
                                addingToList = true;
                                HudList.HudListRowAccessor testRow = raresFound.InsertRow(0);
                                ((HudStaticText)testRow[0]).Text = raresFound.RowCount + "";
                                ((HudStaticText)testRow[1]).Text = rareName;
                                ((HudStaticText)testRow[2]).Text = killstoObtain + "";
                                ((HudStaticText)testRow[3]).Text = DateTime.Now.ToShortTimeString();
                                ((HudStaticText)testRow[4]).Text = DateTime.Today.ToString("MM/dd/yy");

                                string[] export = new string[raresFound.RowCount];
                                int count = 0;
                                for (int i = raresFound.RowCount - 1; i >= 0; i--)
                                {
                                    export[count] = ((HudStaticText)raresFound[i][0]).Text + "," + ((HudStaticText)raresFound[i][1]).Text + "," + ((HudStaticText)raresFound[i][2]).Text + "," + ((HudStaticText)raresFound[i][3]).Text + "," + ((HudStaticText)raresFound[i][4]).Text;
                                    count++;
                                }

                                Util.ExportCSV(export, false);

                                addingToList = false;
                            }

                            if (rareName != "" && tierActive(rareName.Replace('!', ' ').Trim()))
                            {
                                //IF FOUND RARE : SEND EMAIL
                                if (SendEmail && !emailSending)
                                {
                                    emailSending = true;
                                    EmailSender.sendEmail("NEW RARE! " + rareName, Core.CharacterFilter.Name + " has discovered the " + rareName);
                                }

                                //IF FOUND RARE : SEND DISCORD
                                if (SendDiscord && !discordSending)
                                {
                                    discordSending = true;
                                    DiscordSender.sendMsg(Core.CharacterFilter.Name + " has discovered the " + rareName);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Util.WriteToChat("x Error: " + ex.Message + "\n " + ex.Source + "\n " + ex.StackTrace);
            }
            
        }

        private bool tierActive(string name)
        {
            if(rl.rareCount.ContainsKey(name))
            {
                switch(rl.rareCount[name].tier)
                {
                    case 1:
                        return tier1cb.Checked;
                    case 2:
                        return tier2cb.Checked;
                    case 3:
                        return tier3cb.Checked;
                    case 4:
                        return tier4cb.Checked;
                    case 5:
                        return tier5cb.Checked;
                    case 6:
                        return tier6cb.Checked;
                    default:
                        return false;
                }
            }
            else
            {
                Util.WriteToChat("Could not find rare " + name + ". Please report to Invisible Fire on RC ");
                return false;
            }
        }

        private void LoadWindow()
        {
            // Create the view
            VirindiViewService.XMLParsers.Decal3XMLParser parser = new VirindiViewService.XMLParsers.Decal3XMLParser();
            parser.ParseFromResource("RareHunter.mainView.xml", out properties, out controls);
            view = new VirindiViewService.HudView(properties, controls);

            TabView = view != null ? (HudTabView)view["nbMain"] : new HudTabView();

            killrate = view != null ? (HudStaticText)view["killrate"] : new HudStaticText();
            time = view != null ? (HudStaticText)view["time"] : new HudStaticText();
            killshr = view != null ? (HudStaticText)view["killshr"] : new HudStaticText();
            rares = view != null ? (HudStaticText)view["rares"] : new HudStaticText();
            totalInvRares = view != null ? (HudStaticText)view["totalInvRares"] : new HudStaticText();

            broadcaststats = view != null ? (HudButton)view["broadcaststats"] : new HudButton();
            broadcaststats.Hit += new EventHandler(BroadCastMessage);

            broadcaststatsa = view != null ? (HudButton)view["broadcaststatsa"] : new HudButton();
            broadcaststatsa.Hit += new EventHandler(BroadCastMessagea);

            broadcaststatsf = view != null ? (HudButton)view["broadcaststatsf"] : new HudButton();
            broadcaststatsf.Hit += new EventHandler(BroadCastMessagef);

            refreshRares = view != null ? (HudButton)view["refreshRares"] : new HudButton();
            refreshRares.Hit += new EventHandler(CharacterFilter_LoginComplete);

            resetstats = view != null ? (HudButton)view["resetstats"] : new HudButton();
            resetstats.Hit += new EventHandler(ResetStats);

            resetHistory = view != null ? (HudButton)view["resetHistory"] : new HudButton();
            resetHistory.Hit += new EventHandler(resetHistoryEvent);

            exportHistory = view != null ? (HudButton)view["exportHistory"] : new HudButton();
            exportHistory.Hit += new EventHandler(exporthistoryEvent);

            email = view != null ? (HudTextBox)view["emailValue"] : new HudTextBox();
            pass = view != null ? (HudTextBox)view["passwordValue"] : new HudTextBox();
            port = view != null ? (HudTextBox)view["portValue"] : new HudTextBox();
            host = view != null ? (HudTextBox)view["hostValue"] : new HudTextBox();
            ss1 = view != null ? (HudCheckBox)view["enableSS1Value"] : new HudCheckBox();

            showAllCB = view != null ? (HudCheckBox)view["showAll"] : new HudCheckBox();
            showAllCB.Change += new EventHandler(toggleShowAll);

            raresFound = view != null ? (HudList)view["raresFound"] : new HudList();
            totalRares = view != null ? (HudList)view["inventoryRares"] : new HudList();

            sendemail = view != null ? (HudCheckBox)view["sendEmailValue"] : new HudCheckBox();
            sendemail.Change += new EventHandler(SendEmailChanged);

            testEmail = view != null ? (HudButton)view["testEmail"] : new HudButton();
            testEmail.Hit += new EventHandler(TestEmail);

            saveEmail = view != null ? (HudButton)view["emailSave"] : new HudButton();
            saveEmail.Hit += new EventHandler(SaveEmailSettings);

            saveDiscord = view != null ? (HudButton)view["discordSave"] : new HudButton();
            saveDiscord.Hit += new EventHandler(SaveEmailSettings);

            testDiscord = view != null ? (HudButton)view["testDiscord"] : new HudButton();
            testDiscord.Hit += new EventHandler(TestDiscord);
            discordwebhook = view != null ? (HudCheckBox)view["discordWebhookValue"] : new HudCheckBox();
            discordwebhook.Change += new EventHandler(SendDiscordHookChanged);

            discordurl = view != null ? (HudTextBox)view["discordWebhookURLValue"] : new HudTextBox();

            tier1cb = view != null ? (HudCheckBox)view["notifytier1"] : new HudCheckBox();
            tier1cb.Change += new EventHandler(SaveEmailSettings);

            tier2cb = view != null ? (HudCheckBox)view["notifytier2"] : new HudCheckBox();
            tier2cb.Change += new EventHandler(SaveEmailSettings);

            tier3cb = view != null ? (HudCheckBox)view["notifytier3"] : new HudCheckBox();
            tier3cb.Change += new EventHandler(SaveEmailSettings);

            tier4cb = view != null ? (HudCheckBox)view["notifytier4"] : new HudCheckBox();
            tier4cb.Change += new EventHandler(SaveEmailSettings);

            tier5cb = view != null ? (HudCheckBox)view["notifytier5"] : new HudCheckBox();
            tier5cb.Change += new EventHandler(SaveEmailSettings);

            tier6cb = view != null ? (HudCheckBox)view["notifytier6"] : new HudCheckBox();
            tier6cb.Change += new EventHandler(SaveEmailSettings);
        }

        private void exporthistoryEvent(object sender, EventArgs e)
        {
            string[] export = new string[raresFound.RowCount];
            int count = 0;
            for(int i = raresFound.RowCount - 1; i >= 0; i--)
            {
                export[count] = ((HudStaticText)raresFound[i][0]).Text + "," + ((HudStaticText)raresFound[i][1]).Text + "," + ((HudStaticText)raresFound[i][2]).Text + "," + ((HudStaticText)raresFound[i][3]).Text + "," + ((HudStaticText)raresFound[i][4]).Text;
                count++;
            }

            Util.ExportCSV(export, true);
        }

        private void resetHistoryEvent(object sender, EventArgs e)
        {
            raresFound.ClearRows();

            string[] export = new string[raresFound.RowCount];
            int count = 0;
            for (int i = raresFound.RowCount - 1; i >= 0; i--)
            {
                export[count] = ((HudStaticText)raresFound[i][0]).Text + "," + ((HudStaticText)raresFound[i][1]).Text + "," + ((HudStaticText)raresFound[i][2]).Text + "," + ((HudStaticText)raresFound[i][3]).Text + "," + ((HudStaticText)raresFound[i][4]).Text;
                count++;
            }

            Util.ExportCSV(export, false);
        }

        private void toggleShowAll(object sender, EventArgs e)
        {
            updateList(showAllCB.Checked);
        }

        private void TestEmail(object sender, EventArgs e)
        {
            EmailSender.sendEmail("TEST! ", "THIS IS A TEST EMAIL");
        }

        private void TestDiscord(object sender, EventArgs e)
        {
            DiscordSender.sendMsg("Test");
        }

        private void SendEmailChanged(object sender, EventArgs e)
        {
            if(sendemail.Checked)
            {
                SendEmail = true;
                sendemail.Checked = true;
                testEmail.Visible = true;
                email.UserChangeable = true;
                pass.UserChangeable = true;
                host.UserChangeable = true;
                port.UserChangeable = true;
                ss1.UserChangeable = true;
            }
            else
            {
                sendemail.Checked = false;
                SendEmail = false;
                testEmail.Visible = false;
                email.UserChangeable = false;
                pass.UserChangeable = false;
                host.UserChangeable = false;
                port.UserChangeable = false;
                ss1.UserChangeable = false;
            }
           
        }

        private void SendDiscordHookChanged(object sender, EventArgs e)
        {
            if(discordwebhook.Checked)
            {
                SendDiscord = true;
                discordurl.UserChangeable = true;
            }
            else
            {
                SendDiscord = false;
                discordurl.UserChangeable = false;
            }
        }

            private void ResetStats(object sender, EventArgs e)
        {
            timeSpan = TimeSpan.Zero;
            killValue = 0;
            killrate.Text = 0 + "";
            killshrValue = 0;
            killshr.Text = "0 kills/hr";
            raresValue = 0;
            rares.Text = 0 + "";
        }

        private void SaveEmailSettings(object sender, EventArgs e)
        {
            EmailSender = new Email(email.Text, host.Text, int.Parse(port.Text), ss1.Checked, pass.Text);
            DiscordSender = new Discord(discordurl.Text);
            Util.SaveIni(SendEmail, email.Text, pass.Text, host.Text, int.Parse(port.Text), ss1.Checked, discordwebhook.Checked, discordurl.Text, tier1cb.Checked, tier2cb.Checked, tier3cb.Checked, tier4cb.Checked, tier5cb.Checked, tier6cb.Checked);
        }

        private void BroadCastMessage(object sender, EventArgs e)
        {
            string temp = "";
            if (timeSpan.Duration().Days < 1)
            {
               temp  = String.Format("{0}h, {1}m, {2}s", timeSpan.Duration().Hours, timeSpan.Duration().Minutes, timeSpan.Duration().Seconds) + " at a rate of " + (int)(killValue / timeSpan.Duration().TotalHours) + " / hour and discovered " + raresValue + " rares!";
            }
            else
            {
                temp = String.Format("{0}d, {1}h, {2}m, {3}s", timeSpan.Duration().Days, timeSpan.Duration().Hours, timeSpan.Duration().Minutes, timeSpan.Duration().Seconds) + " at a rate of " + (int)(killValue / timeSpan.Duration().TotalHours) + " / hour and discovered " + raresValue + " rares!";
            }
           
            Util.WriteToChat("You have killed " + killValue + " creatures in " + temp);
        }

        private void BroadCastMessagea(object sender, EventArgs e)
        {
            string temp = "";
            if (timeSpan.Duration().Days < 1)
            {
                temp = String.Format("{0}h, {1}m, {2}s", timeSpan.Duration().Hours, timeSpan.Duration().Minutes, timeSpan.Duration().Seconds) + " at a rate of " + (int)(killValue / timeSpan.Duration().TotalHours) + " / hour and discovered " + raresValue + " rares!";
            }
            else
            {
                temp = String.Format("{0}d, {1}h, {2}m, {3}s", timeSpan.Duration().Days, timeSpan.Duration().Hours, timeSpan.Duration().Minutes, timeSpan.Duration().Seconds) + " at a rate of " + (int)(killValue / timeSpan.Duration().TotalHours) + " / hour and discovered " + raresValue + " rares!";
            }

            Core.Actions.InvokeChatParser("/a You have killed " + killValue + " creatures in " + temp);
        }

        private void BroadCastMessagef(object sender, EventArgs e)
        {
            string temp = "";
            if (timeSpan.Duration().Days < 1)
            {
                temp = String.Format("{0}h, {1}m, {2}s", timeSpan.Duration().Hours, timeSpan.Duration().Minutes, timeSpan.Duration().Seconds) + " at a rate of " + (int)(killValue / timeSpan.Duration().TotalHours) + " / hour and discovered " + raresValue + " rares!";
            }
            else
            {
                temp = String.Format("{0}d, {1}h, {2}m, {3}s", timeSpan.Duration().Days, timeSpan.Duration().Hours, timeSpan.Duration().Minutes, timeSpan.Duration().Seconds) + " at a rate of " + (int)(killValue / timeSpan.Duration().TotalHours) + " / hour and discovered " + raresValue + " rares!";
            }

            Core.Actions.InvokeChatParser("/f You have killed " + killValue + " creatures in " + temp);
        }

        private void RefreshRaresButtonClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This is called when the plugin is shut down. This happens only once.
        /// </summary>
        protected override void Shutdown()
		{
			try
			{
                timer.Stop();
                //Destroy the view.
                MVWireupHelper.WireupEnd(this);
			}
			catch (Exception ex) { Util.LogError(ex); }
		}

		[BaseEvent("LoginComplete", "CharacterFilter")]
		private void CharacterFilter_LoginComplete(object sender, EventArgs e)
		{
			try
			{
                string[] keys = new string[rl.getList().Count];
                rl.getList().Keys.CopyTo(keys, 0);
                for (int i = 0; i < rl.rareCount.Count; i++)
                {
                    rl.SetValue(keys[i], 0);
                }

                //update rare list from inventory
                WorldObjectCollection woc = Core.WorldFilter.GetInventory();
                foreach (WorldObject wo in woc)
                {
                    if (rl.getList().ContainsKey(wo.Name))
                    {
                        if (wo.Values(LongValueKey.StackCount) > 0)
                        {
                            rl.rareCount[wo.Name].count += wo.Values(LongValueKey.StackCount);
                        }
                        else
                        {
                            if(wo.Name.Equals("Pack"))
                            {
                                if (wo.Values(LongValueKey.RareId) != 0)
                                    rl.rareCount[wo.Name].count += 1;
                            }
                            else
                            {
                                rl.rareCount[wo.Name].count += 1;
                            }
                        }
                    }
                }

                showAllCB.Checked = false;
                updateList(false);
                loadCSV();
            }
			catch (Exception ex) { Util.LogError(ex); }
		}

        private void loadCSV()
        {
            raresFound.ClearRows();
            List<string> temp = Util.ImportCSV();

            HudList.HudListRowAccessor testRow2 = raresFound.InsertRow(0);

            foreach (string s in temp)
            {
                string[] split = s.Split(',');
                HudList.HudListRowAccessor testRow = raresFound.InsertRow(0);
                ((HudStaticText)testRow[0]).Text = split[0] + "";
                ((HudStaticText)testRow[1]).Text = split[1].Replace('!', ' ').Trim() + "";
                ((HudStaticText)testRow[2]).Text = split[2] + "";
                ((HudStaticText)testRow[3]).Text = split[3] + "";

                if (split.Length == 5)
                    ((HudStaticText)testRow[4]).Text = split[4] + "";
                else
                    ((HudStaticText)testRow[4]).Text = DateTime.Today.ToString("MM/dd/yy");
            }
        }

        private void updateList(bool showAll)
        {
            totalRares.ClearRows();
            if (!showAll)
            {
                foreach (KeyValuePair<string, int> entry in rl.getNonZeros())
                {
                    HudList.HudListRowAccessor newRow = totalRares.AddRow();
                    ((HudStaticText)newRow[0]).Text = entry.Key;
                    ((HudStaticText)newRow[1]).Text = $"{entry.Value}";
                }
            }
            else
            {
                foreach (KeyValuePair<string, RareItem> entry in rl.getList())
                {
                    HudList.HudListRowAccessor newRow = totalRares.AddRow();
                    ((HudStaticText)newRow[0]).Text = entry.Key;
                    ((HudStaticText)newRow[1]).Text = $"{entry.Value.count}";
                }
            }

            int count = 0;
            foreach(KeyValuePair<string, RareItem> entry in rl.getList())
            {
                count += entry.Value.count;
            }

            totalInvRares.Text = "Total Rares: " + count;

        }

        [BaseEvent("Logoff", "CharacterFilter")]
        private void CharacterFilter_Logoff(object sender, Decal.Adapter.Wrappers.LogoffEventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { Util.LogError(ex); }
        }

        private void LoadEmailSettings()
        {
            Dictionary<string, string> emailsettings = Util.LoadSetttings();
            if (emailsettings.ContainsKey("sendemail") && emailsettings["sendemail"] != " " && emailsettings["sendemail"] != "")
            {
                sendemail.Checked = bool.Parse(emailsettings["sendemail"]);
                SendEmail = bool.Parse(emailsettings["sendemail"]);
            }

            if (emailsettings.ContainsKey("email") && emailsettings["email"] != " " && emailsettings["email"] != "")
            {
                email.Text = emailsettings["email"];
            }

            if (emailsettings.ContainsKey("password") && emailsettings["password"] != " " && emailsettings["password"] != "")
            {
                pass.Text = emailsettings["password"];
            }

            if (emailsettings.ContainsKey("host") && emailsettings["host"] != " " && emailsettings["host"] != "")
            {
                host.Text = emailsettings["host"];
            }

            if (emailsettings.ContainsKey("port") && emailsettings["port"] != " " && emailsettings["port"] != "")
            {
                port.Text = emailsettings["port"];
            }

            if (emailsettings.ContainsKey("ss1") && emailsettings["ss1"] != " " && emailsettings["ss1"] != "")
            {
                ss1.Checked = bool.Parse(emailsettings["ss1"]);
            }

            if (emailsettings.ContainsKey("discordenable") && emailsettings["discordenable"] != " " && emailsettings["discordenable"] != "")
            {
                SendDiscord = bool.Parse(emailsettings["discordenable"]);
                discordwebhook.Checked = bool.Parse(emailsettings["discordenable"]);
            }

            if (emailsettings.ContainsKey("discordurl") && emailsettings["discordurl"] != " " && emailsettings["discordurl"] != "")
            {
                discordurl.Text = emailsettings["discordurl"];
            }

            if (emailsettings.ContainsKey("tier1") && emailsettings["tier1"] != " " && emailsettings["tier1"] != "")
            {
                tier1cb.Checked = bool.Parse(emailsettings["tier1"]);
            }

            if (emailsettings.ContainsKey("tier2") && emailsettings["tier2"] != " " && emailsettings["tier2"] != "")
            {
                tier2cb.Checked = bool.Parse(emailsettings["tier2"]);
            }

            if (emailsettings.ContainsKey("tier3") && emailsettings["tier3"] != " " && emailsettings["tier3"] != "")
            {
                tier3cb.Checked = bool.Parse(emailsettings["tier3"]);
            }

            if (emailsettings.ContainsKey("tier4") && emailsettings["tier4"] != " " && emailsettings["tier4"] != "")
            {
                tier4cb.Checked = bool.Parse(emailsettings["tier4"]);
            }

            if (emailsettings.ContainsKey("tier5") && emailsettings["tier5"] != " " && emailsettings["tier5"] != "")
            {
                tier5cb.Checked = bool.Parse(emailsettings["tier5"]);
            }

            if (emailsettings.ContainsKey("tier6") && emailsettings["tier6"] != " " && emailsettings["tier6"] != "")
            {
                tier6cb.Checked = bool.Parse(emailsettings["tier6"]);
            }
        }

        public void GenerateLists()
        {
            raresFound.AddColumn(typeof(HudStaticText), 15, "#");
            raresFound.AddColumn(typeof(HudStaticText), 105, "name");
            raresFound.AddColumn(typeof(HudStaticText), 35, "killssincelast");
            raresFound.AddColumn(typeof(HudStaticText), 50, "time");
            raresFound.AddColumn(typeof(HudStaticText), 45, "date");
            totalRares.AddColumn(typeof(HudStaticText), 250, "name");
            totalRares.AddColumn(typeof(HudStaticText), 20, "qty");
            
        }
	}
}
