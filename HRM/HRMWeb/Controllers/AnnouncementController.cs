using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMWeb.Models;
using HRMBLL;
using HRMEntity;
namespace HRMWeb.Controllers
{
    public class AnnouncementController : BaseController
    {
        //
        // GET: /Announcement/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            AnnouncementModel model = new AnnouncementModel();
            AnnouncementEntity ob = AnnouncementServices.GetAnnouncement();
            model.AnnouncementText = ob.AnnouncementText;
            return View(model);
        }



        // POST: /Announcement/Create
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(AnnouncementModel model)
        {
            if (ModelState.IsValid)
            {
                AnnouncementEntity ob = new AnnouncementEntity();
                ob.AnnouncementText = model.AnnouncementText;
                AnnouncementServices.UpdateAnnouncement(ob);
                TempData[HRMWeb.Helpers.AlertStyles.Success] = "Announcement Successfully Updated";
            }
            return RedirectToAction("Index", "Announcement");
        }

    }
}
