using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_Project_WPF.DataAccess.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        public String ClassName { get; set; }

        [Required]
        public Boolean isDelete;
        
        public ICollection<ClassSubject> classSubjects { get; set; }
    }
}
