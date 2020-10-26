using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using EASendMail;

namespace assist_purchase.Controllers
{
    class OutlookMailHandler
    {
        public String SendMail(String emailReceivers, String subject, String body, String fileName = "")
        {
            try
            {
                String[] emailreceivers = emailReceivers.Split(";");
                for (int i = 0; i < emailreceivers.Length; i++)
                {
                    SmtpMail oMail = new SmtpMail("TryIt");
                
                    // Your email address
                    oMail.From = "mayank.ranjan@philips.com";

                    // Set recipient email address
                    oMail.To = emailreceivers[i];

                    // Set email subject
                    oMail.Subject = subject;

                    // Set email body
                    oMail.TextBody = body;

                    // Hotmail/Outlook SMTP server address
                    SmtpServer oServer = new SmtpServer("smtp.live.com");

                    // If your account is office 365, please change to Office 365 SMTP server
                    // SmtpServer oServer = new SmtpServer("smtp.office365.com");

                    // User authentication should use your
                    // email address as the user name.
                    oServer.User = "mayank.ranjan@philips.com";
                    oServer.Password = "password";

                    // use 587 TLS port
                    oServer.Port = 587;

                    // detect SSL/TLS connection automatically
                    oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                    SmtpClient oSmtp = new SmtpClient();
                    oSmtp.SendMail(oServer, oMail);  
                }
                return "True";
          
            }
            catch (Exception ep)
            {
                
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
                return ep.Message;
            }
        }

       
    }
}
