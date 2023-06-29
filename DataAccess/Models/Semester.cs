using PRN221_Project_WPF.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace PRN221_Project_RazorPage.DataAccess.Models
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
        public Boolean isDelete;

        public ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}
