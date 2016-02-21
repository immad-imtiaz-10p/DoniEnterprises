using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace de_server.App_Config
{

    public class emailManager
    {
        public static string emailTemplate = "/App_Config/emailTemplate/emailtemplate.html";

        public static string populateEmailBody(string userName, string title, string description)
        {
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            String body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(emailManager.emailTemplate)))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Url}", WebConfigurationManager.AppSettings["loginUrl"]);
            body = body.Replace("{Description}", description);
            return body;
        }
        public static void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(WebConfigurationManager.AppSettings["onRegistrationSendEmail"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                var client = new SmtpClient(WebConfigurationManager.AppSettings["Host"], int.Parse(WebConfigurationManager.AppSettings["Port"]))
                {
                    Credentials = new NetworkCredential(WebConfigurationManager.AppSettings["onRegistrationSendEmail"], WebConfigurationManager.AppSettings["Password"]),
                    EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"])
                };
                client.Send(mailMessage);
            }
        }
    }
}