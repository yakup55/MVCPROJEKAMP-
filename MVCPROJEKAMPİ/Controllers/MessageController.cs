
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using FluentValidation;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessLayer.Concerete;
using EntityLayer.Concerete;

namespace MVCPROJEKAMPİ.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidatior mv = new MessageValidatior();
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messagevalues=mm.GetListInbox(p);
            return View(messagevalues);
        }
        public ActionResult Sendbox(string p)
        {
            var messagevalues= mm.GetListSendbox(p);
            return View(messagevalues);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var contactvalues = mm.GetByIdMessage(id);
            return View(contactvalues);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var contactvalues = mm.GetByIdMessage(id);
            return View(contactvalues);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            FluentValidation.Results.ValidationResult result = mv.Validate(message);

            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToString());
               mm.AddMessage(message);

                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();

        }
    }
}