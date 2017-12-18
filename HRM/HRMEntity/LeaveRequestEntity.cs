using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMEntity
{
    public class LeaveRequestEntity
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; }
        public int LeaveDurationId { get; set; }
        public string LeaveDurationType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }       
        public decimal TotalDays { get; set; }
        public string Description { get; set; }
        public int LeaveStatusId { get; set; }
        public string LeaveStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
    }
}
