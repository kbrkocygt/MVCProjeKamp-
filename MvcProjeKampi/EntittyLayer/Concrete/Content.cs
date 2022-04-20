using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntittyLayer.Concrete
{
   public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(1000)]
        public String ContentValue { get; set; }
        public String ContentImage { get; set; }

        public DateTime ContentDate{ get; set; }
        public bool ContentStatus { get; set; }

        //heading ile ilşkili sutunlar
        public int  HeadingID{ get; set; }
        public virtual Heading Heading { get; set; }

        //content tablosunda yazar id yazar anahtarı ilişkileri
        public int? WriterID { get; set; }
      public virtual Writer Writer { get; set; }
        
    }
}
