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
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator contactValidator = new ContactValidator();
        public ActionResult Index()
        {
            var ContactValues = cm.GetContactList();
            return View(ContactValues);
        }
        
        public ActionResult GetContactDetails(int id)
        {
            var ContactValues = cm.GetByID(id);
            return View(ContactValues);

        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Contact p)
        {

           
            ValidationResult results = contactValidator.Validate(p);
            if (results.IsValid)
            {
                cm.ContactAdd(p);
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
        public ActionResult EditContact(int id)
        {
            var wvalue = cm.GetByID(id);
            return View(wvalue);
        }
        [HttpPost]
        public ActionResult EditContact(Contact p)
        {

            ValidationResult results = contactValidator.Validate(p);
            if (results.IsValid)
            {
                cm.ContactUpdate(p);
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

        public int ContacInboxMail()
        {

            var degerler = mm.GetMessageListInbox(); 
            return degerler.Count();


        }

        public int MessageMail()
        {

            var degerler = cm.GetContactList();
            return degerler.Count();


        }
    }
}