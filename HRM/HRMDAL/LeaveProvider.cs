using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMEntity;
using HRMDAL.Repository;

namespace HRMDAL
{
    public class LeaveProvider
    {
        public static int InsertUpdateLeave(LeaveRequestEntity ob)
        {
            try
            {
                int LeaveId = 0;
                using (HRMEntities db = new HRMEntities())
                {
                    System.Data.Entity.Core.Objects.ObjectParameter OutPut = new System.Data.Entity.Core.Objects.ObjectParameter("Output", typeof(int));
                    db.sp_InsertUpdateLeaveRequest(ob.RequestId, ob.UserId, ob.LeaveStatusId, ob.LeaveTypeId, ob.LeaveDurationId, ob.StartTime, ob.EndTime, ob.Description, ob.UpdatedBy, OutPut);
                    LeaveId = int.Parse(OutPut.Value.ToString());
                }

                return LeaveId;
            }
            catch
            {
                throw;
            }
        }

        public static List<LeaveRequestEntity> GetLeave(int RequestId, int UserId, int ManagerId,int LeaveStatusId, DateTime? StartDate, DateTime? EndDate, int UpdatedBy)
        {
            List<LeaveRequestEntity> LeaveList = null;
            try
            {
                using (HRMEntities db = new HRMEntities())
                {
                    LeaveList = (from a in db.sp_GetLeaveRequest(RequestId, UserId, ManagerId, LeaveStatusId, StartDate, EndDate, UpdatedBy)
                                 select new LeaveRequestEntity
                                 {
                                     RequestId = a.RequestId,
                                     UserId = a.UserId,
                                     Name = a.Name,
                                     LeaveTypeId = a.LeaveTypeId,
                                     LeaveTypeName = a.TypeName,
                                     LeaveDurationId = a.LeaveDurationId,
                                     LeaveDurationType = a.DurationType,
                                     TotalDays = a.TotalDays == null ? 0 : (decimal)a.TotalDays,
                                     StartTime = a.StartTime,
                                     EndTime = a.EndTime,
                                     Description = a.Description,
                                     LeaveStatusId = a.LeaveStatusId,
                                     LeaveStatus = a.LeaveStatus,
                                     RequestDate = a.RequestDate,
                                     UpdatedBy = a.UpdatedBy,
                                     UpdatedByName = a.UpdatedByName
                                 }).ToList();
                }
            }
            catch
            {
                throw;
            }
            return LeaveList;
        }

        public static List<LeaveStatusTypeEntity> GetLeaveStatus(int StatusId)
        {
            List<LeaveStatusTypeEntity> rType = null;
            IGenericRepository<LeaveStatusType> repository = new GenericRepository<HRMEntities, LeaveStatusType>();
            try
            {
                rType = repository.FindBy(m => m.StatusId == StatusId || StatusId == 0).Select(m => new LeaveStatusTypeEntity
                {
                    StatusId = m.StatusId,
                    LeaveStatus = m.LeaveStatus
                }).ToList();
            }
            catch
            {
                throw;
            }
            return rType;
        }

        public static List<LeaveTypeEntity> GetLeaveType(int TypeId)
        {
            List<LeaveTypeEntity> rType = null;
            IGenericRepository<LeaveType> repository = new GenericRepository<HRMEntities, LeaveType>();
            try
            {
                rType = repository.FindBy(m => m.TypeId == TypeId || TypeId == 0).Select(m => new LeaveTypeEntity
                {
                    TypeId = m.TypeId,
                    TypeName = m.TypeName
                }).ToList();
            }
            catch
            {
                throw;
            }
            return rType;
        }

        public static List<LeaveDurationEntity> GetLeaveDuration(int DurationId)
        {
            List<LeaveDurationEntity> rType = null;
            IGenericRepository<LeaveDuration> repository = new GenericRepository<HRMEntities, LeaveDuration>();
            try
            {
                rType = repository.FindBy(m => m.DurationId == DurationId || DurationId == 0).Select(m => new LeaveDurationEntity
                {
                    DurationId = m.DurationId,
                    DurationType = m.DurationType
                }).ToList();
            }
            catch
            {
                throw;
            }
            return rType;
        }

    }
}
