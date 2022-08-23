using DataAccessLayer.Abstract;
using DataAccessLayer.Concerete.Repositories;
using EntityLayer.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFAdminDal:GenericRepositories<Admin>,IAdminDal
    {
    }
}
