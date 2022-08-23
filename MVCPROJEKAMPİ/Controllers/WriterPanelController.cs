using BusinessLayer.Concerete;
using BusinessLayer.Concrete;
using DataAccessLayer.Concerete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MVCPROJEKAMPİ.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        Context c = new Context();
        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidatior vr = new WriterValidatior();
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            id = c.writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).SingleOrDefault();
            var writervalue = wm.GetById(id);
            return View(writervalue);
        }
       
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult result = vr.Validate(writer);

            if (result != null)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("WriterProfile");
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


        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
           var  writeridinfo = c.writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
         
            var heading = hm.GetListByWriter(writeridinfo);
            return View(heading);
        }
        [HttpGet]
    public ActionResult NewHeading()
        {
            

            List<SelectListItem> valuecategory = (from x in cm.GetCategories() select new SelectListItem
            {
                Text=x.CategoryName,
                Value=x.CategoryId.ToString()
            }).ToList();
            ViewBag.vlc=valuecategory;  
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string d = (string)Session["WriterMail"];
            var writeridinfo = c.writers.Where(x => x.WriterMail == d).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            
            heading.WriterId = writeridinfo;
            hm.HeadingAdd(heading);
            heading.HeadingStatus = true;
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult WriterEditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetCategories()
                                                  select new SelectListItem
                                                  {
                                                      Value = x.CategoryId.ToString(),
                                                      Text = x.CategoryName.ToString()
                                                  }).ToList();

            ViewBag.vlc= valuecategory;
            var HeadingValue = hm.GetById(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult WriterEditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult WriterDeleteHeading(int id)
        {
            var heading = hm.GetById(id);   
            heading.HeadingStatus=false;
            hm.HeadingDelete(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int p=1)
        {
            var headings = hm.GetList().ToPagedList(p,5);
            return View(headings);
        }
    }
}