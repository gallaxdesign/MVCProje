using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProje.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            
            var admininfo = adm.GetbyAdminUsername(p);
            if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(p.AdminUsername, false);
                Session["admininfo"] = p.AdminUsername;
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                return View();
            }




        }
        
    }
}