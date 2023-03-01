using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = abm.GetList();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            p.AboutStatus = true;
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult PassiveAbout(int id)
        {
            Context context = new Context();
            var passive = context.Abouts.Find(id);
            passive.AboutStatus = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ActiveAbout(int id)
        {
            Context context = new Context();
            var active = context.Abouts.Find(id);
            active.AboutStatus = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}