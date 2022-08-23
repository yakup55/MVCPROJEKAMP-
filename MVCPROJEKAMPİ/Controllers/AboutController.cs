using BusinessLayer.Concerete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJEKAMPİ.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager am = new AboutManager(new EFAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = am.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AboutAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AboutAdd(About about)
        {
            am.AboutAdd(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartiel()
        {

            return PartialView();
        }
    }
}