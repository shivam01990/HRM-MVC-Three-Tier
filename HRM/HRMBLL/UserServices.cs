using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMEntity;
using HRMDAL;


namespace HRMBLL
{
    public class UserServices
    {
        #region User Methods
        public static int InsertUpdateUser(UserEntity ob)
        {
            return UserProvider.InsertUpdateUser(ob);
        }

        public static UserEntity GetUserByID(int UserId)
        {
            return UserProvider.GetUser(UserId, 0, "", "", "", "").FirstOrDefault();
        }

        public static UserEntity GetUserByName(string UserName)
        {
            return UserProvider.GetUser(0, 0, "", UserName, "", "").FirstOrDefault();
        }

        public static List<UserEntity> GetUserByRoleName(string RoleName)
        {
            return UserProvider.GetUser(0, 0, "", "", "", RoleName);
        }

        public static List<UserEntity> GetUserByManagerId(int ManagerId)
        {
            return UserProvider.GetUser(0, ManagerId, "", "", "", "").OrderBy(m => m.Name).ToList();
        }

        public static List<UserEntity> GetAllUser()
        {
            return UserProvider.GetUser(0, 0, "", "", "", "");
        }

        public static List<UserEntity> GetTodayNotPunchInUsers()
        {
            DateTime CurrentDate = DateTime.UtcNow;
            List<AttendanceEntity> AttendanceList = AttendanceServices.GetAttendance(0, 0, 0, DateTime.Parse(CurrentDate.ToShortDateString()), null);         
            List<UserEntity> rType = new List<UserEntity>();
            foreach (UserEntity User in UserServices.GetAllUser())
            {
                if (User.Role != "Admin")
                {
                    if (AttendanceList.Where(a => a.UserId == User.UserId).Count() == 0)
                    {
                        rType.Add(User);
                    }
                }
            }

           
            return rType;
        }
        #endregion

        #region Designation Methods
        public static DesignationEntity GetDesignation(int DesignationId)
        {
            return UserProvider.GetDesignation(DesignationId).FirstOrDefault();
        }

        public static List<DesignationEntity> GetAllDesignations()
        {
            return UserProvider.GetDesignation(0);
        }
        #endregion
    }
}
