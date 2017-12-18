using HRMDAL.Repository;
using HRMEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMDAL
{
    public class HolidayProvider
    {
        public static IGenericRepository<Holiday> repository = new GenericRepository<HRMEntities, Holiday>();
        public static int InsertUpdateHoliday(HolidayEntity ob)
        {
            try
            {
                int HolidayId = 0;
                using (HRMEntities db = new HRMEntities())
                {
                    System.Data.Entity.Core.Objects.ObjectParameter OutPut = new System.Data.Entity.Core.Objects.ObjectParameter("Output", typeof(int));
                    db.sp_InsertUpdateHolidays(ob.HolidayId, ob.HolidayName, ob.StartDate, ob.EndDate, ob.LeaveDurationId, ob.CreatedBy, ob.UpdatedBy, OutPut);
                    HolidayId = int.Parse(OutPut.Value.ToString());
                }

                return HolidayId;
            }
            catch
            {
                throw;
            }
        }

        public static List<HolidayEntity> GetHoliday(int HolidayId, string HolidayName, DateTime? StartDate, DateTime? EndDate, int LeaveDurationId)
        {
            List<HolidayEntity> HolidayList = null;
            try
            {
                using (HRMEntities db = new HRMEntities())
                {
                    HolidayList = (from h in db.sp_GetHoliday(HolidayId, HolidayName, StartDate, EndDate, LeaveDurationId)
                                   select new HolidayEntity
                                   {
                                       HolidayId = h.HolidayId,
                                       HolidayName = h.HolidayName,
                                       StartDate = h.StartDate,
                                       EndDate = h.EndDate,
                                       TotalDays = h.TotalDays == null ? 0 : (decimal)h.TotalDays,
                                       LeaveDurationId = h.LeaveDurationId,
                                       DurationType = h.DurationType,
                                       CreatedBy = h.CreatedBy,
                                       UpdatedBy = h.UpdatedBy,
                                       CreatedOn = h.CreatedOn,
                                       UpdatedOn = h.UpdatedOn
                                   }).ToList();
                }
            }
            catch
            {
                throw;
            }
            return HolidayList;
        }


        public static void DeleteHoliday(int HolidayId)
        {

            try
            {
                Holiday ob = repository.FindBy(x => x.HolidayId == HolidayId).FirstOrDefault();
                repository.Delete(ob);
                repository.Save();
            }
            catch
            {
                throw;
            }

        }
    }
}
