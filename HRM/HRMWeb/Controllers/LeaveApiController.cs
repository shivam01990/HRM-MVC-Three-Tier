using HRMBLL;
using HRMEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRMWeb.Helpers;
using HRMBLL;
using HRMEntity;
namespace HRMWeb.Controllers
{
    public class LeaveApiController : ApiController
    {
        [Authorize]
        public List<LeaveCalendarEntity> GetApprovedLeaves()
        {
            List<LeaveCalendarEntity> rType = new List<LeaveCalendarEntity>();
            //Default get Last 2 months Data
            List<LeaveRequestEntity> RequestList = LeaveServices.GetLeave(0, 0, 0, (int)LeaveServices.Leave_status_Type.Approved, DateTime.UtcNow.AddMonths(-2), null, 0);
            rType = (from l in RequestList
                     select new LeaveCalendarEntity
                     {
                         id = l.RequestId,
                         title = l.Name + " taken leave for " + l.LeaveDurationType,
                         start = l.StartTime,
                         end = (DateTime)l.StartTime.AddHours((int)l.TotalDays * 24),
                         color = "#3A87AD"
                     }).ToList();
            DateTime CurrentDate = DateTime.UtcNow;
            try
            {
                CurrentDate = CurrentDate.Subtract(HRMHelper.TimeDiffrence);
            }
            catch
            { }
            CurrentDate = DateTime.Parse(CurrentDate.ToShortDateString());
            List<UserEntity> UserList = UserServices.GetTodayNotPunchInUsers();
            List<LeaveCalendarEntity> UserCalenderList = (from u in UserList
                                                          select new LeaveCalendarEntity
                                                         {
                                                             id = u.UserId,
                                                             title = u.Name + " not punchin",
                                                             start = CurrentDate,
                                                             end = CurrentDate,
                                                             color = "#FF4500"
                                                         }).ToList();
            rType.AddRange(UserCalenderList);
            return rType;
        }
    }
}
