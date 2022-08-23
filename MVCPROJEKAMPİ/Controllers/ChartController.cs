using MVCPROJEKAMPİ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJEKAMPİ.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        //Grafikler
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChat()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<Category> BlogList()
        {
            List<Category> list = new List<Category>();
            list.Add(new Category()
            {
                CategoryName = "Bilgisayar",
                CategoryCount = 8
            });
            list.Add(new Category()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            list.Add(new Category()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            list.Add(new Category()
            {
                CategoryName = "Spor",
                CategoryCount = 1   
            });
            return list;
        }
    }
}