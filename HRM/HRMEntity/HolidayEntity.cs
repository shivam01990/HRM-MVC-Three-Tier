using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMEntity
{
    public class HolidayEntity
    {       
        public int HolidayId { get; set; }       
        public string HolidayName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveDurationId { get; set; }
        public string DurationType { get; set; }
        public decimal TotalDays { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}
