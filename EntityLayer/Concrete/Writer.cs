using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        [StringLength(100)]
        public string WriterName { get; set; }
        [StringLength(100)]
        public string WriterSurname { get; set; }
        public string WriterImage { get; set; }
        [StringLength(1000)]
        public string WriterAbout { get; set; }

        [StringLength(100)]
        public string WriterMail { get; set; }
        [StringLength(200)]
        public string WriterPassword { get; set; }
        [StringLength(150)]
        public string WriterTitle { get; set; }
        public bool WriterStatus { get; set; }
        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
