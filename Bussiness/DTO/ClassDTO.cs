using ProjectPRN_FAP.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class ClassDTO
    {

        public int ClassId { get; set; }
        public String ClassName { get; set; }

        public bool IsDelete { get; set; }

        public ICollection<ClassSubject> classSubjects { get; set; }
    }
}
