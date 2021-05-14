using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class IstatistikController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var categoryvalues = cm.GetCategoryList();
            ViewBag.KategoriSayi = categoryvalues.Count();

            var baslikfilm = hm.GetHeadingList().Where(x => x.CategoryID == 5);
            ViewBag.filmSayi = baslikfilm.Count();

            var yazarisima = wm.GetWriterList().Where(x => x.WriterName.Contains("u"));
            ViewBag.yazarisima = yazarisima.Count();

            var topcategory = cm.GetCategoryList().Where(x => x.CategoryID == hm.GetHeadingList().GroupBy(c => c.CategoryID).OrderByDescending(c => c.Count()).Select(c => c.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.topcategory = topcategory;

            var categorytrue = cm.GetCategoryList().Where(x => x.CategoryStatus == "True").Count();
            var categoryfalse = cm.GetCategoryList().Where(x => x.CategoryStatus == "False").Count();
            ViewBag.TF = categorytrue - categoryfalse;

            return View();
        }
    }
}