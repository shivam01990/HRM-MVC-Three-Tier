using HRMBLL;
using HRMEntity;
using HRMWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMWeb.Controllers
{

    public class InitializeDbController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public InitializeDbController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public InitializeDbController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        //
        // GET: /InitializeDb/
        public ActionResult Index()
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = "Admin"
                });
            }
            if (!context.Roles.Any(r => r.Name == "Manager"))
            {
                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = "Manager"
                });
            }

            if (!context.Roles.Any(r => r.Name == "Employee"))
            {
                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = "Employee"
                });
            }
            context.SaveChanges();
          var _tempuser=  UserManager.FindByName("Admin");
             if(_tempuser==null)
             {
                 var user = new ApplicationUser() { UserName = "Admin" };
                var result =  UserManager.Create(user, "123456");
                  if (result.Succeeded)
                {
                    UserEntity ob = new UserEntity();
                    ob.UserName = user.UserName;
                    ob.Name ="Admin";
                    ob.Status = true;
                    ob.Guid = user.Id;
                    ob.Email = "Admin@admin.com";
                    ob.PersonalEmail = "Admin@admin.com";
                    ob.DesignationId = 1;
                    ob.ContactNo = "9876543210";
                    ob.Address ="";
                    ob.Salary = 0;
                    ob.ManagerId =1;
                    ob.DOB =null;
                    ob.DOJ =null;
                    ob.DOR = null;
                    ob.UserId = UserServices.InsertUpdateUser(ob);
                    if (ob.UserId > 0)
                    {                       
                        UserManager.AddToRole(user.Id,"Admin");
                    }
                    else
                    {
                        var tempUser = UserManager.FindByName("Admin");
                        UserManager.DeleteAsync(tempUser);
                    }
                  }
              
             }

            return RedirectToAction("Login","Account");
        }


    }
}
