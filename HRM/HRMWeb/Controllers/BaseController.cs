using HRMBLL;
using HRMWeb.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMWeb.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (HRMHelper.CurrentUser == null)
                {
                    HRMHelper.CurrentUser = UserServices.GetUserByName(User.Identity.Name);
                    if (ConfigurationManager.AppSettings["TimezoneOffset"] != null)
                    {
                        int miniouts = int.Parse(ConfigurationManager.AppSettings["TimezoneOffset"].ToString());                       
                        HRMHelper.TimeDiffrence = new TimeSpan(0, miniouts, 0);

                    }
                }
            }
        }
    }
}