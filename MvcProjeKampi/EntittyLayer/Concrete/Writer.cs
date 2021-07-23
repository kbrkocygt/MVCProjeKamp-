﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntittyLayer.Concrete
{
   public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        [StringLength(50)]
        public String WriteName { get; set; }
        [StringLength(50)]
        public string WriterSurname { get; set; }
        [StringLength(100)]
        public string WriterImage { get; set; }
        [StringLength(50)]
        public string WriterMail { get; set; }
        [StringLength(20)]
        public string WriterPassword { get; set; }


        //baslık ve yazar ilişkisi
        public ICollection<Heading>Headings { get; set; }

        //yazar ile içerik ilişkisi
      public ICollection<Content> Contents { get; set; }
    }
}