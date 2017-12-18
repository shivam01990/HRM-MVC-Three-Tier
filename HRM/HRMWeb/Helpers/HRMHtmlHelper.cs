using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMWeb.Helpers
{
    public static class HRMHtmlHelper
    {
        public static string DisplayLocalTime(DateTime UTCtime)
        {
            UTCtime = UTCtime.Subtract(HRMHelper.TimeDiffrence);
            return String.Format("{0}", UTCtime);
        }

        public static string DisplayLocalTime(this HtmlHelper helper, DateTime? UTCtime)
        {
            DateTime _utctime;
            if (UTCtime == null)
            {
                return "";
            }
            else
            {
                _utctime = (DateTime)UTCtime;
            }
            _utctime = _utctime.Subtract(HRMHelper.TimeDiffrence);
            return String.Format("{0}", _utctime);

        }
    }
}