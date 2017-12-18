using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMWeb.Models
{
    public class LeaveModel
    {
        [Required]
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> StartTime { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public Nullable<DateTime> EndTime { get; set; }
        [Required]
        [Display(Name = "Leave Status")]
        public int LeaveStatusId { get; set; }

        [Display(Name = "Duration")]
        public int LeaveDurationId { get; set; }

        public string Description { get; set; }

    }
}