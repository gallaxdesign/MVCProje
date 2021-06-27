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
using PagedList;
using PagedList.Mvc;

namespace MvcProje.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        HeadingValidator headingValidator = new HeadingValidator();
        WriterValidator writerValidator = new WriterValidator();
        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var wvalue = wm.GetByID(id);
            return View(wvalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {

            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading");
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

        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var writerid = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = hm.GetHeadingListbyWriter(writerid);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
          
            List<SelectListItem> valueCategory = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.valcat = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            ValidationResult results = headingValidator.Validate(p);
            if (results.IsValid)
            {

                string wid = (string)Session["WriterMail"];
                var writerid = c.Writers.Where(x => x.WriterMail == wid).Select(y => y.WriterID).FirstOrDefault();
                p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerid;
                p.HeadingStatus = true;
                hm.HeadingAdd(p);
                return RedirectToAction("MyHeading");
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

        public ActionResult DeleteHeading(int id)
        {
            var headingvalues = hm.GetByID(id);
            if (headingvalues.HeadingStatus == true)
            {
                headingvalues.HeadingStatus = false;
                hm.HeadingDelete(headingvalues);
            }
            else
            {
                headingvalues.HeadingStatus = true;
                hm.HeadingDelete(headingvalues);
            }
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valueCategory = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.valcat = valueCategory;
            var hvalue = hm.GetByID(id);
            return View(hvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {

            ValidationResult results = headingValidator.Validate(p);
            if (results.IsValid)
            {
                hm.HeadingUpdate(p);
                return RedirectToAction("Index");
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
        public ActionResult AllHeading(int page=1)
        {
            var headings= hm.GetHeadingList().ToPagedList(page,2);
            return View(headings);
        }



    }
}