using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MVCProjeKamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjeKamp.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminValues = adminManager.GetList();
            return View(adminValues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            Context context = new Context();
            List<SelectListItem> valueRole = (from x in context.Roles.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.RoleID.ToString()
                                              }).ToList();

            ViewBag.roles = valueRole;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            admin.AdminStatus = true;
            adminManager.AdminAdd(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            Context context = new Context();
            List<SelectListItem> valueRole = (from x in context.Roles.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.RoleID.ToString()
                                              }).ToList();

            ViewBag.roles = valueRole;

            var adminValue = adminManager.GetByID(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            admin.AdminStatus = true;
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
        public ActionResult PassiveAdmin(int id)
        {
            using (var context = new Context())
            {
                var passive = context.Admins.Find(id);
                passive.AdminStatus = false;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult ActiveAdmin(int id)
        {
            using (var context = new Context())
            {
                var passive = context.Admins.Find(id);
                passive.AdminStatus = true;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}