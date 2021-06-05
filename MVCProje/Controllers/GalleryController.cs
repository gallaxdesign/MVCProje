using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager gm = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var GalleryValues = gm.GetImageFileList();
            return View(GalleryValues);
        }
    }
}