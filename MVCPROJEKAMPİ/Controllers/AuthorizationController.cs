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
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager am = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            var admin=am.GetList();
            return View(admin);
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            am.AdminAdd(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var admin = am.GetByIdAdmin(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            am.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}