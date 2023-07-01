using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRN_FAP.DataAccess.Models
{
    public class SubjectGrade
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        [Required]
        public bool IsDelete { get; set; }
    }
}
