using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p="")
        {
            if (p != null)
            {
                var values = cm.GetList(p);
                return View(values);
            }
            else
            {
                var values = cm.GetList();
                return View(values.ToList());
            }
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValues=cm.GetListByHeadingID(id);
            return View(contentValues);
        }
    }
}