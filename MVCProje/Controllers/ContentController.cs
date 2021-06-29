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
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            var searchvalues = cm.GetContentList(p);
            if (!string.IsNullOrEmpty(p))
            {
                return View(searchvalues.ToList());
            }
            var values = cm.GetAllContentList();
            return View(values.ToList());

        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cm.GetContentListByHeadingID(id);
            return View(contentValues);
        }
    }
}