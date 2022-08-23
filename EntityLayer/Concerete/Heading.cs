using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concerete
{
 public   class Heading//BASLIK
    {
        //prop TAB TAB
        [Key]
        public int HeadinId { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        //İLİŞKİ
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public bool HeadingStatus { get; set; }

        public ICollection <Content>contents { get; set; }
    }
}
