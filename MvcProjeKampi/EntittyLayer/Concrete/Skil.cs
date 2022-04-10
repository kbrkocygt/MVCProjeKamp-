using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntittyLayer.Concrete
{
    public class Skil
    {[Key]
        public int SkilID { get; set; }
        [StringLength(100)]
        public string Yetenek { get; set; }
        [StringLength(10)]
        public string YetenekBaşarı { get; set; }
    }
}
