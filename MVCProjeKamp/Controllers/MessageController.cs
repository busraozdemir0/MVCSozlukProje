using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers
{
    public class MessageController : Controller
    {
        MessageValidator messageValidator = new MessageValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());
        // GET: Message
        [Authorize]
        public ActionResult Inbox()
        {
            Context context=new Context();
            string p = (string)Session["AdminUserName"];
            var messageListIn = mm.GetListInbox(p);
            return View(messageListIn);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["AdminUserName"];
            var messageListSend = mm.GetListSendbox(p);
            return View(messageListSend);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            Context context = new Context();
            string adminMail = (string)Session["AdminUserName"];
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.SenderMail = adminMail;
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteMessage(int id)
        {
            var deleteID=mm.GetByID(id);
            mm.MessageDelete(deleteID);
            return RedirectToAction("Inbox");
        }
        [HttpGet]
        public ActionResult MessageSearch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MessageSearch(string p)
        {
            var values = mm.GetList(p);
            return View(values);
        }
    }
}