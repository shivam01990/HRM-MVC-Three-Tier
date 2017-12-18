using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HRMBLL
{
    public class MailUtil
    {
        public static async Task MailSend(string Heading, string username, string msg, ArrayList urltext, ArrayList urls, string EmailTo, string CCMails, string subject)
        {
            try
            {
                await MailSend(CreateEmailInFormat(Heading, username, msg, urltext, urls), AppSettings.NoReplyEmail, AppSettings.DisplayName, EmailTo, CCMails, subject);
            }
            catch
            {
            }
        }
        public static async Task MailSend(string Heading, string username, string msg, ArrayList urltext, ArrayList urls, string FromEmailId, string DisplayName, string EmailTo, string CCMails, string subject)
        {
            try
            {
                await MailSend(CreateEmailInFormat(Heading, username, msg, urltext, urls), FromEmailId, DisplayName, EmailTo, CCMails, subject);
            }
            catch
            {
            }
        }
        public static string CreateEmailInFormat(string Heading, string username, string msg, ArrayList urltext, ArrayList urls)
        {
            string SiteUrl = AppSettings.SiteURL;
            StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailFormats/email.html"));
            string readFile = reader.ReadToEnd();
            string EmailContent = GetEmailContentHtml(Heading, username, msg, urltext, urls);
            string EmailMessage = readFile.Replace("[SITEURL]", SiteUrl).Replace("[EMAILCONTENT]", EmailContent).Replace("[APPNAME]", AppSettings.AppName);
            return EmailMessage;
        }
        private static string GetEmailContentHtml(string Heading, string username, string msg, ArrayList urltext, ArrayList urls)
        {
            string SiteUrl = AppSettings.SiteURL;
            StringBuilder sb = new StringBuilder();

            sb.Append("<div style='width: 600px; margin: 0px auto; padding: 20px; height: auto; background: #FFFFFF;'>");
            sb.Append("<div style='clear: both'>");
            sb.Append("</div>");
            sb.Append("<div style='width: 600px; padding-top: 15px; margin-top: 15px; border-top: 1px solid #6e6e6e;'>");
            sb.Append("<div style='font-size: 16px; font-family: Arial, Helvetica, sans-serif; font-weight: bold;'>");
            sb.Append(("Hi " + (username + ",</div>")));
            sb.Append("<div style='font-size: 12px; font-family: Arial, Helvetica, sans-serif;'>");
            sb.Append(msg);
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("<div style='width: 600px;margin:15px 0px 15px 0px;padding-bottom:10px; font-size: 12px; font-family: " + "Arial, Helvetica, sans-serif;word-wrap: break-word;'>");
            for (int j = 0; j < urltext.Count; j++)
            {
                sb.Append((urltext[j].ToString() + "<br/>"));
                sb.Append("<a href='" + urls[j].ToString() + "' style='text-decoration: none; color: #375aa0;'  target='_blank'>" + urls[j].ToString() + "</a><br/>");
            }

            sb.Append("</div>");

            sb.Append("<div style='clear: both'>");
            sb.Append("</div>");
            sb.Append("<div style='width: 600px; padding-top: 10px; margin-top: 15px; border-top: 1px solid #6e6e6e;'>");
            sb.Append("<div style='width: 600px; word-wrap: break-word; font-family: Arial, Helvetica, sans-serif;font-size:" + " 12px;'>");

            sb.Append("<div style='clear: both'>");
            sb.Append("</div>");
            sb.Append(" <div style='padding-top: 20px; font-family: Arial, Helvetica, sans-serif; font-size: 12px;'>");
            sb.Append("Thanks For Using " + AppSettings.AppName + "!<br />");
            sb.Append("--The " + AppSettings.AppName + " Team<br />");
            sb.Append("<a href='" + SiteUrl + "' style='text-decoration: none; color: #375aa0;' target='_blank'>" + SiteUrl + "</a>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("<div style='clear: both'>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            return sb.ToString();
        }
        public static async Task MailSend(string temptextbody, string FromEmailId, string DisplayName, string EmailTo, string CCMails, string subject)
        {
            string networkCredentialUserName = "";
            string networkCredentialPassword = "";
            string networkCredentialDomain = "";
            try
            {
                try
                {
                    networkCredentialUserName = AppSettings.NetworkCredentialUserName;
                    networkCredentialPassword = AppSettings.NetworkCredentialPassword;
                    networkCredentialDomain = AppSettings.NetworkCredentialDomain;
                }
                catch (System.Exception e)
                {
                }
                MailMessage myMail = new MailMessage();
                myMail.From = new MailAddress(FromEmailId, DisplayName);
                if (CCMails != "")
                {
                    myMail.CC.Add(CCMails);
                }
                myMail.Subject = subject;
                myMail.To.Add(new MailAddress(EmailTo));
                myMail.Priority = MailPriority.High;
                //myMail.BodyFormat = MailFormat.Html;
                myMail.IsBodyHtml = true;
                myMail.Body = temptextbody;
                SmtpClient smtpMail = (AppSettings.Port == 0 ? new SmtpClient(AppSettings.SMTPServer) : new SmtpClient(AppSettings.SMTPServer, AppSettings.Port));
                if (((networkCredentialUserName.Length == 0) || (networkCredentialPassword.Length == 0)))
                {
                    smtpMail.UseDefaultCredentials = true;
                }
                else
                {
                    smtpMail.UseDefaultCredentials = false;
                    System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(networkCredentialUserName, networkCredentialPassword, networkCredentialDomain);
                    smtpMail.Credentials = theCredential;
                }
                // smtpMail.UseDefaultCredentials = false;
                smtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpMail.EnableSsl = AppSettings.EnableSsl;
                await smtpMail.SendMailAsync(myMail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
