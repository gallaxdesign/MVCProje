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
    [Authorize]
    public class TalentsController : Controller
    {
        TalentManager tm = new TalentManager(new EfTalentDal());

        public ActionResult Index()
        {
            var talents = tm.GetTalentList();

            return View(talents);
        }

        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTalent(Talent p)
        {
           
            tm.TalentAdd(p);
            return RedirectToAction("Index");
        }

    }
}