using EntityLayer.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstarct
{
    public interface IAdminService
    {
        List<Admin> GetList();
        void AdminAdd(Admin admin); 
        void AdminUpdate(Admin admin);
        void AdminDelete(Admin admin);
        Admin GetByIdAdmin(int id);
    }
}
