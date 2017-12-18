using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMWeb.Models
{
    public class HolidayModel
    {
        [Required]
        public int HolidayId { get; set; }

        [Required]
        [Display(Name = "Occasion Name")]
        public string HolidayName { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Leave Type")]
        public int LeaveDurationId { get; set; }

    }
}