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

namespace MVCProje.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        AboutValidator aboutValidator = new AboutValidator();
        public ActionResult Index()
        {
            var AboutValues = abm.GetAboutList();
            return View(AboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {

           
            ValidationResult results = aboutValidator.Validate(p);
            if (results.IsValid)
            {
                abm.AboutAdd(p);
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
        [HttpGet]
        public ActionResult EditAbout(int id)
        {
            var wvalue = abm.GetByID(id);
            return View(wvalue);
        }
        [HttpPost]
        public ActionResult EditAbout(About p)
        {

            ValidationResult results = aboutValidator.Validate(p);
            if (results.IsValid)
            {
                abm.AboutUpdate(p);
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
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult StatusChange(int id)
        {
            var status = abm.GetByID(id);
            if (status.AboutStatus == true)
            {
                status.AboutStatus = false;
                abm.AboutUpdate(status);
            }
            else
            {
                status.AboutStatus = true;
                abm.AboutUpdate(status);
            }
            return RedirectToAction("Index");
        }
    }
}