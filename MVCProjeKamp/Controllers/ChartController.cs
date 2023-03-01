using DataAccessLayer.Concrete;
using MVCProjeKamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKamp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult CategoryListColumnChart()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {   //köprü görevi görecek olan action
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> CategoryList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return ct;
        }


        public ActionResult HeadingListColumnChart()
        {
            return View();
        }
        public ActionResult HeadingChart()
        {
            return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        }
        public List<HeadingClass> HeadingList()
        {
            List<HeadingClass> headingClasses = new List<HeadingClass>();
            using (var context = new Context())
            {
                headingClasses = context.Headings.Select(x => new HeadingClass
                {
                    HeadingName = x.HeadingName,
                    HeadingCount = x.Contents.Count()
                }).ToList();
            }

            return headingClasses;
        }


        public ActionResult WriterListColumnChart()
        {
            return View();
        }
        public ActionResult WriterChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }
        public List<WriterClass> WriterList()
        {
            List<WriterClass> writerClasses = new List<WriterClass>();
            using (var context = new Context())
            {
                writerClasses = context.Writers.Select(x => new WriterClass
                {
                    WriterName=x.WriterName,
                    WriterCount=x.Headings.Count()
                }).ToList();
            }

            return writerClasses;
        }
    }
}