using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMEntity
{
    public class AttendanceEntity
    {
        public int AttendanceId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public System.DateTime PunchIn { get; set; }
        public string PunchInMessage { get; set; }
        public Nullable<System.DateTime> PunchOut { get; set; }
        public string PunchOutMessage { get; set; }
        public Nullable<System.TimeSpan> Duration { get; set; }
    }
}
