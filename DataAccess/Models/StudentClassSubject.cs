using ProjectPRN_FAP.DataAccess.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectPRN_FAP.Models
{
    public class StudentClassSubject
    {
       
        public int StudentClassSubjectId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ClasSubjectId { get; set; }
        public ClassSubject ClassSubject { get; set; }

        [Required]
        public bool IsDelete { get; set; }
    }
}
