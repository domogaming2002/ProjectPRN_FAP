using ProjectPRN_FAP.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class TeacherDTO
    {
        public int TeacherId { get; set; }
        public String TeacherCode { get; set; }
        public int UserId { get; set; }
        public bool IsDelete { get; set; }
        public User User { get; set; }
        public ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}
