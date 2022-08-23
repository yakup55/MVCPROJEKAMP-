using EntityLayer.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstarct
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        void AddMessage(Message message);
        void UpdateMessage(Message message);
        void DeleteMessage(Message message);
        Message GetByIdMessage(int id);
    }
}
