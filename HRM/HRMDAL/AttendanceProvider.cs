using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMEntity;
using HRMDAL.Repository;

namespace HRMDAL
{
    public class AttendanceProvider
    {
        public static IGenericRepository<Attendance> repository = new GenericRepository<HRMEntities, Attendance>();
        public static int PunchInOut(AttendanceEntity ob)
        {
            try
            {
                int AttendanceId = 0;
                using (HRMEntities db = new HRMEntities())
                {
                    System.Data.Entity.Core.Objects.ObjectParameter OutPut = new System.Data.Entity.Core.Objects.ObjectParameter("Output", typeof(int));
                    db.sp_InsertUpdateAttendance(ob.AttendanceId, ob.UserId, ob.PunchInMessage, ob.PunchOutMessage, OutPut);
                    AttendanceId = int.Parse(OutPut.Value.ToString());
                }

                return AttendanceId;
            }
            catch
            {
                throw;
            }
        }

        public static AttendanceEntity GetLastPunchInTime(int UserId)
        {
            try
            {
                AttendanceEntity AttendanceObj = null;


                using (HRMEntities db = new HRMEntities())
                {
                    AttendanceObj = (from a in db.Attendances
                                     join u in db.Users on a.UserId equals u.UserId
                                     where ((u.UserId == UserId) && (a.PunchOut == null))
                                     select new AttendanceEntity
                                     {
                                         AttendanceId = a.AttendanceId,
                                         UserId = a.UserId,
                                         UserName = u.UserName,
                                         PunchIn = a.PunchIn,
                                         PunchInMessage = a.PunchInMessage,
                                         PunchOut = a.PunchOut,
                                         PunchOutMessage = a.PunchOutMessage,
                                         Duration = a.Duration
                                     }).FirstOrDefault();

                }
                return AttendanceObj;
            }
            catch
            {
                throw;
            }
        }


        public static List<AttendanceEntity> GetAttendance(int AttendanceId, int UserId,int ManagerId, DateTime? StartDate, DateTime? EndDate)
        {
            List<AttendanceEntity> AttendanceList = null;
            try
            {

                using (HRMEntities db = new HRMEntities())
                {

                    AttendanceList = (from a in db.sp_GetAttendance(AttendanceId, UserId,ManagerId, StartDate, EndDate)
                                      select new AttendanceEntity
                                      {
                                          AttendanceId = a.AttendanceId,
                                          UserId = a.UserId,
                                          UserName = a.UserName,
                                          PunchIn = a.PunchIn,
                                          PunchInMessage = a.PunchInMessage,
                                          PunchOut = a.PunchOut,
                                          PunchOutMessage = a.PunchOutMessage,
                                          Duration = a.Duration
                                      }).ToList();

                }
            }
            catch
            {
                throw;
            }
            return AttendanceList;
        }

    }
}
