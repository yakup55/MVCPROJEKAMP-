using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityLayer.Concerete;

namespace DataAccessLayer.Concerete
{
   public class Context:DbContext
    {
        public Context() : base("Data Source=MSI;Initial Catalog=DbMvcKampi;Integrated Security=True")
        {

        }

        //REFERANS EKLEYEREK ULAŞTIK KLASLARA ENTİTYLAYER SEÇTİK


        public DbSet <About>abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> writers { get; set; }
        public DbSet <Message>Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin>Admins { get; set; }
    }
}
