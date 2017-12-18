using HRMDAL.Repository;
using HRMEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMDAL
{
    public class UserProvider
    {
        public static IGenericRepository<User> repository = new GenericRepository<HRMEntities, User>();
        public static int InsertUpdateUser(UserEntity ob)
        {
            int UserID = 0;
            try
            {
                using (HRMEntities db = new HRMEntities())
                {
                    System.Data.Entity.Core.Objects.ObjectParameter OutPut = new System.Data.Entity.Core.Objects.ObjectParameter("Output", typeof(int));
                    db.sp_InsertUpdateUser(ob.UserId, ob.Guid, ob.Name, ob.UserName, ob.Email, ob.PersonalEmail, ob.ManagerId, ob.DesignationId, ob.ContactNo, ob.Address, ob.Salary, ob.Image, ob.DOB, ob.DOJ, ob.DOR, ob.Status, OutPut);
                    UserID = int.Parse(OutPut.Value.ToString());
                }
            }
            catch
            {
                throw;
            }

            return UserID;
        }

        public static List<UserEntity> GetUser(int UserId, int ManagerId, string Name, string UserName, string Email, string Rolename)
        {
            List<UserEntity> rType = new List<UserEntity>();
            try
            {
                using (HRMEntities db = new HRMEntities())
                {
                    rType = (from u in db.sp_GetUser(UserId, ManagerId, Name, UserName, Email, Rolename)
                             select new UserEntity
                               {
                                   UserId = u.UserId,
                                   UserName = u.UserName,
                                   Name = u.Name,
                                   Guid = u.Guid,
                                   Role = u.RoleName,
                                   ManagerId = u.ManagerId,
                                   ManagerName = u.ManagerName,
                                   DesignationId = u.DesignationId,
                                   DesignationName = u.DesignationName,
                                   Email = u.Email,
                                   PersonalEmail = u.PersonalEmail,
                                   ContactNo = u.ContactNo,
                                   Address = u.Address,
                                   Salary = u.Salary,
                                   Image = u.Image,
                                   DOB = u.DOB,
                                   DOJ = u.DOJ,
                                   DOR = u.DOR,
                                   Status = u.Status,
                                   CreatedOn = u.CreatedOn,
                                   UpdatedOn = u.UpdatedOn
                               }
                    ).ToList();

                }
            }
            catch
            {
                throw;
            }
            return rType;
        }



        public static List<DesignationEntity> GetDesignation(int DesignationId)
        {
            List<DesignationEntity> rType = null;
            IGenericRepository<Designation> _repository = new GenericRepository<HRMEntities, Designation>();
            try
            {
                rType = _repository.FindBy(m => m.DesignationId == DesignationId || DesignationId == 0).Select(m => new DesignationEntity
                {
                    DesignationId = m.DesignationId,
                    DesignationName = m.DesignationName
                }).ToList();
            }
            catch
            {
                throw;
            }
            return rType;
        }

    }
}
