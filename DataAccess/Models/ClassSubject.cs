using PRN221_Project_RazorPage.DataAccess.Models;
using PRN221_Project_RazorPage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_Project_WPF.DataAccess.Models
{
    public class ClassSubject
    {
        [Key]
        public int ClassSubjectId { get; set; }
        [Required]
        public int ClassId { get; set; }
        public Class Class { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Semester Semester { get; set; }

        public int SemesterId { get; set; }
        [Required]
        public Boolean isDelete;
        public ICollection<StudentClassSubject> StudentClassSubjects { get; set; }
        public ICollection<Transcript> Transcripts { get; set; }


    }
}
