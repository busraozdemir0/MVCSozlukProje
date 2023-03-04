using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            Context context = new Context();
            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentValues = cm.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.headingID = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            Context context = new Context();
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            p.ContentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ContentStatus = true;
            p.WriterID = writerIdInfo;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }       
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cm.GetListByHeadingID(id);
            return View(contentValues);
        }
    }
}