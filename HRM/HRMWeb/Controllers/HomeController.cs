using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMEntity;
using HRMBLL;

namespace HRMWeb.Controllers
{
    public class HomeController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            AnnouncementEntity objAnnouncment = AnnouncementServices.GetAnnouncement();
            List<HolidayEntity> objHolidayList = HolidayServices.GetAllHoliday();
            ViewBag.HolidayList = objHolidayList;
            string AnnouncmentText = objAnnouncment.AnnouncementText;
            AnnouncmentText = AnnouncmentText == null ? string.Empty : AnnouncmentText;
            string AnnouncmentHtml = "";
            if (AnnouncmentText.Trim() != "")
            {
                try
                {
                    string[] AnnouncmentList = AnnouncmentText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                    foreach (string item in AnnouncmentList)
                    {
                        AnnouncmentHtml += "<li class=\"news-item\"><small>" + item + "</small></li>";
                    }
                }
                catch { }
            }
            else
            {
                AnnouncmentHtml = "<li class=\"news-item\"><small>No new Announcments.</small></li>";
            }
            ViewBag.AnnouncementMessage = AnnouncmentHtml;
            return View();
        }
    }
}