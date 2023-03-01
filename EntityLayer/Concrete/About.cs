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
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        [StringLength(500)] 
        public string AboutTitle { get; set; }
        [StringLength(1000)]  //veritabanında AboutDetails1 sütunu için 1000 karakterlik alan oluşturulur
        public string AboutDetails { get; set; }
        public string AboutImageYol { get; set; }
        [NotMapped]
        public IFormFile AboutImage { get; set; }       
        public bool AboutStatus { get; set; }
        
    }
}
