using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace RareHunter
{
	public static class Util
	{
		public static void LogError(Exception ex)
		{
			try
			{
				using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Asheron's Call\" + Globals.PluginName + " errors.txt", true))
				{
					writer.WriteLine("============================================================================");
					writer.WriteLine(DateTime.Now.ToString());
					writer.WriteLine("Error: " + ex.Message);
					writer.WriteLine("Source: " + ex.Source);
					writer.WriteLine("Stack: " + ex.StackTrace);
					if (ex.InnerException != null)
					{
						writer.WriteLine("Inner: " + ex.InnerException.Message);
						writer.WriteLine("Inner Stack: " + ex.InnerException.StackTrace);
					}
					writer.WriteLine("============================================================================");
					writer.WriteLine("");
					writer.Close();
				}
			}
			catch
			{
			}
		}

        public static void ExportCSV(string[] data, bool export)
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(assemblyFolder, Globals.Core.CharacterFilter.Id + "_" + Globals.Core.CharacterFilter.Name.Replace(' ', '_') + "_data.csv");

            if (export)
            {
                assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                filePath = Path.Combine(assemblyFolder, Globals.Core.CharacterFilter.Id + "_" + Globals.Core.CharacterFilter.Name.Replace(' ', '_') + "_data.csv");
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (string s in data)
                    {
                        writer.WriteLine(s);
                    }
                    writer.Close();
                }
            }

        }

        public static List<string> ImportCSV()
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(assemblyFolder, Globals.Core.CharacterFilter.Id + "_" + Globals.Core.CharacterFilter.Name.Replace(' ', '_') + "_data.csv");

            List<string> temp = new List<string>();
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            else
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    temp.Add(line);
                }
            }
            return temp;
        }

		public static void WriteToChat(string message)
		{
			try
			{
				Globals.Host.Actions.AddChatText(Globals.PluginName + ": " + message, 5);
			}
			catch (Exception ex) { LogError(ex); }
		}

        public static void SaveIni(bool sendemail, string email, string password, string host, int port, bool ss1, bool senddiscord, string discordurl, bool t1, bool t2, bool t3, bool t4, bool t5, bool t6)
        {
            try
            {
                string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(assemblyFolder, "rarehunter.ini");

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();

                    using (StreamWriter writer = new StreamWriter(filePath, false))
                    {
                        writer.WriteLine("sendemail: ");
                        writer.WriteLine("email: ");
                        writer.WriteLine("password: ");
                        writer.WriteLine("host: ");
                        writer.WriteLine("port: ");
                        writer.WriteLine("ss1: ");
                        writer.WriteLine("discordenable: ");
                        writer.WriteLine("discordurl: ");
                        writer.WriteLine("tier: ");
                        writer.WriteLine("tier1:");
                        writer.WriteLine("tier2:");
                        writer.WriteLine("tier3:");
                        writer.WriteLine("tier4:");
                        writer.WriteLine("tier5:");
                        writer.WriteLine("tier6:");
                        writer.Close();
                    }
                }

                string[] lines = File.ReadAllLines(filePath);

                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine("sendemail:" + sendemail);
                    writer.WriteLine("email:" + email);
                    writer.WriteLine("password:" + password);
                    writer.WriteLine("host:" + host);
                    writer.WriteLine("port:" + port);
                    writer.WriteLine("ss1:" + ss1);
                    writer.WriteLine("discordenable:" + senddiscord);
                    writer.WriteLine("discordurl:" + discordurl);
                    writer.WriteLine("tier1:" + t1);
                    writer.WriteLine("tier2:" + t2);
                    writer.WriteLine("tier3:" + t3);
                    writer.WriteLine("tier4:" + t4);
                    writer.WriteLine("tier5:" + t5);
                    writer.WriteLine("tier6:" + t6);
                    WriteToChat("Email Settings Saved to rarehunter.ini");
                }
            }
            catch (Exception ex)
            {
                WriteToChat(ex.Message);
            }
        }

        internal static Dictionary<string, string> LoadSetttings()
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(assemblyFolder, "rarehunter.ini");
            Dictionary<string, string> temp = new Dictionary<string, string>();

            if (!File.Exists(filePath))
                SaveIni(false, "", "", "", 0, false, false, "", true, true, true, true, true, true);

            foreach(string line in File.ReadAllLines(filePath))
            {
                string[] templineinfo = line.Split(':');
                if (templineinfo.Length > 2)
                    temp.Add(templineinfo[0], templineinfo[1] + ":" + templineinfo[2]);
                else
                    temp.Add(templineinfo[0], templineinfo[1]);
            }

            return temp;
        }
    }
}
