using PRN221_Project_WPF.DataAccess.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRN221_Project_RazorPage.Models
{
    public class StudentClassSubject
    {
       
        public int StudentClassSubjectId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ClasSubjectId { get; set; }
        public ClassSubject ClassSubject { get; set; }

        [Required]
        public Boolean isDelete;
    }
}
