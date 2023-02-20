using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            Context context = new Context();
            var contactCount = context.Contacts.Count().ToString();
            ViewBag.iletisimSayisi = contactCount;
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues=cm.GetByID(id);
            return View(contactValues);
        }
        public PartialViewResult MessageListMenuPartial()
        {
            return PartialView();
        }
    }
}