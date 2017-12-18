using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBLL
{
    public class AppSettings
    {
        #region---App Related--
        public static string AppName
        {
            get { return (ConfigurationManager.AppSettings["AppName"] != null ? ConfigurationManager.AppSettings["AppName"].ToString() : null); }
        }

        public static string SiteURL
        {
            get { return (ConfigurationManager.AppSettings["SiteURL"] != null ? ConfigurationManager.AppSettings["SiteURL"].ToString() : null); }
        }
        #endregion


        #region---Email Settings--
        public static string HRMail
        {
            get { return (ConfigurationManager.AppSettings["HRMail"] != null ? ConfigurationManager.AppSettings["HRMail"].ToString() : ""); }
        }
        public static string SMTPServer
        {
            get { return (ConfigurationManager.AppSettings["SMTPServer"] != null ? ConfigurationManager.AppSettings["SMTPServer"].ToString() : ""); }
        }
        public static int Port
        {
            get { return (ConfigurationManager.AppSettings["port"] != null && ConfigurationManager.AppSettings["port"].ToString() != "" ? int.Parse(ConfigurationManager.AppSettings["port"].ToString()) : 0); }
        }
        public static string NetworkCredentialUserName
        {
            get { return (ConfigurationManager.AppSettings["NetworkCredentialUserName"] != null ? ConfigurationManager.AppSettings["NetworkCredentialUserName"].ToString() : ""); }
        }
        public static string NetworkCredentialPassword
        {
            get { return (ConfigurationManager.AppSettings["NetworkCredentialPassword"] != null ? ConfigurationManager.AppSettings["NetworkCredentialPassword"].ToString() : ""); }
        }
        public static string NetworkCredentialDomain
        {
            get { return (ConfigurationManager.AppSettings["NetworkCredentialDomain"] != null ? ConfigurationManager.AppSettings["NetworkCredentialDomain"].ToString() : ""); }
        }
        public static bool EnableSsl
        {
            get { return (ConfigurationManager.AppSettings["EnableSsl"] != null && ConfigurationManager.AppSettings["EnableSsl"].ToString() != "" ? bool.Parse(ConfigurationManager.AppSettings["EnableSsl"].ToString()) : false); }
        }
        public static string NoReplyEmail
        {
            get { return (ConfigurationManager.AppSettings["noreply"] != null ? ConfigurationManager.AppSettings["noreply"].ToString() : ""); }
        }
        public static string DisplayName
        {
            get { return (ConfigurationManager.AppSettings["displayname"] != null ? ConfigurationManager.AppSettings["displayname"].ToString() : ""); }
        }
        public static string EnquiryOnEmail
        {
            get { return (ConfigurationManager.AppSettings["EnquiryOnEmail"] != null ? ConfigurationManager.AppSettings["EnquiryOnEmail"].ToString() : ""); }
        }
        public static string ErrorlogEmails
        {
            get { return (ConfigurationManager.AppSettings["errorlogemails"] != null ? ConfigurationManager.AppSettings["errorlogemails"].ToString() : ""); }
        }
        public static bool OnErrorEmail
        {
            get { return bool.Parse((ConfigurationManager.AppSettings["OnErrorEmail"] != null ? ConfigurationManager.AppSettings["OnErrorEmail"].ToString() : "false")); }
        }
        #endregion

    }
}
