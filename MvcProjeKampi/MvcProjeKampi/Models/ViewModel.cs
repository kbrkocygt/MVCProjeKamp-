using EntittyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class ViewModel
    {
        public List<Category> Categories {get;set;}
        public List<Content> Contents { get; set; }
        public List<Heading> Headings { get; set; }
        public List<About> Abouts { get; set; }
        public List<Message> Messages { get; set; }
    }
}