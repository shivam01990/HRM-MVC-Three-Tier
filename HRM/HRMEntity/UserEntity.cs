using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMEntity
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PersonalEmail { get; set; }
        public string Role { get; set; }
        public bool? Status { get; set; }
        public int ManagerId { get; set; }
        public Nullable<int> DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public string Image { get; set; }
        public string ManagerName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        public Nullable<System.DateTime> DOR { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

    }
}
