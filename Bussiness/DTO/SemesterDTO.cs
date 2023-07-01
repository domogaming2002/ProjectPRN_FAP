using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class SemesterDTO
    {
        public int SemesterId { get; set; }
        public DateTime StartDate { get; set; }
        public String SemesterName { get; set; }
        public DateTime EndDate { get; set; }

        public Boolean isDelete;

        public ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}
