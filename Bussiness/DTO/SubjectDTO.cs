using ProjectPRN_FAP.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class SubjectDTO
    {
        public int SubjectId { get; set; }

        public String SubjectSubName { get; set; }

        public String SubjectName { get; set; }

        public bool IsDelete { get; set; }

        public ICollection<ClassSubject> ClassSubjects { get; set; }

        public ICollection<SubjectGrade> SubjectGrades { get; set; }
        public ICollection<Transcript> Transcripts { get; set; }

    }
}
