using Microsoft.EntityFrameworkCore;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface IStudentRepository
    {
         List<StudentDTO>? GetList();
         StudentDTO? GetById(int studentId);

        StudentDTO? GetByUserId(int userId);

         Boolean Create(StudentDTO studentDTO);

         Boolean Delelte(StudentDTO studentDTO);

         Boolean Update(StudentDTO studentDTO);
    }
}
