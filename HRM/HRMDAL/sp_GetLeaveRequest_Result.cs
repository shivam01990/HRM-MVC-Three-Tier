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
    
    public partial class sp_GetLeaveRequest_Result
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int LeaveStatusId { get; set; }
        public string LeaveStatus { get; set; }
        public int LeaveTypeId { get; set; }
        public string TypeName { get; set; }
        public int LeaveDurationId { get; set; }
        public string DurationType { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public Nullable<double> TotalDays { get; set; }
        public string Description { get; set; }
        public System.DateTime RequestDate { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
    }
}
