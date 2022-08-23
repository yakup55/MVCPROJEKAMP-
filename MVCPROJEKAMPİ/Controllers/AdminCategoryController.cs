using BusinessLayer.Concrete;
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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager c = new CategoryManager(new EFCategoryDal());
        //Sadece B rolune ait olanlar görebilecek
        [Authorize(Roles="B")]
        public ActionResult Index()
        {
            var categoryvalues = c.GetCategories();
           
            return View(categoryvalues);
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = c.GetById(id);
            c.CategoryDelete(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryvalue = c.GetById(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            c.CategoryUpdate(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidatior cv = new CategoryValidatior();
            ValidationResult result = cv.Validate(p);
            if (result!=null)
            {
                c.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}