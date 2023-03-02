using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers
{
    //[Authorize(Roles = "A")]
    public class RoleController : Controller
    {
        RoleManager rm = new RoleManager(new EfRoleDal());
        // GET: Role
        public ActionResult Index()
        {
            var roleValues= rm.GetList();
            return View(roleValues);
        }
        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(Role role)
        {
            rm.RoleAdd(role);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateRole(int id)
        {
            var updateID = rm.GetByID(id);
            return View(updateID);
        }
        [HttpPost]
        public ActionResult UpdateRole(Role role)
        {
            rm.RoleUpdate(role);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteRole(int id) 
        { 
            var deleteID = rm.GetByID(id);  
            rm.RoleDelete(deleteID);
            return RedirectToAction("Index");
        }
    }
}