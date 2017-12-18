//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRMDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class LeaveRequest
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int LeaveStatusId { get; set; }
        public int LeaveTypeId { get; set; }
        public int LeaveDurationId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public string Description { get; set; }
        public System.DateTime RequestDate { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
    
        public virtual LeaveDuration LeaveDuration { get; set; }
        public virtual LeaveStatusType LeaveStatusType { get; set; }
        public virtual LeaveType LeaveType { get; set; }
        public virtual User User { get; set; }
    }
}
