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
    public class ImageFile
    {
        [Key]
        public int ImageID { get; set; }
        [StringLength(300)]
        public string ImageName { get; set; }
        public string Image { get; set; }
    }
}
