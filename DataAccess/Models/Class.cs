using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRN_FAP.DataAccess.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        public String ClassName { get; set; }

        [Required]
        public bool IsDelete { get; set; }
        
        public ICollection<ClassSubject> classSubjects { get; set; }
    }
}
