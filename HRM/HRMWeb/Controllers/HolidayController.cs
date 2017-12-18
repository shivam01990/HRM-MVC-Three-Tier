using HRMBLL;
using HRMEntity;
using HRMWeb.Helpers;
using HRMWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMWeb.Controllers
{
    public class HolidayController : BaseController
    {
        //
        // GET: /Holiday/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<HolidayEntity> model = HolidayServices.GetAllHoliday();
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.LeaveDuration = LeaveServices.GetAllLeaveDuration();
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HolidayModel model)
        {
            ViewBag.LeaveDuration = LeaveServices.GetAllLeaveDuration();
            if (ModelState.IsValid)
            {
                DateTime StartDate;
                DateTime EndDate;
                HolidayEntity ob = new HolidayEntity();
                if (model.StartDate == null)
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Warning] = "Please Input Start Date";
                    return View(model);
                }
                if (model.EndDate == null)
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Warning] = "Please Input End Date";
                    return View(model);
                }
                StartDate = model.StartDate;
                EndDate = model.EndDate;

                if (StartDate > EndDate)
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Warning] = "Start Date can not exceed End Date";
                    return View(model);
                }

                ob.HolidayId = 0;
                ob.HolidayName = model.HolidayName;
                ob.LeaveDurationId = model.LeaveDurationId == 0 ? (int)LeaveServices.Leave_Duration.FullDay : model.LeaveDurationId;
                ob.StartDate = model.StartDate;
                ob.EndDate = model.EndDate;
                ob.UpdatedBy = HRMHelper.CurrentUser.UserId;
                ob.CreatedBy = HRMHelper.CurrentUser.UserId;
                int x = HolidayServices.InsertUpdateHoliday(ob);
                if (x > 0)
                {
                    ob.HolidayId = x;
                    TempData[HRMWeb.Helpers.AlertStyles.Success] = "Holiday Saved Successfully";
                    model = new HolidayModel();
                }
                else
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Danger] = "Save Fails";
                }
            }
            return View(model);
        }


        public ActionResult EditHoliday(int? Id)
        {
            ViewBag.LeaveDuration = LeaveServices.GetAllLeaveDuration();
            int HolidayId = Id == null ? 0 : (int)Id;
            HolidayEntity ob = HolidayServices.GetHolidayById(HolidayId);
            HolidayModel model = new HolidayModel();
            if (ob != null)
            {
                model.HolidayId = ob.HolidayId;
                model.HolidayName = ob.HolidayName;
                model.StartDate = ob.StartDate;
                model.EndDate = ob.EndDate;
                model.LeaveDurationId = ob.LeaveDurationId;
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditHoliday(HolidayModel model)
        {
            ViewBag.LeaveDuration = LeaveServices.GetAllLeaveDuration();
            if (ModelState.IsValid)
            {
                DateTime StartDate;
                DateTime EndDate;
                HolidayEntity ob = new HolidayEntity();
                if (model.StartDate == null)
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Warning] = "Please Input Start Date.";
                    return View(model);
                }
                if (model.EndDate == null)
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Warning] = "Please Input End Date.";
                    return View(model);
                }
                StartDate = model.StartDate;
                EndDate = model.EndDate;

                if (StartDate > EndDate)
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Warning] = "Start Date can not exceed End Date.";
                    return View(model);
                }

                ob.HolidayId = model.HolidayId;
                ob.HolidayName = model.HolidayName;
                ob.LeaveDurationId = model.LeaveDurationId == 0 ? (int)LeaveServices.Leave_Duration.FullDay : model.LeaveDurationId;
                ob.StartDate = model.StartDate;
                ob.EndDate = model.EndDate;
                ob.UpdatedBy = HRMHelper.CurrentUser.UserId;
                ob.CreatedBy = HRMHelper.CurrentUser.UserId;
                int x = HolidayServices.InsertUpdateHoliday(ob);
                if (x > 0)
                {
                    ob.HolidayId = x;
                    TempData[HRMWeb.Helpers.AlertStyles.Success] = "Holiday Edited Successfully.";
                }
                else
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Danger] = "Save Fails";
                }
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHoliday()
        {
            try
            {
                if (Request.Form["hdnHolidayIds"] != null)
                {
                    string UnParse = Request.Form["hdnHolidayIds"].ToString();
                    List<int> StatusList = new List<int>();
                    List<string> tempstr = new List<string>();
                    tempstr = UnParse.Split(',').ToList();
                    foreach (string item in tempstr)
                    {
                        string data;
                        data = item.Trim('(');
                        data = data.Trim(')');
                        StatusList.Add(int.Parse(data));
                    }
                    foreach (var item in StatusList)
                    {
                        HolidayServices.DeleteHoliday(item);
                    }
                    TempData[HRMWeb.Helpers.AlertStyles.Success] = "Holiday Successfully Deleted.";
                }
            }
            catch { }
            return RedirectToAction("Index","Holiday");
        }
    }
}
