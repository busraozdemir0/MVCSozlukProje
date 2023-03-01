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
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        public ActionResult HomePage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HomePage(Contact contact)
        {
            contact.ContactDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.ContactAdd(contact);
            return View();
        }
    }
}