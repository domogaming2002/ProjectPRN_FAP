using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }

        public int UserId { get; set; }
        public String StudentCode { get; set; }
        public bool IsDelete { get; set; }

        public User User { get; set; }

        public ICollection<StudentClassSubject> StudentClassSubjects { get; set; }
        public ICollection<Transcript> Transcripts { get; set; }
    }
}
