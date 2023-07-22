using Microsoft.EntityFrameworkCore;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface IStudentRepository
    {
        public List<StudentDTO>? GetList();
        public StudentDTO? GetById(int studentId);

        public Boolean Create(StudentDTO studentDTO);

        public Boolean Delelte(StudentDTO studentDTO);

        public Boolean Update(StudentDTO studentDTO);
    }
}
