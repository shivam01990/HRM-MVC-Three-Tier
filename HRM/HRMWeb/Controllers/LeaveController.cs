using HRMWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMEntity;
using HRMBLL;
using HRMWeb.Helpers;
using System.Globalization;
using System.Collections;
using System.Threading.Tasks;

namespace HRMWeb.Controllers
{
    public class LeaveController : BaseController
    {
        //
        // GET: /Leave/
        [Authorize]
        public ActionResult ApplyLeave()
        {
            ViewBag.LeaveType = LeaveServices.GetAllLeaveType();
            ViewBag.LeaveDuration = LeaveServices.GetAllLeaveDuration();
            LeaveModel model = new LeaveModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ApplyLeave(LeaveModel model)
        {
            ViewBag.LeaveType = LeaveServices.GetAllLeaveType();
            ViewBag.LeaveDuration = LeaveServices.GetAllLeaveDuration();
            if (ModelState.IsValid)
            {
                DateTime StartDate;
                DateTime EndDate;
                LeaveRequestEntity ob = new LeaveRequestEntity();
                if (model.StartTime == null)
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Warning] = "Please Input Start Date";
                    return View(model);
                }
                if (model.EndTime == null)
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Warning] = "Please Input End Date";
                    return View(model);
                }

                StartDate = model.StartTime == null ? DateTime.Now.Date : (DateTime)model.StartTime;
                EndDate = model.EndTime == null ? DateTime.Now.Date : (DateTime)model.EndTime;

                if (StartDate > EndDate)
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Warning] = "Start Date can not exceed End Date";
                    return View(model);
                }
                ob.RequestId = 0;
                ob.UserId = HRMHelper.CurrentUser.UserId;
                ob.LeaveStatusId = (int)LeaveServices.Leave_status_Type.PendingApproval;
                ob.LeaveTypeId = model.LeaveTypeId;
                ob.LeaveDurationId = model.LeaveDurationId == 0 ? (int)LeaveServices.Leave_Duration.FullDay : model.LeaveDurationId;
                ob.StartTime = StartDate;
                ob.EndTime = EndDate;
                ob.Description = model.Description;
                ob.UpdatedBy = HRMHelper.CurrentUser.UserId;
                int x = LeaveServices.InsertUpdateLeave(ob);
                if (x > 0)
                {
                    ob.RequestId = x;
                    TempData[HRMWeb.Helpers.AlertStyles.Success] = "Leave Applied Successfully";
                    string MailMessage = "You applied for leave from " + ob.StartTime.ToString("MM/dd/yy") + " to " + ob.EndTime.ToString("MM/dd/yy");
                    string Heading = "Leave Applied";
                    try
                    {
                        UserEntity manager = UserServices.GetUserByID(HRMHelper.CurrentUser.ManagerId);
                        string CCMail = manager.Email + "," + AppSettings.HRMail;
                        ArrayList Urltext = new ArrayList();
                        ArrayList Urls = new ArrayList();
                        Urltext.Add("Click Here to check status");
                        Urls.Add(AppSettings.SiteURL + Url.Action("LeaveRecords", "Leave"));
                        await MailUtil.MailSend(Heading, HRMHelper.CurrentUser.Name, MailMessage, Urltext, Urls, HRMHelper.CurrentUser.Email, CCMail, Heading);

                    }
                    catch
                    { }

                }
                else
                {
                    TempData[HRMWeb.Helpers.AlertStyles.Danger] = "Leave Apply Fails";
                    return View(model);
                }
            }
            model = new LeaveModel();
            return View(model);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult LeaveRecords()
        {
            int ManagerId = 0;
            int UserId = 0;
            List<LeaveRequestEntity> lstRequest = new List<LeaveRequestEntity>();
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
            //else
            //{
            //    _startdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month-1, 1);
            //}
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
            List<LeaveStatusTypeEntity> LeaveStatusList = LeaveServices.GetAllLeaveStatus();
            List<LeaveStatusTypeEntity> PersonalLeaveStatus = LeaveServices.GetAllLeaveStatus();
            List<LeaveRequestEntity> model = new List<LeaveRequestEntity>();
            if (User.IsInRole("Admin") || User.IsInRole("Manager"))
            {
                LeaveStatusTypeEntity tempPendingApproval = LeaveStatusList.Where(l => l.StatusId == (int)LeaveServices.Leave_status_Type.PendingApproval).FirstOrDefault();
                LeaveStatusList.Remove(tempPendingApproval);
            }
            else
            {
                LeaveStatusTypeEntity tempApproval = LeaveStatusList.Where(l => l.StatusId == (int)LeaveServices.Leave_status_Type.Approved).FirstOrDefault();
                LeaveStatusTypeEntity tempDeclined = LeaveStatusList.Where(l => l.StatusId == (int)LeaveServices.Leave_status_Type.Declined).FirstOrDefault();
                LeaveStatusList.Remove(tempApproval);
                LeaveStatusList.Remove(tempDeclined);
            }

            {
                LeaveStatusTypeEntity tempApproval = PersonalLeaveStatus.Where(l => l.StatusId == (int)LeaveServices.Leave_status_Type.Approved).FirstOrDefault();
                LeaveStatusTypeEntity tempDeclined = PersonalLeaveStatus.Where(l => l.StatusId == (int)LeaveServices.Leave_status_Type.Declined).FirstOrDefault();
                PersonalLeaveStatus.Remove(tempApproval);
                PersonalLeaveStatus.Remove(tempDeclined);
            }
            if (User.IsInRole("Manager"))
            {
                if (UserId == 0)
                    lstRequest = LeaveServices.GetLeaveByUserId(HRMHelper.CurrentUser.UserId, StartDate, EndDate);
            }
            lstRequest.AddRange(LeaveServices.GetLeave(0, UserId, ManagerId, 0, StartDate, EndDate, 0));
            model = lstRequest.OrderBy(l => l.LeaveStatusId).ThenByDescending(l => l.RequestDate).ToList();
            ViewBag.TotalLeaves = model.Where(s => s.LeaveStatusId == (int)LeaveServices.Leave_status_Type.Approved).Sum(s => s.TotalDays);
            ViewBag.LeaveStatus = LeaveStatusList;
            ViewBag.PersonalLeaveStatus = PersonalLeaveStatus;
            return View(model);
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveLeaveStatus()
        {
            try
            {
                string UnParse = Request.Form["hdnLeaveStatus"].ToString();
                Dictionary<int, int> StatusList = new Dictionary<int, int>();
                List<string> tempstr = new List<string>();
                tempstr = UnParse.Split(',').ToList();
                foreach (string item in tempstr)
                {
                    string data;
                    data = item.Trim('(');
                    data = data.Trim(')');
                    StatusList.Add(int.Parse(data.Split('|').ToArray()[0]), int.Parse(data.Split('|').ToArray()[1]));
                }

                foreach (var item in StatusList)
                {
                    try
                    {
                        LeaveRequestEntity ob = new LeaveRequestEntity();
                        ob = LeaveServices.GetLeaveByRequestId(item.Key);
                        ob.RequestId = item.Key;
                        ob.LeaveStatusId = item.Value;
                        ob.UpdatedBy = HRMHelper.CurrentUser.UserId;
                        LeaveServices.InsertUpdateLeave(ob);
                        if (item.Value != (int)LeaveServices.Leave_status_Type.PendingApproval)
                        {
                            string Heading = GetHeading(item.Value);
                            string MailMessage = "Your " + Heading + " from " + ob.StartTime.ToString("MM/dd/yy") + " to " + ob.EndTime.ToString("MM/dd/yy");
                            try
                            {
                                string CCMail = AppSettings.HRMail;
                                ArrayList Urltext = new ArrayList();
                                ArrayList Urls = new ArrayList();
                                Urltext.Add("Click Here to check status");
                                Urls.Add(AppSettings.SiteURL + Url.Action("LeaveRecords", "Leave"));
                                UserEntity tempUser = UserServices.GetUserByID(ob.UserId);
                                await MailUtil.MailSend(Heading, tempUser.Name, MailMessage, Urltext, Urls, tempUser.Email, CCMail, Heading);
                            }
                            catch
                            { }
                        }
                    }
                    catch
                    { }

                }
                TempData[HRMWeb.Helpers.AlertStyles.Success] = "Leave Status Updated Successfully.";
            }
            catch
            { }
            return RedirectToAction("LeaveRecords", "Leave");
        }

        [Authorize]
        public ActionResult LeaveCalendar()
        {
            return View();
        }

        public string GetHeading(int StatusId)
        {
            string Heading = "";
            if (StatusId == (int)LeaveServices.Leave_status_Type.Approved)
            {
                Heading = "Leave Approved";
            }

            if (StatusId == (int)LeaveServices.Leave_status_Type.Cancelled)
            {
                Heading = "Leave Cancelled";
            }

            if (StatusId == (int)LeaveServices.Leave_status_Type.Declined)
            {
                Heading = "Leave Declined";
            }
            return Heading;

        }


    }
}
