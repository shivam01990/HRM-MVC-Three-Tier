using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMWeb.Models
{
    public class AttendanceModel
    {
        public int AttendanceId { get; set; }
        [Display(Name = "PunchIn Time")]
        public DateTime PunchIn { get; set; }
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}