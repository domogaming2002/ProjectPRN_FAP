using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class ClassGradeDTO
    {
        public int ClassSubjectId { get; set; }
        public int GradeId { get; set; }

        public Grade Grade { get; set; }
        public List<StudentClassSubject> Student { get; set; }

        public List<DetailScoreDTO> DetailScores { get; set; } 
    }
}
