using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.IO;
using System.Collections.Specialized;

namespace RareHunter
{
    class Discord
    {
        public string msg, url;

        public string subject, body;

        public Discord(string url)
        {
            this.url = url;
        }

        public void sendMsg(string msg)
        {
            this.msg = msg;
            Thread send = new Thread(threadSend);
            send.Start();
        }

        public void threadSend()
        {
            try
            {
                if(!this.url.Trim().Equals(""))
                {
                    Post(this.url, new NameValueCollection()
                    {
                        { "username", "Rare Hunter" },
                        { "avatar_url", "http://acpedia.org/images/0/0d/Pack_%28Rare%29_Icon.png" },
                        { "content", this.msg }
                    });

                    RareHunter.discordSending = false;
                }
                
            }
            catch (Exception e)
            {
                Util.LogError(e);
                Util.WriteToChat("ERROR TESTING DISCORD");
            }

            return;
        }

        public static byte[] Post(string uri, NameValueCollection pairs)
        {
            using (WebClient webClient = new WebClient())
            {
                return webClient.UploadValues(uri, pairs);
            }
        }
    }
}
