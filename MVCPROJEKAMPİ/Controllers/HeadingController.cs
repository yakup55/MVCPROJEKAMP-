using BusinessLayer.Concerete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJEKAMPİ.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        public ActionResult Index()
        {
            var hedingValues = hm.GetList();
            return View(hedingValues);
        }
        public ActionResult HeadingReport()
        {
            var hedingValues = hm.GetList();
            return View(hedingValues);
        }
        [HttpGet]
        public ActionResult HeadingAdd()
        {

            List<SelectListItem> valucategory = (from x in cm.GetCategories()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem()
                                                {
                                                    Text = x.WriterName + "" + x.WriterSurname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();
            ViewBag.vlw = valuewriter;
            ViewBag.vlc = valucategory;
            return View();
        }
        [HttpPost]
        public ActionResult HeadingAdd(Heading p)
        {
            //BUGÜNÜN TARİHİNİ VERDİM
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            hm.HeadingAdd(p);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HeadingEdit(int id)
        {
            List<SelectListItem> valucategory = (from x in cm.GetCategories()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.vlc = valucategory;

            var headingvalues = hm.GetById(id);
            return View(headingvalues);
        }
        [HttpPost]
        public ActionResult HeadingEdit(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult HeadingDelete(int id)
        {
            var headingvalue = hm.GetById(id);
            headingvalue.HeadingStatus = false;
            hm.HeadingDelete(headingvalue);
            return RedirectToAction("Index");
        }

    }
}