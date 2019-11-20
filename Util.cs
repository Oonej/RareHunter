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

        public static void SaveIni(bool sendemail, string email, string password, string host, int port, bool ss1, bool senddiscord, string discordurl)
        {
            try
            {
                string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(assemblyFolder, "rarehunter.ini");

                if(!File.Exists(filePath))
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
                        writer.Close();
                    }
                }

                string[] lines = File.ReadAllLines(filePath);

                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (string line in lines)
                    {
                        if(line.Contains("sendemail:"))
                        {
                            writer.WriteLine("sendemail:" + sendemail);
                        }
                        else if (line.Contains("email:"))
                        {
                            writer.WriteLine("email:" + email);
                        }
                        else if (line.Contains("password:"))
                        {
                            writer.WriteLine("password:" + password);
                        }
                        else if (line.Contains("host:"))
                        {
                            writer.WriteLine("host:" + host);
                        }
                        else if (line.Contains("port:"))
                        {
                            writer.WriteLine("port:" + port);
                        }
                        else if (line.Contains("ss1:"))
                        {
                            writer.WriteLine("ss1:" + ss1);
                        }
                        else if (line.Contains("discordenable:"))
                        {
                            writer.WriteLine("discordenable:" + senddiscord);
                        }
                        else if (line.Contains("discordurl:"))
                        {
                            writer.WriteLine("discordurl:" + discordurl);
                        }
                    }
                }

                WriteToChat("Email Settings Saved to rarehunter.ini");
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
                SaveIni(false, "", "", "", 0, false, false, "");

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
