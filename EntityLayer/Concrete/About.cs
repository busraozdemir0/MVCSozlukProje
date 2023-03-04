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
        [StringLength(500)] //veritabanında AboutTitle sütunu için 500 karakterlik alan oluşturulur
        public string AboutTitle { get; set; }
        public string AboutDetails { get; set; }
        public string AboutImage{ get; set; }     
        public bool AboutStatus { get; set; }
        
    }
}
