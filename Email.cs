using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace RareHunter
{
    class Email
    {
        public MailAddress mailAddress;
        public string email, host, password;
        public int port;
        public bool enabless1;

        public string subject, body;

        public Email(string email, string host, int port, bool enabless1, string password)
        {
            this.email = email;
            this.password = password;
            this.host = host;
            this.port = port;
            this.enabless1 = enabless1;
        }

        public void sendEmail(string subject, string body)
        {
            this.subject = subject;
            this.body = body;
            Thread send = new Thread(threadSend);
            send.Start();
        }

        public void threadSend()
        {
            try
            {
                mailAddress = new MailAddress(email, "Rare Hunter");
                string fromPassword = password;

                var smtp = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enabless1,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(mailAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(mailAddress, mailAddress)
                {
                    Subject = this.subject,
                    Body = this.body
                })
                {
                    smtp.Send(message);
                    RareHunter.emailSending = false;
                }
            }
            catch (Exception e)
            {
                Util.WriteToChat("ERROR SENDING EMAIL. PLEASE CHECK YOUR SETTINGS!");
            }

            return;
        }
    }
}
