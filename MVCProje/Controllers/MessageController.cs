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
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var MessageValues = mm.GetMessageListInbox();
            return View(MessageValues);
        }
        public ActionResult Sentbox()
        {
            var MessageValues = mm.GetMessageListSentbox();
            return View(MessageValues);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            var MessageValues = mm.GetMessageListSentbox();
            return View(MessageValues);
        }


        public ActionResult GetInboxMessageDetails(int id)
        {
            var InboxValues = mm.GetByID(id);
            return View(InboxValues);

        }
        public ActionResult GetSentboxMessageDetails(int id)
        {
            var InboxValues = mm.GetByID(id);
            return View(InboxValues);

        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {


            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sentbox");
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