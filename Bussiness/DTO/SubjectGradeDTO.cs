using ProjectPRN_FAP.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class SubjectGradeDTO
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public bool IsDelete { get; set; }
    }
}
