using PRN221_Project_WPF.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace PRN221_Project_RazorPage.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; } 
       
        [Required]
        public int UserId { get; set; }
        [Required]
        public String StudentCode { get; set; }
        [Required]
        public Boolean isDelete;

        public User User { get; set; }
        
        public ICollection<StudentClassSubject> StudentClassSubjects { get; set; }
        public ICollection<Transcript> Transcripts { get; set; }
    }
}
