using ProjectPRN_FAP.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectPRN_FAP.Models
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
        public bool IsDelete { get; set; }
        public User User { get; set; }
        public ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}
