using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class ClassSubjectDTO
    {
        public int ClassSubjectId { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Semester Semester { get; set; }

        public int SemesterId { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<StudentClassSubject> StudentClassSubjects { get; set; }
        public ICollection<Transcript> Transcripts { get; set; }
    }
}
