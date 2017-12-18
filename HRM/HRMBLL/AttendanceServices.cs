using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMDAL;
using HRMEntity;

namespace HRMBLL
{
    public class AttendanceServices
    {
        public static int PunchInOut(AttendanceEntity ob)
        {
            return AttendanceProvider.PunchInOut(ob);
        }

        public static AttendanceEntity GetLastPunchInTime(int UserId)
        {
            return AttendanceProvider.GetLastPunchInTime(UserId);
        }

        public static List<AttendanceEntity> GetAttendance(int AttendanceId, int UserId,int ManagerId, DateTime? StartDate, DateTime? EndDate)
        {
            return AttendanceProvider.GetAttendance(AttendanceId, UserId,ManagerId, StartDate, EndDate);
        }
    }
}
