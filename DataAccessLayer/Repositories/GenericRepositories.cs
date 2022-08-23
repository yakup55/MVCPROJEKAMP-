using System;
using DataAccessLayer.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;

namespace DataAccessLayer.Concerete.Repositories
{
    public class GenericRepositories<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepositories()
        {
            _object = c.Set<T>();
        }
        public void Delete(T p)
        {
            var delete=c.Entry(p);
            delete.State=EntityState.Deleted;  
           // _object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var add = c.Entry(p);
            add.State = EntityState.Added;
           // _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var update = c.Entry(p);
            update.State = EntityState.Modified;
             c.SaveChanges();
        }
    }
}
