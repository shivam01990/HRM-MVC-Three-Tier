﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HRMEntities : DbContext
    {
        public HRMEntities()
            : base("name=HRMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<LeaveDuration> LeaveDurations { get; set; }
        public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }
        public virtual DbSet<LeaveStatusType> LeaveStatusTypes { get; set; }
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
    
        public virtual ObjectResult<sp_GetAttendance_Result> sp_GetAttendance(Nullable<int> attendanceId, Nullable<int> userId, Nullable<int> managerId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var attendanceIdParameter = attendanceId.HasValue ?
                new ObjectParameter("AttendanceId", attendanceId) :
                new ObjectParameter("AttendanceId", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var managerIdParameter = managerId.HasValue ?
                new ObjectParameter("ManagerId", managerId) :
                new ObjectParameter("ManagerId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetAttendance_Result>("sp_GetAttendance", attendanceIdParameter, userIdParameter, managerIdParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_GetLeaveRequest_Result> sp_GetLeaveRequest(Nullable<int> requestId, Nullable<int> userId, Nullable<int> managerId, Nullable<int> leaveStatusId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<int> updatedBy)
        {
            var requestIdParameter = requestId.HasValue ?
                new ObjectParameter("RequestId", requestId) :
                new ObjectParameter("RequestId", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var managerIdParameter = managerId.HasValue ?
                new ObjectParameter("ManagerId", managerId) :
                new ObjectParameter("ManagerId", typeof(int));
    
            var leaveStatusIdParameter = leaveStatusId.HasValue ?
                new ObjectParameter("LeaveStatusId", leaveStatusId) :
                new ObjectParameter("LeaveStatusId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var updatedByParameter = updatedBy.HasValue ?
                new ObjectParameter("UpdatedBy", updatedBy) :
                new ObjectParameter("UpdatedBy", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetLeaveRequest_Result>("sp_GetLeaveRequest", requestIdParameter, userIdParameter, managerIdParameter, leaveStatusIdParameter, startDateParameter, endDateParameter, updatedByParameter);
        }
    
        public virtual ObjectResult<sp_GetUser_Result> sp_GetUser(Nullable<int> userId, Nullable<int> managerId, string name, string userName, string email, string roleName)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var managerIdParameter = managerId.HasValue ?
                new ObjectParameter("ManagerId", managerId) :
                new ObjectParameter("ManagerId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var roleNameParameter = roleName != null ?
                new ObjectParameter("RoleName", roleName) :
                new ObjectParameter("RoleName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetUser_Result>("sp_GetUser", userIdParameter, managerIdParameter, nameParameter, userNameParameter, emailParameter, roleNameParameter);
        }
    
        public virtual int sp_InsertUpdateAttendance(Nullable<int> attendanceId, Nullable<int> userId, string punchInMessage, string punchOutMessage, ObjectParameter output)
        {
            var attendanceIdParameter = attendanceId.HasValue ?
                new ObjectParameter("AttendanceId", attendanceId) :
                new ObjectParameter("AttendanceId", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var punchInMessageParameter = punchInMessage != null ?
                new ObjectParameter("PunchInMessage", punchInMessage) :
                new ObjectParameter("PunchInMessage", typeof(string));
    
            var punchOutMessageParameter = punchOutMessage != null ?
                new ObjectParameter("PunchOutMessage", punchOutMessage) :
                new ObjectParameter("PunchOutMessage", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertUpdateAttendance", attendanceIdParameter, userIdParameter, punchInMessageParameter, punchOutMessageParameter, output);
        }
    
        public virtual int sp_InsertUpdateLeaveRequest(Nullable<int> requestId, Nullable<int> userId, Nullable<int> leaveStatusId, Nullable<int> leaveTypeId, Nullable<int> leaveDurationId, Nullable<System.DateTime> startTime, Nullable<System.DateTime> endTime, string description, Nullable<int> updatedBy, ObjectParameter output)
        {
            var requestIdParameter = requestId.HasValue ?
                new ObjectParameter("RequestId", requestId) :
                new ObjectParameter("RequestId", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var leaveStatusIdParameter = leaveStatusId.HasValue ?
                new ObjectParameter("LeaveStatusId", leaveStatusId) :
                new ObjectParameter("LeaveStatusId", typeof(int));
    
            var leaveTypeIdParameter = leaveTypeId.HasValue ?
                new ObjectParameter("LeaveTypeId", leaveTypeId) :
                new ObjectParameter("LeaveTypeId", typeof(int));
    
            var leaveDurationIdParameter = leaveDurationId.HasValue ?
                new ObjectParameter("LeaveDurationId", leaveDurationId) :
                new ObjectParameter("LeaveDurationId", typeof(int));
    
            var startTimeParameter = startTime.HasValue ?
                new ObjectParameter("StartTime", startTime) :
                new ObjectParameter("StartTime", typeof(System.DateTime));
    
            var endTimeParameter = endTime.HasValue ?
                new ObjectParameter("EndTime", endTime) :
                new ObjectParameter("EndTime", typeof(System.DateTime));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var updatedByParameter = updatedBy.HasValue ?
                new ObjectParameter("UpdatedBy", updatedBy) :
                new ObjectParameter("UpdatedBy", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertUpdateLeaveRequest", requestIdParameter, userIdParameter, leaveStatusIdParameter, leaveTypeIdParameter, leaveDurationIdParameter, startTimeParameter, endTimeParameter, descriptionParameter, updatedByParameter, output);
        }
    
        public virtual int sp_InsertUpdateUser(Nullable<int> userId, string guid, string name, string userName, string email, string personalEmail, Nullable<int> managerId, Nullable<int> designationId, string contactNo, string address, Nullable<decimal> salary, string image, Nullable<System.DateTime> dOB, Nullable<System.DateTime> dOJ, Nullable<System.DateTime> dOR, Nullable<bool> status, ObjectParameter output)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var guidParameter = guid != null ?
                new ObjectParameter("Guid", guid) :
                new ObjectParameter("Guid", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var personalEmailParameter = personalEmail != null ?
                new ObjectParameter("PersonalEmail", personalEmail) :
                new ObjectParameter("PersonalEmail", typeof(string));
    
            var managerIdParameter = managerId.HasValue ?
                new ObjectParameter("ManagerId", managerId) :
                new ObjectParameter("ManagerId", typeof(int));
    
            var designationIdParameter = designationId.HasValue ?
                new ObjectParameter("DesignationId", designationId) :
                new ObjectParameter("DesignationId", typeof(int));
    
            var contactNoParameter = contactNo != null ?
                new ObjectParameter("ContactNo", contactNo) :
                new ObjectParameter("ContactNo", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("Salary", salary) :
                new ObjectParameter("Salary", typeof(decimal));
    
            var imageParameter = image != null ?
                new ObjectParameter("Image", image) :
                new ObjectParameter("Image", typeof(string));
    
            var dOBParameter = dOB.HasValue ?
                new ObjectParameter("DOB", dOB) :
                new ObjectParameter("DOB", typeof(System.DateTime));
    
            var dOJParameter = dOJ.HasValue ?
                new ObjectParameter("DOJ", dOJ) :
                new ObjectParameter("DOJ", typeof(System.DateTime));
    
            var dORParameter = dOR.HasValue ?
                new ObjectParameter("DOR", dOR) :
                new ObjectParameter("DOR", typeof(System.DateTime));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertUpdateUser", userIdParameter, guidParameter, nameParameter, userNameParameter, emailParameter, personalEmailParameter, managerIdParameter, designationIdParameter, contactNoParameter, addressParameter, salaryParameter, imageParameter, dOBParameter, dOJParameter, dORParameter, statusParameter, output);
        }
    
        public virtual int sp_InsertUpdateHolidays(Nullable<int> holidayId, string holidayName, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<int> leaveDurationId, Nullable<int> createdBy, Nullable<int> updatedBy, ObjectParameter output)
        {
            var holidayIdParameter = holidayId.HasValue ?
                new ObjectParameter("HolidayId", holidayId) :
                new ObjectParameter("HolidayId", typeof(int));
    
            var holidayNameParameter = holidayName != null ?
                new ObjectParameter("HolidayName", holidayName) :
                new ObjectParameter("HolidayName", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var leaveDurationIdParameter = leaveDurationId.HasValue ?
                new ObjectParameter("LeaveDurationId", leaveDurationId) :
                new ObjectParameter("LeaveDurationId", typeof(int));
    
            var createdByParameter = createdBy.HasValue ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(int));
    
            var updatedByParameter = updatedBy.HasValue ?
                new ObjectParameter("UpdatedBy", updatedBy) :
                new ObjectParameter("UpdatedBy", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertUpdateHolidays", holidayIdParameter, holidayNameParameter, startDateParameter, endDateParameter, leaveDurationIdParameter, createdByParameter, updatedByParameter, output);
        }
    
        public virtual ObjectResult<sp_GetHoliday_Result> sp_GetHoliday(Nullable<int> holidayId, string holidayName, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<int> leaveDurationId)
        {
            var holidayIdParameter = holidayId.HasValue ?
                new ObjectParameter("HolidayId", holidayId) :
                new ObjectParameter("HolidayId", typeof(int));
    
            var holidayNameParameter = holidayName != null ?
                new ObjectParameter("HolidayName", holidayName) :
                new ObjectParameter("HolidayName", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var leaveDurationIdParameter = leaveDurationId.HasValue ?
                new ObjectParameter("LeaveDurationId", leaveDurationId) :
                new ObjectParameter("LeaveDurationId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetHoliday_Result>("sp_GetHoliday", holidayIdParameter, holidayNameParameter, startDateParameter, endDateParameter, leaveDurationIdParameter);
        }
    }
}