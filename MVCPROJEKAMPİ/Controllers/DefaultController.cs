using BusinessLayer.Concerete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJEKAMPİ.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());
        public PartialViewResult Index(int id=0)
        {
            var contentlist = cm.GetListById(id);
            return PartialView(contentlist);
        }
        public ActionResult Headings()
        {
            var headinglist = hm.GetList();
            return View(headinglist);
        }
    }
}