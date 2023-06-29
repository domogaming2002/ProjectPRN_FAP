using PRN221_Project_RazorPage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_Project_WPF.DataAccess.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        public String Name { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public Boolean Gender { get; set; }

        [Required]
        public String Phone { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public String Campus { get; set; }

        [Required]
        public int RoleId { get; set; }
        [Required]
        public Boolean isDelete;

        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }


    }
}
