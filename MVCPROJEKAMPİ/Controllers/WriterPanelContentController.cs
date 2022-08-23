using BusinessLayer.Concerete;
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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EFContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            var writeridinfo = c.writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
          var contentvalues = cm.GetListByWriter(writeridinfo);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();  
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
          string  p = (string)Session["WriterMail"];
            var writeridinfo = c.writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            content.ContetDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writeridinfo;
            content.ContentStatus = true;
            cm.ContentAdd(content);

            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}