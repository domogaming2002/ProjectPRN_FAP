using ProjectPRN_FAP.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class GradeDTO
    {
        public int GradeID { get; set; }
        public string GradeName { get; set; }
        public double Percent { get; set; }
        public ICollection<SubjectGrade> SubjectGrades { get; set; }
        public bool IsDelete { get; set; }
    }
}
