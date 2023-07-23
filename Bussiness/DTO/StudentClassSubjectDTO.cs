using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class StudentClassSubjectDTO
    {
        public int StudentClassSubjectId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ClasSubjectId { get; set; }
        public ClassSubject ClassSubject { get; set; }

        public bool IsDelete { get; set; }
    }
}
