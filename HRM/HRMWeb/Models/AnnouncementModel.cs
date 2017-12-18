using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMWeb.Models
{
    public class AnnouncementModel
    {
        [Display(Name = "Message")]
        public string AnnouncementText { get; set; }
    }
}