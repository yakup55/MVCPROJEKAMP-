using BusinessLayer.Concerete;
using DataAccessLayer.Concerete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJEKAMPİ.Controllers
{

   
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EFContentDal());
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult GettAllContent(string p)
        {
            var values = cm.GetList(p);
            //if (!string.IsNullOrEmpty(p))
            //{
            //    values = values.Where(y => y.ContentValue.Contains(p));
            //}
            return View(values.ToList());
        }
        public ActionResult HeadingContentByHeading(int id)
        {
            var contentvalues = cm.GetListById(id);
            return View(contentvalues);
        }
    }
}