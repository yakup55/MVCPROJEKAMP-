using EntityLayer.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstarct
{
    public interface IContactService
    {
        List<Contact> GetList();
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
        Contact GetById(int id);
        void AddContact(Contact contact);
    }
}
