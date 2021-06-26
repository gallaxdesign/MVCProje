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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        WriterManager vm = new WriterManager(new EfWriterDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox() //Bu Tamam
        {
            var deger = mm.GetMessageListInbox();
            return View(deger);
        }

        public PartialViewResult WriterMessageListMenu()
        {
            return PartialView();
        }

        

        public ActionResult UnRead() //Tamam
        {
            var deger = mm.GetUnreadList();
            return View(deger);
        }


        public ActionResult Sentbox() //Tamam
        {
            var deger = mm.GetMessageListSentbox();
            return View(deger);
        }

        //public ActionResult Read() //Tamam
        //{
        //    var deger = mm.GetReadList();
        //    return View(deger);
        //}

        //public ActionResult Draft() //Tamam
        //{
        //    var deger = mm.GetListDraft();
        //    return View(deger);
        //}

        //public ActionResult Trash() //Tamam
        //{
        //    var deger = mm.GetListTrash();
        //    return View(deger);
        //}



        [HttpGet]
        public ActionResult NewMessage() //Tamam
        {
            int id = 4;
            var deger = vm.GetByID(id);
            ViewBag.mail = deger.WriterMail;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message p, string MessageContent) 
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Now;
                //p.MessageContent = MessageContent;
                //p.MessageStatus = "Gönderilen";
                p.SenderMail = "umut@gmail.com";
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
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

        public ActionResult GetInBoxMessageDetails(int id) 
        {
            var values = mm.GetByID(id);
            values.MessageUnread = false;
            mm.MessageUpdate(values);
            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            values.MessageUnread = false;
            mm.MessageUpdate(values);
            return View(values);
        }


        public int UnreadMail()
        {
            var degerler = mm.GetUnreadList();
            return degerler.Count();

        }

        public int UnreadMailContact()
        {
            var degerler = cm.GetUnreadList();
            return degerler.Count();

        }



    }
}