using BusinessLayer.Concerete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concerete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJEKAMPİ.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidatior mv = new MessageValidatior();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
      public PartialViewResult WriterMessagePartial()
        {
            return PartialView();
        }
        public ActionResult Sendbox() 
        {
            string p = (string)Session["WriterMail"];
            var messagevalues = mm.GetListSendbox(p);
            return View(messagevalues);
        }
        public ActionResult GetInboxWriterHeadingDetails(int id)
        {
            var values = mm.GetByIdMessage(id);
            return View(values);
        }
        public ActionResult GetSendboxWriterHeadingDetails(int id)
        {
            var values = mm.GetByIdMessage(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string sender = (string)Session["WriterMail"];
            FluentValidation.Results.ValidationResult result = mv.Validate(message);

            if (result.IsValid)
            {
                message.SenderMail= sender;
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