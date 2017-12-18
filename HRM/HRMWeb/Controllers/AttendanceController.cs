using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMWeb.Models;
using HRMEntity;
using HRMBLL;
using HRMWeb.Helpers;
using System.Globalization;


namespace HRMWeb.Controllers
{
    public class AttendanceController : BaseController
    {
        [Authorize]
        public ActionResult PunchInOut()
        {
            AttendanceModel model = new AttendanceModel();
            AttendanceEntity ObjAttendance = AttendanceServices.GetLastPunchInTime(HRMHelper.CurrentUser.UserId);
            if (ObjAttendance != null)
            {
                model.AttendanceId = ObjAttendance.AttendanceId;
                model.PunchIn = ObjAttendance.PunchIn;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult PunchInOut(AttendanceModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AttendanceEntity ObjAttendance = new AttendanceEntity();
                    ObjAttendance.AttendanceId = model.AttendanceId;
                    if (model.AttendanceId == 0)
                    {
                        ObjAttendance.PunchInMessage = model.Message;
                        ObjAttendance.PunchIn = DateTime.Now;
                    }
                    else
                    {
                        ObjAttendance.PunchOutMessage = model.Message;
                        ObjAttendance.PunchOut = DateTime.Now;
                    }
                    ObjAttendance.UserId = HRMHelper.CurrentUser.UserId;
                    ObjAttendance.AttendanceId = AttendanceServices.PunchInOut(ObjAttendance);
                    TempData[HRMWeb.Helpers.AlertStyles.Success] = "Successfully Saved";
                }
                catch
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Danger] = "Punch In Fails";
                }
            }
            return RedirectToAction("PunchInOut");
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Records()
        {
            int ManagerId = 0;
            int UserId = 0;
            List<AttendanceEntity> AttendenctList = new List<AttendanceEntity>();
            if (User.IsInRole("Admin"))
            {
                ViewBag.UserList = UserServices.GetAllUser();
            }
            if (User.IsInRole("Manager"))
            {
                ViewBag.UserList = UserServices.GetUserByManagerId(HRMHelper.CurrentUser.UserId);
                ManagerId = HRMHelper.CurrentUser.UserId;
            }

            if (Request.Form["lstUser"] != null)
            {
                int.TryParse(Request.Form["lstUser"].ToString(), out UserId);
            }
            ViewBag.SelectedUser = UserId;

            if ((!User.IsInRole("Manager")) && !User.IsInRole("Admin"))
            {
                UserId = HRMHelper.CurrentUser.UserId;
            }


            string _strStartDate = "";
            string _strEndDate = "";
            if (Request.Form["txtStartDate"] != null)
                _strStartDate = Request.Form["txtStartDate"].ToString();
            if (Request.Form["txtEndDate"] != null)
                _strEndDate = Request.Form["txtEndDate"].ToString();

            ViewBag.StartDate = _strStartDate;
            ViewBag.EndDate = _strEndDate;
            DateTime _startdate = new DateTime();
            DateTime _enddate = new DateTime();
            DateTime? StartDate = null;
            DateTime? EndDate = null;
            if (_strStartDate != "")
            {
                DateTime.TryParseExact(_strStartDate, new string[] { "MM/dd/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out _startdate);
            }
            else
            {
                _startdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            if (_strEndDate != "")
            {
                DateTime.TryParseExact(_strEndDate, new string[] { "MM/dd/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out _enddate);
            }


            if (_startdate != new DateTime())
            {
                _startdate = _startdate.Add(HRMHelper.TimeDiffrence);
                StartDate = _startdate;
            }
            if (_enddate != new DateTime())
            {
                _enddate = _enddate.Subtract(HRMHelper.TimeDiffrence);
                EndDate = _enddate;
            }

            if (User.IsInRole("Manager"))
            {
                if (UserId == 0)
                    AttendenctList = AttendanceServices.GetAttendance(0, HRMHelper.CurrentUser.UserId, 0, StartDate, EndDate);
            }
            AttendenctList.AddRange(AttendanceServices.GetAttendance(0, UserId, ManagerId, StartDate, EndDate));
            List<AttendanceEntity> model = AttendenctList.OrderBy(a => a.PunchIn).ToList();
            List<TimeSpan> TotalWorkingHours = (from m in model where m.Duration != null select m.Duration == null ? TimeSpan.Zero : (TimeSpan)m.Duration).ToList();
            ViewBag.TotalHours = TotalWorkingHours.Sum(m => m.TotalHours);
            return View(model);
        }


    }
}
