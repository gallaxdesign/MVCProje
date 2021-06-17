using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        HeadingValidator headingValidator = new HeadingValidator();

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading()
        {

            
            //id = 4;
            var values = hm.GetHeadingListbyWriter();
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
                
                p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
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



    }
}