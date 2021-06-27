using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class WriterPanelContenController : Controller
    {
        // GET: WriterPanelConten
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writerid = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentvalues = cm.GetContentListByWriter(writerid);
            return View(contentvalues);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetContentListByHeadingID(id);
            return View(contentvalues);
        }

        [HttpGet]
        public ActionResult EditContent(int id)
        {
            var deger = cm.GetByID(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult EditContent(Content p)
        {
            cm.ContentUpdate(p);
            return RedirectToAction("MyContent");
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {

            string mail = (string)Session["WriterMail"];
            var writerid = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();


            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString()); ;
            p.WriterID = writerid;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }


    }
}