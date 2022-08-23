using BusinessLayer.Concerete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJEKAMPİ.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ım = new ImageFileManager(new  EFImageFileDal());
        public ActionResult Index()
        {
            var file=ım.GetList();
            return View(file);
        }
    }
}