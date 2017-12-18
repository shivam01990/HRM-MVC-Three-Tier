using HRMDAL;
using HRMEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBLL
{
    public class HolidayServices
    {
        public static int InsertUpdateHoliday(HolidayEntity ob)
        {
            return HolidayProvider.InsertUpdateHoliday(ob);
        }

        public static List<HolidayEntity> GetHoliday(int HolidayId, string HolidayName, DateTime? StartDate, DateTime? EndDate, int LeaveDurationId)
        {
            return HolidayProvider.GetHoliday(HolidayId, HolidayName, StartDate, EndDate, LeaveDurationId);
        }

        public static List<HolidayEntity> GetAllHoliday()
        {
            return HolidayProvider.GetHoliday(0, "", null, null, 0);
        }

        public static HolidayEntity GetHolidayById(int HolidayId)
        {
            return HolidayProvider.GetHoliday(HolidayId, "", null, null, 0).FirstOrDefault();
        }

        public static List<HolidayEntity> GetHolidayByDurationId(int DurationId)
        {
            return HolidayProvider.GetHoliday(0, "", null, null, DurationId);
        }

        public static void DeleteHoliday(int HolidayId)
        {
            HolidayProvider.DeleteHoliday(HolidayId);
        }
    }
}
