using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMEntity;
using HRMDAL;
namespace HRMBLL
{
    public class LeaveServices
    {
        public static int InsertUpdateLeave(LeaveRequestEntity ob)
        {
            return LeaveProvider.InsertUpdateLeave(ob);
        }

        public static List<LeaveRequestEntity> GetLeave(int RequestId, int UserId, int ManagerId, int LeaveStatusId, DateTime? StartDate, DateTime? EndDate, int UpdatedBy)
        {
            return LeaveProvider.GetLeave(RequestId, UserId, ManagerId, LeaveStatusId, StartDate, EndDate, UpdatedBy);
        }

        public static List<LeaveRequestEntity> GetAllLeave()
        {
            return LeaveProvider.GetLeave(0, 0, 0, 0, null, null, 0);
        }

        public static List<LeaveRequestEntity> GetLeaveByStatusId(int LeaveStatusId)
        {
            return LeaveProvider.GetLeave(0, 0, 0, LeaveStatusId, null, null, 0);
        }


        public static LeaveRequestEntity GetLeaveByRequestId(int RequestId)
        {
            return LeaveProvider.GetLeave(RequestId, 0, 0, 0, null, null, 0).FirstOrDefault();
        }

        public static List<LeaveRequestEntity> GetLeaveByUserId(int UserId, DateTime? StartDate, DateTime? EndDate)
        {
            return LeaveProvider.GetLeave(0, UserId, 0, 0, StartDate, EndDate, 0);
        }

        public static List<LeaveStatusTypeEntity> GetLeaveStatus(int StatusId)
        {
            return LeaveProvider.GetLeaveStatus(StatusId);
        }

        public static List<LeaveStatusTypeEntity> GetAllLeaveStatus()
        {
            return LeaveProvider.GetLeaveStatus(0);
        }


        public static List<LeaveTypeEntity> GetLeaveType(int TypeId)
        {
            return LeaveProvider.GetLeaveType(TypeId);
        }

        public static List<LeaveTypeEntity> GetAllLeaveType()
        {
            return LeaveProvider.GetLeaveType(0);
        }


        public static List<LeaveDurationEntity> GetLeaveDuration(int DurationId)
        {
            return LeaveProvider.GetLeaveDuration(DurationId);
        }

        public static List<LeaveDurationEntity> GetAllLeaveDuration()
        {
            return LeaveProvider.GetLeaveDuration(0);
        }

        public enum Leave_status_Type
        {
            PendingApproval = 1,
            Approved = 2,
            Declined = 3,
            Cancelled = 4
        }

        public enum Leave_Duration
        {
            FullDay = 1,
            HalfDayMorning = 2,
            HalfDayAfternoon = 3
        }

    }
}
