using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [StringLength(200)]
        public string AdminUserName { get; set; }
        [StringLength(100)]
        public string AdminPassword { get; set; }
        public bool AdminStatus { get; set; }
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
