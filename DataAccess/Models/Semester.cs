using ProjectPRN_FAP.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectPRN_FAP.DataAccess.Models
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }
        [Required]
        public String SemesterName { get; set; }
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        public ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}
