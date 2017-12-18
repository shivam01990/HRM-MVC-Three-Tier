using HRMEntity;
using HRMWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace HRMWeb.Helpers
{
    public class HRMHelper
    {
        protected const string strCurrentUser = "CurrentUser";
        public static UserEntity CurrentUser
        {
            get
            {
                UserEntity x = null;
                if (HttpContext.Current.Session[strCurrentUser] != null)
                {
                    try
                    {
                        x = (UserEntity)HttpContext.Current.Session[strCurrentUser];
                    }
                    catch
                    {
                        HttpContext.Current.Session[strCurrentUser] = x;
                    }
                }
                else
                {
                    HttpContext.Current.Session[strCurrentUser] = x;
                }

                return x;
            }

            set
            {
                HttpContext.Current.Session[strCurrentUser] = value;
            }
        }

        protected const string strTimeDiffrence = "TimeDiffrence";
        public static TimeSpan TimeDiffrence
        {
            get
            {
                TimeSpan x = new TimeSpan(0);
                if (HttpContext.Current.Session[strTimeDiffrence] != null)
                {
                    try
                    {
                        x = (TimeSpan)HttpContext.Current.Session[strTimeDiffrence];
                    }
                    catch
                    {
                        HttpContext.Current.Session[strTimeDiffrence] = x;
                    }
                }
                else
                {
                    HttpContext.Current.Session[strTimeDiffrence] = x;
                }

                return x;
            }

            set
            {
                HttpContext.Current.Session[strTimeDiffrence] = value;
            }
        }

        public static string GetUserDirectory()
        {
            string path = HttpContext.Current.Server.MapPath("~");
            if (!Directory.Exists(path + "\\Files"))
            {
                Directory.CreateDirectory(path + "\\Files");              
            }
            path += "\\Files";
            if (!Directory.Exists(path + "\\Users"))
            {
                Directory.CreateDirectory(path + "\\Users");              
            }
            path += "\\Users";
            return path;
        }
    }

    public static class AlertStyles
    {
        public const string Success = "success";
        public const string Information = "info";
        public const string Warning = "warning";
        public const string Danger = "danger";
    }

}