using BusinessLayer.Abstarct;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concerete.Repositories;
using EntityLayer.Concerete;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal ıcategoryDal;

        public CategoryManager(ICategoryDal ıcategoryDal)
        {
            this.ıcategoryDal = ıcategoryDal;
        }

        public void CategoryAdd(Category p)
        {
            ıcategoryDal.Insert(p);
        }

        public void CategoryDelete(Category category)
        {
            ıcategoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            ıcategoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return ıcategoryDal.Get(x => x.CategoryId == id);
        }

        public List<Category> GetCategories()
        {
            return ıcategoryDal.List();
        }
    }
}
