using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concerete
{
   public class Category //KATEGORİ
    {
        //prop tab tab
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(200)]
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; } //SİLMEK YERİNE PASİF HALE GETİRCEZ

        public ICollection <Heading>headings { get; set; }
    }
}
