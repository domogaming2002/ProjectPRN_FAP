using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_Project_WPF.DataAccess.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public String RoleName { get; set; }
        [Required]
        public Boolean isDelete;
    }
}
