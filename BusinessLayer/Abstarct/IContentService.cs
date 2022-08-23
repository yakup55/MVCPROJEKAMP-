using EntityLayer.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstarct
{
    public interface IContentService
    {
        List<Content> GetList(string p);
        List<Content> GetListById(int id);
        List<Content> GetListByWriter(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
        void ContentAdd(Content content);
        Content GetById(int id);
    }
}
