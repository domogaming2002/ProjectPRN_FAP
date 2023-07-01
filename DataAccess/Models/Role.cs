using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRN_FAP.DataAccess.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public String RoleName { get; set; }
        [Required]
        public bool IsDelete { get; set; }
    }
}
