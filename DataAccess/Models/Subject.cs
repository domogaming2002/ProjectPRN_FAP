using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRN_FAP.DataAccess.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        public String SubjectSubName { get; set; }

        [Required]
        public String SubjectName { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        public ICollection<ClassSubject> ClassSubjects { get; set; }
        
        public ICollection<SubjectGrade> SubjectGrades { get; set; }
        public ICollection<Transcript> Transcripts { get; set; }


    }
}
