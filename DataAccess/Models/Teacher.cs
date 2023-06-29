using PRN221_Project_WPF.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace PRN221_Project_RazorPage.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public String TeacherCode { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public Boolean isDelete;
        public User User { get; set; }
        public ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}
