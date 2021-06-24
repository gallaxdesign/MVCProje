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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyContent()
        {            
            var contentvalues = cm.GetContentListByWriter();
            return View(contentvalues);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByHeadingID(id);
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
        public ActionResult AddContent(Content p, string s)
        {
            Context c = new Context();
            s = (string)Session["WriterMail"];
            var deger = c.Writers.Where(x => x.WriterMail == s).Select(a => a.WriterID).FirstOrDefault();
            int id = deger;

            p.ContentDate = DateTime.Now;
            p.WriterID = id;
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