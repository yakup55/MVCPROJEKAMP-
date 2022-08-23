using BusinessLayer.Concerete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concerete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJEKAMPİ.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager wr = new WriterManager(new EFWriterDal());
        WriterValidatior vr = new WriterValidatior();
        public ActionResult Index()
        {
            var writervalues = wr.GetList();
            return View(writervalues);
        }

        //YAZAR EKLEME
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult result = vr.Validate(writer);

            if (result!=null)
            {
                wr.WriterAdd(writer);
                return RedirectToAction("Index");
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

        //YAZAR DÜZENLEME
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue = wr.GetById(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult result = vr.Validate(writer);

            if (result != null)
            {
                wr.WriterUpdate(writer);
                return RedirectToAction("Index");
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