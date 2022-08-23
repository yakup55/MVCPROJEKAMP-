using BusinessLayer.Abstarct;
using DataAccessLayer.Abstract;
using EntityLayer.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concerete
{
    public class AdminManager:IAdminService
    {
        IAdminDal _admindal;

        public AdminManager(IAdminDal admindal)
        {
            _admindal = admindal;
        }

        public void AdminAdd(Admin admin)
        {
     _admindal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _admindal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
           _admindal.Update(admin); 
        }

        public Admin GetByIdAdmin(int id)
        {
         return _admindal.Get(x => x.Adminid == id);
        }

        public List<Admin> GetList()
        {
            return _admindal.List();
        }
    }
}
