using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntittyLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
 
        public DateTime HeadingDate { get; set; }


        //kategori tablosundaki id ile burdaki id ismi aynı olacak
        
        public int CategoryID { get; set; }
        //virtual anahtar kelime kategori tablosundan bir sutunla ilişkilendir
        public virtual  Category Category{ get; set; }

        //baslık hangı yazar tarafından olusturuldu ilişkisi 1 e çok ilişki
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        //heading ile content de ilişkili
        public ICollection<Content> Contents { get; set; }

    }
}
